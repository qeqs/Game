﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Graphics
{
    class Sprite
    {
        SpriteEnum name;
        Point2 loc;
        Size size;
        #region props
        public SpriteEnum Name
        {
            get
            {
                return name;
            }
        }

        internal Point2 Loc
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

        public Size Size
        {
            get
            {
                return size;
            }

            set
            {
                size = value;
            }
        }
        #endregion
        //
        //Image[] images; 
        //public Image this[int i] 
        //{ 
        // get { return images[i]; } 
        //} 
        //public int Length 
        //{ 
        // get { return images.Length; } 
        //} 
        public Sprite(SpriteEnum name, double x, double y, int w, int h)
        {
            this.name = name;
            loc = new Point2(x, y);
            size = new Size(w, h);

        }
        public Sprite(SpriteEnum name, Point2 loc, Size size) : this(name, loc.X, loc.Y, size.Width, size.Height) { }


    }
}
