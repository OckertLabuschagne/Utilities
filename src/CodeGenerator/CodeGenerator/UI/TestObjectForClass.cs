using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
namespace CodeGenerator.UI
{
    public partial class TestObjectForClass : Form
    {
        public TestObjectForClass()
        {
            InitializeComponent();
        }

        public string ConnectionString { get; set; }

        private void tsbtnSelectAssembly_Click(object sender, EventArgs e)
        {
            lbxTypes.Items.Clear();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
                Assembly assembly = provider.CompileAssemblyFromSource(new CompilerParameters(new string[] { "FI.Source" }), openFileDialog1.FileName).CompiledAssembly;
                tsslblAssembly.Text = assembly.FullName;
                if (assembly != null)
                {
                    Type[] types = assembly.GetTypes();
                    lbxTypes.Items.AddRange(types);
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void tscmbxMappingClass_Click(object sender, EventArgs e)
        {

        }

        private void tsbtnConnect_Click(object sender, EventArgs e)
        {

        }

        private void tsbtnExecute_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void tscmbxInterface_Click(object sender, EventArgs e)
        {

        }

        private void rbtnFormDb_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tscmbxCode_Click(object sender, EventArgs e)
        {

        }
    }
}
