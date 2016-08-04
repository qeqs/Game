using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game.FormContext
{
   public class FormMainContext : IFormContext
    {
        KeyEventHandler keysHandler;
        KeyEventHandler keysUpHandler;
        MouseEventHandler mouseDownHandler;
        MouseEventHandler mouseUpHandler;

        public FormMain CurForm { get; set; }
        public KeyEventHandler KeysDownHandler
        {
            get
            {
                return keysHandler;
            }
            set
            {
                keysHandler = value;
                CurForm.KeyDown += KeysDownHandler;
            }
        }

        public MouseEventHandler MouseDownHandler
        {
            get
            {
                return mouseDownHandler;
            }

            set
            {
                mouseDownHandler = value;
                CurForm.MouseDown += MouseDownHandler;
            }
        }

        public KeyEventHandler KeysUpHandler
        {
            get
            {
                return keysUpHandler;
            }
            set
            {
                keysUpHandler = value;
                CurForm.KeyUp += KeysUpHandler;
            }
        }
        public MouseEventHandler MouseUpHandler
        {
            get
            {
                return mouseUpHandler;
            }

            set
            {
                mouseUpHandler = value;
                CurForm.MouseUp += MouseUpHandler;
            }
        }

        public FormMainContext(FormMain form)
        {
            CurForm = form;
        }
    }
}
