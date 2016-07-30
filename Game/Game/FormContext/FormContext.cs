using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game.FormContext
{
    class FormContext : IFormContext
    {
        KeyEventHandler handler;
        public FormMain CurForm { get; set; }
        public KeyEventHandler Handler
        {
            get
            {
                return handler;
            }
            set
            {
                handler = value;
                CurForm.KeyDown += Handler;
            }
        }

        public FormContext(FormMain form)
        {
            CurForm = form;
        }
    }
}
