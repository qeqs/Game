using Game.Graphics;
using Game.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Utils
    {
        public static Map map = new Map();
        private static List<int[]> res = new List<int[]>();

        /// <summary>
        /// Выдает координаты тех тайлов карты, которые были изменены
        /// </summary>
        /// <param name="loc">положение картинки</param>
        /// <param name="size">размеры картинки</param>
        /// <returns>координаты тайлов на матрице карты, которые нужно перерисовать</returns>
        public static List<int[]> GetChangedBackground(Point loc, Size size)
        {
            res.Clear();
            int x = loc.X / map.CellSize;
            int y = loc.Y / map.CellSize;
            int dx = (loc.X + size.Width) / map.CellSize;
            int dy = (loc.Y + size.Height) / map.CellSize;
            
            for(int i = 0; i < dx - x;i++)
            {
                for (int j = 0; j < dy - y; j++)
                    res.Add(new int[] { x + i, y + j });
            }
            return res;
        }
        
        public static Dictionary<SpriteEnum, Image> InitializeTexures()
        {
            Dictionary<SpriteEnum, Image> tex = new Dictionary<SpriteEnum, Image>();
            foreach(KeyValuePair<SpriteEnum, Config.SpriteConfig> pair in Config.Sprites)
            {
                tex.Add(pair.Key, new Bitmap(pair.Value.texture));
            }
            return tex;
        }//TODO: здесь будем создавать объекты
        public static List<IObject> InitializeObjects(Map map)
        {
            List<IObject> objs = new List<IObject>();
            return objs;
        }
    }
    class Rand
    {
        static Random rand= new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
        static RNGCryptoServiceProvider _rand = new RNGCryptoServiceProvider();
       
        public static bool GetSign(double chance)
        {
            int max = (int)DateTime.Now.Ticks & 0x0000FFFF;
            int min = (int)(chance * max);
            int number = rand.Next(0, max);
            return 0 >= number && number <= min;
        }
        public static bool GetSign(int chance)
        {
            byte[] buff = new byte[1];
            _rand.GetBytes(buff);
            return buff[0] % chance == 0;
        }
        public static int GetNext(int max)
        {
            return rand.Next(0, max);
        }
        public static int GetNext(int min,int max)
        {            
            return rand.Next(min, max);
        }
    }
}
