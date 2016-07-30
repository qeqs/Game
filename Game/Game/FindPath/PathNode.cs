using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Graphics;

namespace Game.FindPath
{
    class PathNode
    {
        public Point2 Position { get; set; }
        public int PathLengthFromStart { get; set; }
        public PathNode CameFrom { get; set; }
        public int HeuristicEstimatePathLength { get; set; }
        public int EstimateFullPathLength
        {
            get
            {
                return this.PathLengthFromStart + this.HeuristicEstimatePathLength;
            }
        }

        public static List<Point2> FindPath(int[,] field, Point2 start, Point2 goal)
        {
            Collection<PathNode> closedSet = new Collection<PathNode>();
            Collection<PathNode> openSet = new Collection<PathNode>();

            PathNode startNode = new PathNode()
            {
                Position = start,
                CameFrom = null,
                PathLengthFromStart = 0,
                HeuristicEstimatePathLength = GetHeuristicPathLength(start, goal)
            };
            openSet.Add(startNode);

            while (openSet.Count > 0)
            {
                PathNode currentNode = openSet.OrderBy(node => node.EstimateFullPathLength).First();

                if (currentNode.Position.ToPoint() == goal.ToPoint())
                    return GetPathForNode(currentNode);

                openSet.Remove(currentNode);
                closedSet.Add(currentNode);

                foreach (PathNode neighbourNode in GetNeighbours(currentNode, goal, field))
                {
                    if (closedSet.Count(node => node.Position.ToPoint() == neighbourNode.Position.ToPoint()) > 0)
                        continue;
                    PathNode openNode = openSet.FirstOrDefault(node => node.Position.ToPoint() == neighbourNode.Position.ToPoint());

                    if (openNode == null)
                        openSet.Add(neighbourNode);
                    else if (openNode.PathLengthFromStart > neighbourNode.PathLengthFromStart)
                    {
                        openNode.CameFrom = currentNode;
                        openNode.PathLengthFromStart = neighbourNode.PathLengthFromStart;
                    }
                }
            }
            return null;
        }

        private static int GetHeuristicPathLength(Point2 from, Point2 to)
        {
            return (int)(Math.Abs(from.X - to.X) + Math.Abs(from.Y - to.Y));
        }

        private static List<Point2> GetPathForNode(PathNode pathNode)
        {
            List<Point2> result = new List<Point2>();
            PathNode currentNode = pathNode;
            while (currentNode != null)
            {
                result.Add(currentNode.Position);
                currentNode = currentNode.CameFrom;
            }
            result.Reverse();
            return result;
        }

        private static Collection<PathNode> GetNeighbours(PathNode pathNode, Point2 goal, int[,] field)
        {
            Collection<PathNode> result = new Collection<PathNode>();

            Point2[] neighbourPoints = new Point2[4];
            neighbourPoints[0] = new Point2(pathNode.Position.X + 1, pathNode.Position.Y);
            neighbourPoints[1] = new Point2(pathNode.Position.X - 1, pathNode.Position.Y);
            neighbourPoints[2] = new Point2(pathNode.Position.X, pathNode.Position.Y + 1);
            neighbourPoints[3] = new Point2(pathNode.Position.X, pathNode.Position.Y - 1);

            foreach (Point2 point in neighbourPoints)
            {
                if (point.ToPoint().X < 0 || point.ToPoint().X >= field.GetLength(0))
                    continue;
                if (point.ToPoint().Y < 0 || point.ToPoint().Y >= field.GetLength(1))
                    continue;
                if ((field[point.ToPoint().X, point.ToPoint().Y] != 0) && (field[point.ToPoint().X, point.ToPoint().Y] != 1))
                    continue;

                PathNode neighbourNode = new PathNode()
                {
                    Position = point,
                    CameFrom = pathNode,
                    PathLengthFromStart = pathNode.PathLengthFromStart + GetDistanceBetweenNeighbours(),
                    HeuristicEstimatePathLength = GetHeuristicPathLength(point, goal)
                };
                result.Add(neighbourNode);
            }
            return result;
        }

        private static int GetDistanceBetweenNeighbours()
        {
            return 1;
        }
    }
}
