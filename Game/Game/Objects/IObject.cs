﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Graphics;

namespace Game.Objects
{
    interface IObject
    {
        Animation[] AnimationArray { get; }
        void Update();
    }
}
