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
    class Warrior : AbstractCharacter
    {
        public override List<Spell> CreateSpells()
        {
            return new List<Spell>() { new LegendaryHit() };
        }

        public override Weapon CreateWeapon()
        {
            return new Sword();
        }
    }
}
