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
        public GameController()
        {
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
                    frame =Update();
                    lag -= Config.MS_PER_UPDATE;
                }

                painter.Render(gx,frame,textures,lag / Config.MS_PER_UPDATE);
            }
        }
        private Frame Update()
        {
            Frame frame = new Frame();

            //здесь нужно выбрать объекты которые попали в кадр и поместиь их в frame

            //здесь нужно вызвать update у всех объектов
            foreach(IObject o in objects)
            {
                o.Update();
            }

            return frame;
        }


    }
}
