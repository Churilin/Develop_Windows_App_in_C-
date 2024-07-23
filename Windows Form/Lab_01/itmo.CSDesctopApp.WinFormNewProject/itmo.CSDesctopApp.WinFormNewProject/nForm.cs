using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace itmo.CSDesctopApp.WinFormNewProject
{
    public partial class nForm : Form
    {
        private void nForm_FormClosing (object sender, FormClosingEventArgs e)
        {
            if (checkBoxClose.Checked) return;
            e.Cancel = true;
            Hide();
        }
        public nForm()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
