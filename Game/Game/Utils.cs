using System;
using System.Collections.Generic;
using System.Linq;
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
        public static List<int[]> GetChangedBackground(int[] loc, int[] size)
        {
            res.Clear();
            int x = loc[0] / map.CellSize;
            int y = loc[1] / map.CellSize;
            int dx = (loc[0] + size[0]) / map.CellSize;
            int dy = (loc[1] + size[1]) / map.CellSize;
            
            for(int i = 0; i < dx - x;i++)
            {
                for (int j = 0; j < dy - y; j++)
                    res.Add(new int[] { x + i, y + j });
            }
            return res;
        }

        public void Initialize()
        {
            //TODO: здесь будем загружать все дела и создавать объекты
        }
    }
}
