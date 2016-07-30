﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Graphics
{
    class Animation
    {
        private Point2 loc;
        private Sprite sprite;
        public double X { get { return loc.X; } set { loc.X = value; } }
        public double Y { get { return loc.Y; } set { loc.Y = value; } }
        public double Duration { get; set; }

        public Point2 Loc
        {
            get
            {
                return loc;
            }

            set
            {
                loc = value;
            }
        }

        internal Sprite Sprite
        {
            get
            {
                return sprite;
            }

            set
            {
                sprite = value;
            }
        }

        public Animation() { }
        public Animation(Point2 loc,double duration):this(loc.X,loc.Y,duration) { }
        public Animation(double x, double y,double duration)
        {
            loc = new Point2(x, y);
            Duration = duration;
        }
    }
}
