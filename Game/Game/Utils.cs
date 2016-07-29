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
        /// возвращает координаты, к которым следует идти
        /// </summary>
        /// <param name="from">текущее положение</param>
        /// <param name="where">положение цели</param>
        /// <returns>Координаты тайла</returns>
        public static int[] FindPath(int[] from, int[] where)
        {
            return null;
        }

        public static int[,] FloydWarshall(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            for (int k = 0; k < n; k++)
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        if ((matrix[i, k] * matrix[k, j] != 0) && (i != j))
                            if ((matrix[i, k] + matrix[k, j] < matrix[i, j]) || (matrix[i, j] == 0))
                                matrix[i, j] = matrix[i, k] + matrix[k, j];
            return matrix;
        }

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
