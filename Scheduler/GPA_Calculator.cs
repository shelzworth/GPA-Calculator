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

        double total1 = 0, total2 = 0, total3 = 0, total4 = 0, total5 = 0;
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
            gBox2.Hide(); gBox_En2.Hide(); gBox3.Hide(); gBox_En3.Hide(); gBox4.Hide(); gBox_En4.Hide();
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
            for (int n = 0; n < 5; n++)
            {

                for (int i = 0; i < 8; i++)
                {
                    string weightTextBoxName = "txt_Weight" + i + "B" + n;
                    string gradeTextBoxName = "txtGrade" + i + "B" + n;
                    string resultBoxName = "lblResult" + n;
                    string gradeBoxName = "lblLetterGrade" + n;
                    string gpaBoxName = "lblGPA" + n;

                    TextBox? weightTextBox = this.Controls.Find(weightTextBoxName, true).FirstOrDefault() as TextBox;
                    TextBox? gradeTextBox = this.Controls.Find(gradeTextBoxName, true).FirstOrDefault() as TextBox;

                    Label? resultLabel = this.Controls.Find(resultBoxName, true).FirstOrDefault() as Label;
                    Label? gradeLabel = this.Controls.Find(gradeBoxName, true).FirstOrDefault() as Label;
                    Label? gpaLabel = this.Controls.Find(gpaBoxName, true).FirstOrDefault() as Label;



                    if ((weightTextBox != null && gradeTextBox != null))
                    {
                        double weight = 0;
                        double grade = 0;

                        if (double.TryParse(weightTextBox.Text, out weight) && double.TryParse(gradeTextBox.Text, out grade))
                        {
                            grid[0, i] = weight;
                            grid[1, i] = grade;

                            if (weight < 0.0 || grade < 0.0)
                            {
                                MessageBox.Show("You can not have a negative weight or grade.");
                                gradeTextBox.Clear(); weightTextBox.Clear(); lblResult1.Text = "";
                            }

                            weight = weight / 100.0;
                            double current = weight * grade;

                            total1 += current;

                            if (total1 > 100.0)
                            {
                                MessageBox.Show("Your total grade is above 100%.");
                            }
                            else if (total1 < 0.0)
                            {
                                MessageBox.Show("Your grade is negative.");
                                lblResult1.Text = "";
                            }
                            else
                            {
                                if (0 <= total1 && total1 < 50.0)
                                {
                                    letterGrade = "F";
                                    GPA = "0.00";
                                }
                                else if (50.0 <= total1 && total1 < 54.0)
                                {
                                    letterGrade = "D";
                                    GPA = "1.00";
                                }
                                else if (54.0 < total1 && total1 < 59.0)
                                {
                                    letterGrade = "D+";
                                    GPA = "1.33";
                                }
                                else if (59.0 < total1 && total1 < 62.0)
                                {
                                    letterGrade = "C-";
                                    GPA = "1.67";
                                }
                                else if (62.0 < total1 && total1 < 66.0)
                                {
                                    letterGrade = "C";
                                    GPA = "2.00";
                                }
                                else if (66.0 < total1 && total1 < 69.0)
                                {
                                    letterGrade = "C+";
                                    GPA = "2.33";
                                }
                                else if (69.0 < total1 && total1 < 72.0)
                                {
                                    letterGrade = "B-";
                                    GPA = "2.67";
                                }
                                else if (72.0 < total1 && total1 < 76.0)
                                {
                                    letterGrade = "B";
                                    GPA = "3.00";
                                }
                                else if (76.0 < total1 && total1 < 79.0)
                                {
                                    letterGrade = "B+";
                                    GPA = "3.33";
                                }
                                else if (79.0 < total1 && total1 < 84.0)
                                {
                                    letterGrade = "A-";
                                    GPA = "3.67";
                                }
                                else if (84.0 < total1 && total1 < 89.0)
                                {
                                    letterGrade = "A";
                                    GPA = "4.00";
                                }
                                else if (89.0 < total1 && total1 == 100.0)
                                {
                                    letterGrade = "A+";
                                    GPA = "4.33";
                                }
                            }
                        }
                        else
                        {

                        }
                    }
                }
                //total1 --> variable
                if (total1 <= 100.0 && total1 >= 0.0)
                {
                    lblResult1.Text = total1.ToString("F2");
                    lblLetterGrade1.Text = letterGrade;
                    lblGPA1.Text = GPA;
                }
                else
                {
                 //figure this out
                    lblResult1.Text = "";
                    lblGPA1.Text = "";
                    lblLetterGrade1.Text = "";
                }
            }
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
