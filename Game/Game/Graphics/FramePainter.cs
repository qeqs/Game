using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Game.Graphics
{
    class FramePainter
    {
        
        public void Render(BufferedGraphics g,Frame frame, Dictionary<SpriteEnum,Image> textures,double prediction)
        {
            if (frame == null) return;

            g.Graphics.FillRectangle(Brushes.Black, g.Graphics.ClipBounds);

            foreach(Sprite s in frame.sprites)
            {
                //g.Graphics.DrawImage()
            }
        }
    }
}
