using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeweySystemSystem
{
    public partial class Form4 : Form
    {
        public Form4(int points)
        {
            InitializeComponent();
            label1.Text = points.ToString()+"/10";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
