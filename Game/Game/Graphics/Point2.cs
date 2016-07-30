using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Game.Graphics
{
    struct Point2
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Point2(double x, double y)
        {
            this.X = x; this.Y = y;
        }
        public void Normalize(double k)
        {
            double m = Math.Sqrt(X * X + Y * Y);
            X /= m; X *= k;
            Y /= m; Y *= k;
        }

        public static Point2 operator +(Point2 p1, Point2 p2)
        {
            return new Point2(p1.X + p2.X, p1.Y + p2.Y);
        }

        public static Point2 operator -(Point2 p1, Point2 p2)
        {
            return new Point2(p1.X - p2.X, p1.Y - p2.Y);
        }


        public static Point2 operator -(Point2 p)
        {
            return new Point2(-p.X, -p.Y);
        }

        public static Point2 operator *(Point2 p, double k)
        {
            return new Point2(p.X * k, p.Y * k);
        }

        public static Point2 operator /(Point2 p, double k)
        {
            return new Point2(p.X / k, p.Y / k);
        }

        public static double operator %(Point2 p1, Point2 p2) // scalar product
        {
            return p1.X * p2.X + p1.Y * p2.Y;
        }

        public static double operator *(Point2 p1, Point2 p2) // vector product
        {
            return p1.X * p2.Y - p1.Y * p2.X;
        }

        public PointF ToPointF()
        {
            return new PointF((float)X, (float)Y);
        }
        public Point ToPoint()
        {
            return new Point((int)X, (int)Y);
        }

        public double Length()
        {
            return Math.Sqrt(X * X + Y * Y);
        }
        public double DistTo(Point2 to)
        {
            return Math.Sqrt((X - to.X) * (X - to.X) + (Y - to.Y) * (Y - to.Y));
        }

        public double getAngle(Point2 u)
        {
            Point2 v = this;
            return Math.Atan2(v * u, v % u) / Math.PI * 180;
        }


        /// <summary>
        /// Угол в градусах
        /// </summary>
        public double angleTo(Point2 to)
        {
            double angle = Math.Atan((to.Y - Y) / (to.X - X)) / Math.PI * 180;

            return angle;
        }

        //внутренняя вспомогательная
        //1- точка слева от вектора, -1 - точка справа от вектора, 0 - на прямой вектора
        int PointRelativelyVector(Point2 to)
        {
            double s = X * (to.Y - Y) - Y * (to.X - X);
            if (s > 0) return 1;
            else if (s < 0) return -1;
            else return 0;
        }

    }
}
