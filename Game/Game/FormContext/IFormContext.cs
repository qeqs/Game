using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game.FormContext
{
    public interface IFormContext
    {
        KeyEventHandler KeysDownHandler { get; set; }
        KeyEventHandler KeysUpHandler { get; set; }
        MouseEventHandler MouseDownHandler { get; set; }
        MouseEventHandler MouseUpHandler { get; set; }
    }
}
