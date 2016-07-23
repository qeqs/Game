using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Objects.Skills;

namespace Game.Objects.Characters
{
    class Warrior : AbstractCharacter
    {
        public override Spell CreateSpell()
        {
            return null;
        }

        public override Weapon CreateWeapon()
        {
            return null;
        }
    }
}
