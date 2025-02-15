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
        private double[] GPAtotals;
        double GPA;
        int n = 1, year = 1;
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

        private void Schedule_Load(object sender, EventArgs e)
        {

        }
        private void Load(double[] GPA)
        {

        }

        public void LoadTotals(double[] totals)
        {
            GPAtotals = totals;
            for (int n = 1; n <= 5; n++)
            {
                ComboBox? current = this.Controls.Find("CBox" + n + "Y" + year, true).FirstOrDefault() as ComboBox;
                if (current != null)
                {

                    for (int i = 0; i < GPAtotals.Length; i++)
                    {
                        double computedGPA = 0.0;
                        if (GPAtotals[i] < 49.5) { computedGPA = 0.00; }
                        else if (GPAtotals[i] < 52.5) { computedGPA = 0.67; }
                        else if (GPAtotals[i] < 56.5) { computedGPA = 1.00; }
                        else if (GPAtotals[i] < 59.5) { computedGPA = 1.33; }
                        else if (GPAtotals[i] < 62.5) { computedGPA = 1.67; }
                        else if (GPAtotals[i] < 66.5) { computedGPA = 2.00; }
                        else if (GPAtotals[i] < 69.5) { computedGPA = 2.33; }
                        else if (GPAtotals[i] < 72.5) { computedGPA = 2.67; }
                        else if (GPAtotals[i] < 76.5) { computedGPA = 3.00; }
                        else if (GPAtotals[i] < 79.5) { computedGPA = 3.33; }
                        else if (GPAtotals[i] < 84.5) { computedGPA = 3.67; }
                        else if (GPAtotals[i] < 89.5) { computedGPA = 4.00; }
                        else { computedGPA = 4.33; }

                        current.Text = computedGPA.ToString("F2");
                    }
                }
            }
        }
    }
}
