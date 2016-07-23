﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Graphics
{
    class Animation
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Animation() { }
        public Animation(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
