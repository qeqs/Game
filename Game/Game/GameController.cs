using Game.Graphics;
using Game.Objects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    class GameController
    {
        private List<IObject> objects = new List<IObject>();
        private FramePainter painter = new FramePainter();
        private Dictionary<SpriteEnum, Image> textures;
        private Stopwatch time = new Stopwatch();
        private Frame frame;
        private Map map;
        private Rectangle view;
        /* 
        Rectangle rect1 = new Rectangle(x1, y1, 50, 50);
            Rectangle view = new Rectangle(x - (Width / 2 - 50), y - (Height / 2 - 50), Width, Height);
            if(rect1.IntersectsWith(view))
            {
                g.FillRectangle(Brushes.Red, new Rectangle(rect1.X-view.X, rect1.Y-view.Y, rect1.Width, rect1.Height));
            }    
        */
        public GameController()
        {
            frame = new Frame();
        }
        public void Process(BufferedGraphics gx)
        {
            //MS_PER_UPDATE - это дробность наших обновлений игры. 
            
            double lag = 0.0;
            while (true)
            {
                
                double elapsed = time.ElapsedMilliseconds;
                time.Restart();
                lag += elapsed;

                //processInput();
                Frame frame = null;
                while (lag >= Config.MS_PER_UPDATE)
                {
                   Update();
                    lag -= Config.MS_PER_UPDATE;
                }

                AnimationControl();
                painter.Render(gx,frame,map,view,textures,lag / Config.MS_PER_UPDATE);
            }
        }
        private void Update()
        {

            //здесь нужно выбрать объекты которые попали в кадр и поместиь их в frame

            //здесь нужно вызвать update у всех объектов
            foreach(IObject o in objects)
            {
                o.Update();
            }
            
        }
        private void AnimationControl()
        {
            foreach (IObject o in objects)
                foreach (Animation a in o.AnimationArray)
                    a.Animate();
        }
    }
}
