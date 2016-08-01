using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Objects.Skills;

namespace Game.Objects.Characters
{
    abstract class AbstractCharacter
    {
        public abstract List<Spell> CreateSpells();
        public abstract Weapon CreateWeapon();
    }
}
