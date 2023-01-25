using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APITester.Dialog.Controls
{
    public partial class CustomSortListbox : ListBox
    {
        public CustomSortListbox()
            : base()
        {
        }

        [Category("Behavior")]
        public SortOrder SortOrder { get; set; }

        protected override void Sort()
        {
            if (this.Items.Count > 1)
            {
                bool swapped;
                do
                {

                    int counter = this.Items.Count - 1;
                    swapped = false;

                    while (counter > 0)
                    {
                        if (this.Items[counter].ToString().CompareTo(
                            this.Items[counter - 1].ToString()) == (SortOrder == SortOrder.Ascending ? - 1 : 1))
                        {
                            object temp = Items[counter];
                            this.Items[counter] = this.Items[counter - 1];
                            this.Items[counter - 1] = temp;
                            swapped = true;
                        }

                        counter -= 1;

                    }

                }
                while (swapped);
            }
        }
    }
}
