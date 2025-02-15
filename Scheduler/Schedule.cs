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
        private Calculator _calculator;

        private double[] GPAtotals;
        double GPA;
        int n = 1, sem = 1;
        public Schedule(Calculator calculator)
        {
            InitializeComponent();
            _calculator = calculator;
            gBoxY1.Show(); gBoxY2.Show(); gBoxY3.Show(); gBoxY4.Show();

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void btn_Calculator_Click(object sender, EventArgs e)
        {
            if (_calculator == null || _calculator.IsDisposed)
            {
                _calculator = new Calculator();
            }
            this.Hide();
            _calculator.Show();
        }

        public void LoadTotals(double[] totals)
        {
            GPAtotals = totals;
            for (int n = 1; n <= GPAtotals.Length; n++)
            {
                ComboBox? current = this.Controls.Find("CBox" + n + "S" + sem, true)
                                              .FirstOrDefault() as ComboBox;
                if (current != null)
                {
                    double computedGPA;
                    double currentTotal = GPAtotals[n - 1];

                    if (currentTotal < 49.5) computedGPA = 0.00;
                    else if (currentTotal < 52.5) computedGPA = 0.67;
                    else if (currentTotal < 56.5) computedGPA = 1.00;
                    else if (currentTotal < 59.5) computedGPA = 1.33;
                    else if (currentTotal < 62.5) computedGPA = 1.67;
                    else if (currentTotal < 66.5) computedGPA = 2.00;
                    else if (currentTotal < 69.5) computedGPA = 2.33;
                    else if (currentTotal < 72.5) computedGPA = 2.67;
                    else if (currentTotal < 76.5) computedGPA = 3.00;
                    else if (currentTotal < 79.5) computedGPA = 3.33;
                    else if (currentTotal < 84.5) computedGPA = 3.67;
                    else if (currentTotal < 89.5) computedGPA = 4.00;
                    else computedGPA = 4.33;

                    current.Text = computedGPA.ToString("F2");
                }
            }
        }

        private void btnSaveSem_Click(object sender, EventArgs e)
        {
            sem++;
            if (sem == 9) btnSaveSem.Enabled = false;

            lblSuccess.Visible = true;
            System.Windows.Forms.Timer hideLabelTimer = new System.Windows.Forms.Timer();
            hideLabelTimer.Interval = 1200; 
            hideLabelTimer.Tick += (s, e) =>
            {
                lblSuccess.Visible = false;
                hideLabelTimer.Stop(); 
                hideLabelTimer.Dispose();
            };
            hideLabelTimer.Start();
        }
    }
}
