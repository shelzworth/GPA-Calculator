using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduler
{
    public partial class GPA_Calculator : Form
    {
        public GPA_Calculator()
        {
            InitializeComponent();
            gBox2.Hide();
            gBox_En2.Hide();
            gBox3.Hide();
            gBox_En3.Hide();
        }

        private void rbtn_En_CheckedChanged(object sender, EventArgs e)
        {
            gBox1.Enabled = true;
        }

        private void rbtn_Disabled_CheckedChanged(object sender, EventArgs e)
        {
            gBox1.Enabled = false;
        }

        private void rbtn_Single_CheckedChanged(object sender, EventArgs e)
        {
            gBox2.Enabled = true;
            gBox_En2.Enabled = true;
            gBox2.Hide();
            gBox_En2.Hide();
            gBox3.Hide();
            gBox_En3.Hide();
        }

        private void rbtn_En2_CheckedChanged(object sender, EventArgs e)
        {
            gBox2.Enabled = true;
        }

        private void rbtn_Disabled2_CheckedChanged(object sender, EventArgs e)
        {
            gBox2.Enabled = false;
        }

        private void rBtn_Multi_CheckedChanged(object sender, EventArgs e)
        {
            gBox2.Show();
            gBox_En2.Show();
            gBox3.Show();
            gBox_En3.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void rbtn_En3_CheckedChanged(object sender, EventArgs e)
        {
            gBox3.Enabled = true;
        }

        private void rbtn_Disabled3_CheckedChanged(object sender, EventArgs e)
        {
            gBox3.Enabled=false;
        }
    }
}
