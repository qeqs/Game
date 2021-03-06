﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Graphics;

namespace Game
{
    class Map
    {
        private int cellSize;
        private Sprite[,] matrix;
        public Map()
        {
            //TODO: создание готовой карты
        }
        public Map(string path)
        {
            //TODO: загрузка из файла готовой карты
        }
        public int CellSize { get { return cellSize; }}
        public int LengthX { get { return matrix.GetLength(0); } }
        public int LengthY { get { return matrix.GetLength(1); } }
        public Sprite this [int x,int y]
        {
            get {
                if (x < LengthX && y < LengthY)
                    return matrix[x, y];
                else
                {
                    throw new IndexOutOfRangeException("in map with coords: " + x + " " + y);
                }
            }
        }
        public Point2 GetLocationByIndex(int i,int j)
        {
            return new Point2(i * CellSize, j * CellSize);
        }
    }
}
