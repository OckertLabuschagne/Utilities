using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEFI
{
    public class DialogResultEventArg : EventArgs
    {

        public DialogResultEventArg() { }
        public DialogResultEventArg(DialogResult dialogResult)
        {
            DialogResult = dialogResult;
        }
        public DialogResult DialogResult { get; set; }
    }

    public delegate void DialogResultEvemtHandler(object sender, DialogResultEventArg e);
}
