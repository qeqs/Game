using System;
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
        Point2 loc;//вроде и не нужно
        Size size;
        private Point2[] points = new Point2[3];
        public int CurrentFrame { get; set; } = 0;
        public Point2[] Points { get { return points; } set { points = value; } }
        public Bitmap FromImage(Image image,int Frame)
        {
            return ((Bitmap)image).Clone(new RectangleF(Size.Width * (Frame), 0, Size.Width, Size.Height), System.Drawing.Imaging.PixelFormat.DontCare);
        }
        public Bitmap FromImage(Image image)
        {
            return FromImage(image, CurrentFrame);
        }
        #region props
        public SpriteEnum Name
        {
            get
            {
                return name;
            }
        }

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
        
        public Sprite(SpriteEnum name, double x, double y, int w, int h)
        {
            this.name = name;
            loc = new Point2(x, y);
            size = new Size(w, h);

        }
        public Sprite(SpriteEnum name, Point2 loc, Size size) : this(name, loc.X, loc.Y, size.Width, size.Height) { }


    }
}
