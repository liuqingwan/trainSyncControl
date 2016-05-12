using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace trainLSPU
{
    public partial class Form1 : Form
    {
        UserControl mainwin;
        UserControl followwin;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainwin = new mainWin();
            mainwin.Show();
            winBox.Controls.Clear();
            winBox.Controls.Add(mainwin);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            followwin = new followWin();
            followwin.Show();
            winBox.Controls.Clear();
            winBox.Controls.Add(followwin);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            winBox.Controls.Clear();
        }
    }
}
