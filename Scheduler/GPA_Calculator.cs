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
        double TheorytotalPossible, LabstotalPossible;
        double[] totals = { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 };
        double[] Theory = { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 };
        double[] Labs = { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 };

        string letterGrade;
        string GPA;
        double[,] grid =
            {
                { 0,0,0,0,0,0,0,0,0,0,0 }, //Weight
                { 0,0,0,0,0,0,0,0,0,0,0 }, //Grade
            };
        public GPA_Calculator()
        {
            InitializeComponent();
            gBox2.Enabled = true; gBox_En2.Enabled = true; gBox2.Hide(); gBox_En2.Hide(); gBox3.Enabled = true; gBox_En3.Enabled = true; gBox3.Hide(); gBox_En3.Hide(); gBox4.Enabled = true; gBox_En4.Enabled = true; gBox4.Hide(); gBox_En4.Hide();gBox5.Enabled = true; gBox_En5.Enabled = true; gBox5.Hide(); gBox_En5.Hide();
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
            gBox2.Enabled = true; gBox_En2.Enabled = true; gBox2.Hide(); gBox_En2.Hide();
            gBox3.Enabled = true; gBox_En3.Enabled = true; gBox3.Hide(); gBox_En3.Hide();
            gBox4.Enabled = true; gBox_En4.Enabled = true; gBox4.Hide(); gBox_En4.Hide();
            gBox5.Enabled = true; gBox_En5.Enabled = true; gBox5.Hide(); gBox_En5.Hide();
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
            gBox2.Show(); gBox_En2.Show(); gBox3.Show(); gBox3.Show(); gBox_En3.Show(); gBox4.Show(); gBox_En4.Show(); gBox5.Show(); gBox_En5.Show();
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
            gBox3.Enabled = false;
        }

        private void rbtn_En4_CheckedChanged(object sender, EventArgs e)
        {
            gBox4.Enabled = true;
        }

        private void rbtn_Disabled4_CheckedChanged(object sender, EventArgs e)
        {
            gBox4.Enabled = false;
        }

        private void btn_g1Calculate_Click(object sender, EventArgs e)
        {
    
            totals[0] = 0;
            Theory[0] = 0;
            Labs[0] = 0;
            TheorytotalPossible = 0;
            LabstotalPossible = 0;

            for (int i = 0; i < 12; i++)
            {
                string weightTextBoxName = "txt_Weight" + i + "B1";
                string gradeTextBoxName = "txtGrade" + i + "B1";

                TextBox? weightTextBox = this.Controls.Find(weightTextBoxName, true).FirstOrDefault() as TextBox;
                TextBox? gradeTextBox = this.Controls.Find(gradeTextBoxName, true).FirstOrDefault() as TextBox;

                if (weightTextBox != null && gradeTextBox != null)
                {
                    double weight = 0;
                    double grade = 0;

                    if (double.TryParse(weightTextBox.Text, out weight) && double.TryParse(gradeTextBox.Text, out grade))
                    {
                        grid[0, i] = weight;
                        grid[1, i] = grade;

                        if (weight < 0.0 || grade < 0.0)
                        {
                            MessageBox.Show("You cannot have a negative weight or grade.");
                            gradeTextBox.Clear();
                            weightTextBox.Clear();
                            lblResult1.Text = "";
                            return;
                        }

                        weight /= 100.0;  
                        double current = weight * grade;
                        double tempWeight = 100 * weight;

                        if (i < 8)  
                        {
                            TheorytotalPossible += tempWeight;
                            Theory[0] += current;
                        }
                        else
                        {
                            LabstotalPossible += tempWeight;
                            Labs[0] += current;
                        }
                    }
                }
            }

            totals[0] = Theory[0] + Labs[0];

            if (totals[0] >= 0.0 && totals[0] <= 100.0)
            {
                lblResult1.Text = totals[0].ToString("F2");

                lblTheory1.Text = (TheorytotalPossible == 0) ? "N/A" : ((Theory[0] / TheorytotalPossible) * 100).ToString("F2");
                lblLab1.Text = (LabstotalPossible == 0) ? "N/A" : ((Labs[0] / LabstotalPossible) * 100).ToString("F2");
            }
            else
            {
                lblResult1.Text = lblTheory1.Text = lblLab1.Text = "";
            }

            if (totals[0] > 100.0)
            {
                MessageBox.Show("Your total grade is above 100%.");
            }
            else if (totals[0] < 0.0)
            {
                MessageBox.Show("Your grade is negative.");
                lblResult1.Text = "";
            }

            // Letter grade & GPA
            if ((TheorytotalPossible == 0 || (Theory[0] / TheorytotalPossible) >= 0.5) &&
                (LabstotalPossible == 0 || (Labs[0] / LabstotalPossible) >= 0.5))
            {
                if (totals[0] < 50.0) { letterGrade = "F"; GPA = "0.00"; }
                else if (totals[0] < 54.0) { letterGrade = "D"; GPA = "1.00"; }
                else if (totals[0] < 59.0) { letterGrade = "D+"; GPA = "1.33"; }
                else if (totals[0] < 62.0) { letterGrade = "C-"; GPA = "1.67"; }
                else if (totals[0] < 66.0) { letterGrade = "C"; GPA = "2.00"; }
                else if (totals[0] < 69.0) { letterGrade = "C+"; GPA = "2.33"; }
                else if (totals[0] < 72.0) { letterGrade = "B-"; GPA = "2.67"; }
                else if (totals[0] < 76.0) { letterGrade = "B"; GPA = "3.00"; }
                else if (totals[0] < 79.0) { letterGrade = "B+"; GPA = "3.33"; }
                else if (totals[0] < 84.0) { letterGrade = "A-"; GPA = "3.67"; }
                else if (totals[0] < 89.0) { letterGrade = "A"; GPA = "4.00"; }
                else { letterGrade = "A+"; GPA = "4.33"; } 
            }
            else
            {
                letterGrade = "F";
                GPA = "0.00";
            }

            // letter grade & GPA
            if (totals[0] >= 0.0 && totals[0] <= 100.0)
            {
                lblLetterGrade1.Text = letterGrade;
                lblGPA1.Text = GPA;
            }
            else
            {
                lblLetterGrade1.Text = "";
                lblGPA1.Text = "";
            }
        }
        private void btn_g2Calculate_Click(object sender, EventArgs e)
        {

        }
        private void btn_g3Calculate_Click(object sender, EventArgs e)
        {

        }
        private void btn_g4Calculate_Click(object sender, EventArgs e)
        {

        }
        private void btn_g5Calculate_Click(object sender, EventArgs e)
        {

        }
        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void lbl_Weight_Click(object sender, EventArgs e)
        {

        }

        private void txt_Weight7B1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
