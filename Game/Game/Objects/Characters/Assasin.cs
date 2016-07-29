using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Objects.Skills;
using Game.Objects.Skills.Weapons;
using Game.Objects.Skills.Spells;

namespace Game.Objects.Characters
{
    class Assasin : AbstractCharacter
    {
        public override Spell CreateSpell()
        {
            return new Invisible();
        }

        public override Weapon CreateWeapon()
        {
            return new Bow();
        }
    }
}
