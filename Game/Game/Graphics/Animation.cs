using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Graphics
{
    class Animation
    {
        Point2[] points = new Point2[3];
        private Point2 loc;
        private Sprite sprite;
        private double angle;
        private double durationCounter = 0;
        int frame = 0;
        public double X { get { return loc.X; } set { loc.X = (float)value; } }
        public double Y { get { return loc.Y; } set { loc.Y = (float)value; } }
        public double Duration { get; set; }

        public Point2 Loc
        {
            get
            {
                return loc;
            }

            set
            {
                if (!loc.Equals(value))
                {
                    double x = value.X - loc.X;
                    double y = value.Y - loc.Y;
                    loc = value;
                    for (int i = 0; i < 3; i++)
                    {
                        points[i].X += x;
                        points[i].Y += y;
                    }
                }
            }
        }

        public Sprite Sprite
        {
            get
            {
                return sprite;
            }
        }
        public double R { get { return Math.Sqrt((sprite.Size.Height / 2) * (sprite.Size.Height / 2) + (sprite.Size.Width / 2) * (sprite.Size.Width / 2)); } }
        public double Angle
        {
            get
            {
                return angle;
            }

            set
            {
                angle = value;
            }
        }

        public Point2 Center
        {
            get
            {
                return new Point2(loc.X + sprite.Size.Width / 2.0f, loc.Y + sprite.Size.Height / 2.0f);
            }
        }

        public Point2[] Points
        {
            get
            {
                return points;
            }

            set
            {
                points = value;
            }
        }
    }
}
