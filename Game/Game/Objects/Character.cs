using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Objects.Skills;
using Game.Objects.Characters;
using Game.Graphics;
using Game.Strategy;

namespace Game.Objects
{
    class Character : IObject
    {
        private List<Spell> _spells;
        private Weapon _weapon;
        private Body _body;
        private IStrategy strategy;

        #region attributes
        int agility;
        int strength;
        int intelegence;
        int luck;

        int currentMana;
        int maxMana;

        int currentHealth;//if == 0 then state = dead
        int maxHealth;

        int regenHp;
        int regenMp;

        double speed;

        int level;//max exp = level*100
        int experience;//if level*100<=exp then exp = 0 and level++

        int minDamage;
        int maxDamage;


        //TODO: дописать свойства (додумать свойства)
        #region attr props
        public int Agility
        {
            get
            {
                return agility;
            }

            set
            {
                agility = value;
                Speed = value * 2;
            }
        }

        public int Strength
        {
            get
            {
                return strength;
            }

            set
            {
                strength = value;
                MaxHealth = value * 100;
            }
        }

        public int Intelegence
        {
            get
            {
                return intelegence;
            }

            set
            {
                intelegence = value;
                Mana = value * 100;
            }
        }

        public int Luck
        {
            get
            {
                return luck;
            }

            set
            {
                luck = value;
            }
        }

        public int Mana
        {
            get
            {
                return currentMana;
            }

            set
            {
                currentMana = value;
            }
        }

        public int Health
        {
            get
            {
                return currentHealth;
            }

            set
            {
                currentHealth = value;
            }
        }
        public int MaxHealth
        {
            get
            {
                return maxHealth;
            }

            set
            {
                maxHealth = value;
            }
        }
        public double Speed
        {
            get
            {
                return speed;
            }

            set
            {
                speed = value;
            }
        }

        public int Level
        {
            get
            {
                return level;
            }

            set
            {
                level = value;
            }
        }

        public int Experience
        {
            get
            {
                return experience;
            }

            set
            {
                experience = value;
            }
        }

        public int Damage
        {
            get
            {
                return Rand.GetNext(minDamage,maxDamage);
            }
        }

        public void SetDamage(int min, int max)
        {
            minDamage = min;
            maxDamage = max;
        }

        public int MaxMana
        {
            get
            {
                return maxMana;
            }

            set
            {
                maxMana = value;
            }
        }

        public int RegenHp
        {
            get
            {
                return regenHp;
            }

            set
            {
                regenHp = value;
            }
        }

        public int RegenMp
        {
            get
            {
                return regenMp;
            }

            set
            {
                regenMp = value;
            }
        }

        #endregion
        #endregion
        #region static methods
        //Хотел что-то важное тут написать, отвелкся и забыл :(
        #endregion

        public Animation[] AnimationArray
        {
            get
            {
                return new Animation[]
                {

                };
            }
        }

        public IStrategy Strategy
        {
            get
            {
                return strategy;
            }

            set
            {
                strategy = value;
            }
        }

   
        public Character(AbstractCharacter character)
        {
            
            _spells = character.CreateSpells();
            _weapon = character.CreateWeapon();
        }

        public void CastSpell(int spell)
        {
            _spells[spell].Cast();
        }

        public void Hit()
        {
            _weapon.Hit();
        }

        public void Update()
        {
            strategy.Update();
        }
    }
}
