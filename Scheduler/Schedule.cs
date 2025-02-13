using GPA_Calculator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms;
using Scheduler;

namespace GPA_Calculator
{
    public partial class Schedule : Form
    {
        public Schedule()
        {
            InitializeComponent();
            gBoxY1.Show(); gBoxY2.Show(); gBoxY3.Show(); gBoxY4.Show();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void btn_Calculator_Click(object sender, EventArgs e)
        {
            Calculator Calculator = new Calculator();
            this.Hide();
            Calculator.Show();
        }
    }
}
