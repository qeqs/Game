using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Objects.Skills;
using Game.Objects.Characters;
using Game.Graphics;

namespace Game.Objects
{
    class Character : IObject
    {
        private Spell _spell;
        private Weapon _weapon;
        private Body _body;

        public Animation[] AnimationArray
        {
            get
            {
                return new Animation[]
                {
                    _spell.Animation,
                    _weapon.Animation,
                    _body.Animation
                };
            }
        }
        public int Health { get; set; }

        public Character(AbstractCharacter character)
        {
            _spell = character.CreateSpell();
            _weapon = character.CreateWeapon();
        }

        public void SpellIt()
        {
            _spell.SpellIt();
        }

        public void Hit()
        {
            _weapon.Hit();
        }
    }
}
