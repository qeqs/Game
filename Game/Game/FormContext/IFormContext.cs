using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game.FormContext
{
    interface IFormContext
    {
        KeyEventHandler Handler { get; set; }
    }
}
