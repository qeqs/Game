using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Graphics;

namespace Game.Objects.Skills
{
    abstract class Spell
    {
        public Animation Animation { get; private set; }
        public abstract void SpellIt();
    }
}
