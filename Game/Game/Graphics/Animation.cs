using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Graphics
{
    class Animation
    {
        private bool isStarted = false;
        private Point2 loc;
        private Sprite sprite;
        private double angle;
        private double durationCounter = 0;
        //private int frame = 0;
        private int lastframe;
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
                    //double x = value.X - loc.X;
                    //double y = value.Y - loc.Y;
                    loc = value;
                    //for (int i = 0; i < 3; i++)
                    //{
                    //    points[i].X += x;
                    //    points[i].Y += y;
                    //}
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
                return new Point2(loc.X + sprite.Size.Width / 2.0, loc.Y + sprite.Size.Height / 2.0);
            }
        }

        public Point2[] Points
        {
            get
            {
                return sprite.Points;
            }
        }
        public bool IsStarted
        {
            get
            {
                return isStarted;
            }
        }
        public Animation(Sprite sprite, Point2 loc, double duration, double angle) : this(sprite, loc.X, loc.Y, duration, angle) { }
        public Animation(Sprite sprite, double x, double y, double duration, double angle)
        {
            loc = new Point2(x, y);
            Duration = duration;
            this.sprite = sprite;
            Angle = angle;
            lastframe = Config.Sprites[sprite.Name].frames;
        }
        public void Animate()
        {
            if (isStarted)
            {
                durationCounter += Config.MS_PER_UPDATE/1000;
                if (durationCounter > Duration)
                {
                    sprite.CurrentFrame++;
                    sprite.Points[0] = new Point2(Center.X + R * Math.Cos(-Angle + 3 * Math.PI / 4), Center.Y - R * Math.Sin(-Angle + 3 * Math.PI / 4));
                    //loc = sprite.Points[0];
                    sprite.Points[1] = new Point2(Center.X + R * Math.Cos(-Angle + Math.PI / 4), Center.Y - R * Math.Sin(-Angle + Math.PI / 4));
                    sprite.Points[2] = new Point2((Center.X + R * Math.Cos(-Angle + 5 * Math.PI / 4)), (Center.Y - R * Math.Sin(-Angle + 5 * Math.PI / 4)));
                    durationCounter = 0;
                }
                if (sprite.CurrentFrame > lastframe) { sprite.CurrentFrame = 0; isStarted = false; }
            }
            
        }
        public void Start()
        {
            isStarted = true;
        }
        public void Abort(bool startFrame)
        {
            if(startFrame)
            sprite.CurrentFrame = 0;
            isStarted = false;
        }
        public void SetAngleToPoint(Point2 e)
        {
            double ax = -(Center.X - Points[0].X);//(float)(boxer.Center.X - boxer.Points[0].X+(boxer.Points[2].X- boxer.Points[0].X)/2.0f);
            double ay = -(Center.Y - Points[0].Y);//(float)(boxer.Center.Y - boxer.Points[0].Y+(boxer.Points[2].Y-boxer.Points[0].Y)/2.0f);
            double bx = e.X -Center.X;
            double by = e.Y - Center.Y;

            Angle += Math.Atan2((ax * by - ay * bx), (ax * bx + ay * by)) - Math.PI / 4;
        }
    }
}