using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Objects;
using Game.FormContext;
using System.Windows.Forms;

namespace Game.Strategy
{
    class KeyboardStrategy : IStrategy
    {
        private IFormContext context = null;
        private GameController game = null;
        private Character character = null;

        public KeyboardStrategy(IFormContext context, GameController game, Character character)
        {
            this.context = context;
            this.context.Handler = new KeyEventHandler(OnKeyPress);
            this.game = game;
            this.character = character;
        }

        private void OnKeyPress(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.W:
                    break;
                case Keys.A:
                    break;
                case Keys.S:
                    break;
                case Keys.D:
                    break;
            }
        }

        public void Update()
        {

        }
    }
}
