using GPA_Calculator;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Scheduler;

namespace GPA_Calculator
{
    public partial class Schedule : Form
    {
        private Calculator _calculator;
        private double[] GPAtotals;
        int sem = 1; 

        public Schedule(Calculator calculator)
        {
            InitializeComponent();
            _calculator = calculator;
            gBoxY1.Show(); gBoxY2.Show(); gBoxY3.Show(); gBoxY4.Show();

            if (GPAtotals != null)
            {
                LoadTotals(GPAtotals);
            }
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
            for (int subject = 1; subject <= GPAtotals.Length; subject++)
            {
                ComboBox? current = this.Controls.Find("CBox" + subject + "S" + sem, true)
                                              .FirstOrDefault() as ComboBox;
                if (current != null)
                {
                    if (string.IsNullOrWhiteSpace(current.Text))
                    {
                        double computedGPA;
                        double currentTotal = GPAtotals[subject - 1];

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
        }
        private void btnSaveSem_Click(object sender, EventArgs e)
        {
            bool allFilled = true;
            for (int subject = 1; subject <= 5; subject++)
            {
                ComboBox? current = this.Controls.Find("CBox" + subject + "S" + sem, true)
                                                 .FirstOrDefault() as ComboBox;
                if (current == null || string.IsNullOrWhiteSpace(current.Text))
                {
                    allFilled = false;
                    break;
                }
            }

            if (allFilled)
            {
                // Compute the cumulative GPA across *all* semesters up to 'sem'.
                double cgpa = Calculatecgpa(sem);
                _calculator.cgpaText(cgpa);
                LblCGPA.Text = cgpa.ToString("F2");
                sem++;

                // The rest of your existing logic...
                if (sem == 9)
                {
                    btnSaveSem.Enabled = false;
                }
                else
                {
                    lblSuccess.Visible = true;
                    btnSaveSem.BackColor = Color.Gray;
                    btnSaveSem.Enabled = false;
                    System.Windows.Forms.Timer hideLabelTimer = new System.Windows.Forms.Timer();
                    hideLabelTimer.Interval = 1200;
                    hideLabelTimer.Tick += (s, eArgs) =>
                    {
                        lblSuccess.Visible = false;
                        btnSaveSem.Enabled = true;
                        btnSaveSem.BackColor = Color.Lime;
                        hideLabelTimer.Stop();
                        hideLabelTimer.Dispose();
                    };
                    hideLabelTimer.Start();
                }
            }
            else
            {
                MessageBox.Show("Please fill in all combo boxes for semester " + sem + " before saving.");
            }
        }
        private double Calculatecgpa(int currentSemester)
        {
            double total = 0;
            int filledCount = 0;

            // Loop over *all* semesters from 1 to the current one.
            for (int s = 1; s <= currentSemester; s++)
            {
                // Each semester has 5 subjects
                for (int subject = 1; subject <= 5; subject++)
                {
                    // Example naming: "CBox1S1", "CBox2S1", ... "CBox5S4"
                    ComboBox? current = this.Controls.Find("CBox" + subject + "S" + s, true)
                                                     .FirstOrDefault() as ComboBox;

                    if (current != null && double.TryParse(current.Text, out double value))
                    {
                        total += value;
                        filledCount++;
                    }
                }
            }

            // Avoid division by zero if no boxes are filled
            return (filledCount > 0) ? (total / filledCount) : 0;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearAllComboBoxes(this);
            LblCGPA.Text = "_____";
            sem = 1;
        }

        private void ClearAllComboBoxes(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is ComboBox combo)
                {
                    combo.SelectedIndex = -1;
                }
                else if (ctrl.HasChildren)
                {
                    ClearAllComboBoxes(ctrl);
                }
            }
        }
    }
}
