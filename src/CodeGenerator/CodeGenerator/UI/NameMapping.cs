using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeGenerator.UI
{
    public partial class NameMapping : Form
    {
        public NameMapping()
        {
            InitializeComponent();
        }

        Dictionary<string, string> _Mappings;

        public Dictionary<string, string> Mappings { set => FillGrid(value); get => GetMapping(); }

        private void FillGrid(Dictionary<string, string> value)
        {
            _Mappings = value;
            dataGridView1.Rows.Clear();
            foreach (string key in value.Keys)
                dataGridView1.Rows.Add(key, value[key]);
        }

        private Dictionary<string, string> GetMapping()
        {
            _Mappings.Clear();

            foreach (DataGridViewRow row in dataGridView1.Rows)
                if (row.Cells[0].Value != null)
                    _Mappings.Add(row.Cells[0].Value as string, row.Cells[1].Value as string);
            return _Mappings;
        }
    }
}
