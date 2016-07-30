using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Game.Objects;

namespace Game.Graphics
{
    class FramePainter
    {
        List<int[]> mapsTextures;
        PointF[] points = new PointF[3];
        public void Render(BufferedGraphics g,Frame frame, Map map,Rectangle view, Dictionary<SpriteEnum,Image> textures,double prediction)
        {
            if (frame == null) return;

            g.Graphics.FillRectangle(Brushes.Black, g.Graphics.ClipBounds);

            mapsTextures = Utils.GetChangedBackground(view.Location, view.Size);
            for(int i = 0; i<mapsTextures.Count;i++)
            {
                Sprite temp = map[mapsTextures[i][0], mapsTextures[i][1]];
                Point point = map.GetLocationByIndex(mapsTextures[i][0], mapsTextures[i][1]).ToPoint();
                g.Graphics.DrawImage(temp.FromImage(textures[temp.Name], 0), point.X,point.Y,map.CellSize,map.CellSize);
            }
            
            foreach(Sprite s in frame.sprites.OrderBy(x => Config.Sprites[x.Name].depth))
            {
                for (int i = 0; i < 3; i++)
                    points[i] = s.Points[i].ToPointF();
                g.Graphics.DrawImage(s.FromImage(textures[s.Name]), points, new RectangleF(new PointF(0, 0), new SizeF(s.Size.Width, s.Size.Height)), GraphicsUnit.Pixel);
            }
        }
    }
}
