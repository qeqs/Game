using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Graphics
{
    enum SpriteEnum
    {
        ground,background
    }
    class Config//сюда кидаем константы для графики(загружать из файла?)
    {
        public static int MS_PER_UPDATE;
        public class SpriteConfig
        {
            public string texture;
            public int frames;
            public int yframes;
            public int xframes;
            public int depth;//чем больше это значение тем выше рисуем спрайт

            public SpriteConfig(string file,int xframes,int yframes,int depth=0)
            {
                texture = file;
                this.xframes = xframes;
                this.yframes = yframes;
                frames = xframes * yframes;
                this.depth = depth;
            }
            public SpriteConfig(string file,int depth = 0) : this(file, 1, 1, depth) { }
        }
        public static Dictionary<SpriteEnum, SpriteConfig> Sprites = new Dictionary<SpriteEnum, SpriteConfig>();//здесь все доступные спрайты

        static Config()
        {

            string[] s = Properties.Resources.Config.Split(' ');
            s = s.SkipWhile(x => { int i; return !int.TryParse(x, out i); }).ToArray();

            MS_PER_UPDATE = int.Parse(s[0]);

            Sprites.Add(SpriteEnum.background, new SpriteConfig(null));//здесь закидываем текстуры
        
        }
    }
}
