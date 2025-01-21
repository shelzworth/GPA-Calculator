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
        double total = 0;
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
            gBox2.Enabled = true; gBox_En2.Enabled = true; gBox2.Hide(); gBox_En2.Hide(); gBox3.Hide(); gBox_En3.Hide(); gBox4.Hide(); gBox_En4.Hide();
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
            gBox2.Show(); gBox_En2.Show(); gBox3.Show(); gBox3.Show(); gBox_En3.Show(); gBox4.Show(); gBox_En4.Show();
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
            total = 0;
            for (int i = 0; i < 8; i++)
            {
                string weightTextBoxName = "txt_Weight" + i + "B1";
                string gradeTextBoxName = "txtGrade" + i + "B1";

                TextBox? weightTextBox = this.Controls.Find(weightTextBoxName, true).FirstOrDefault() as TextBox;
                TextBox? gradeTextBox = this.Controls.Find(gradeTextBoxName, true).FirstOrDefault() as TextBox;

                if ((weightTextBox != null && gradeTextBox != null))
                {
                    double weight = 0;
                    double grade = 0;

                    if (double.TryParse(weightTextBox.Text, out weight) && double.TryParse(gradeTextBox.Text, out grade))
                    {
                        grid[0, i] = weight;
                        grid[1, i] = grade;

                        if(weight < 0.0 || grade < 0.0)
                        {
                            MessageBox.Show("You can not have a negative weight or grade.");
                            gradeTextBox.Clear(); weightTextBox.Clear(); lblResult1.Text = "";
                        }

                        weight = weight / 100.0;
                        double current = weight * grade;

                        total += current;

                        if(total > 100.0)
                        {
                            MessageBox.Show("Your total grade is above 100%.");
                        }
                        else if (total < 0.0)
                        {
                            MessageBox.Show("Your grade is negative.");
                            lblResult1.Text = "";
                        }
                        else
                        {
                           if (0 < total && total > 50.0)
                           {
                              letterGrade = "F";
                                GPA = "0.00";
                            }
                           else if (50.0 <= total && total < 54.0)
                           {
                              letterGrade = "D";
                                GPA = "1.00";
                            }
                           else if (54.0 < total && total < 59.0)
                           {
                               letterGrade = "D+";
                                GPA = "1.33";
                            }
                           else if (59.0 < total && total < 62.0)
                           {
                               letterGrade = "C-";
                                GPA = "1.67";
                            }
                           else if (62.0 < total && total < 66.0)
                           {
                               letterGrade = "C";
                                GPA = "2.00";
                            }
                           else if (66.0 < total && total < 69.0)
                           {
                               letterGrade = "C+";
                                GPA = "2.33";
                            }
                           else if (69.0 < total && total < 72.0)
                           {
                               letterGrade = "B-";
                                GPA = "2.67";
                            }
                           else if (72.0 < total && total < 76.0)
                           {
                               letterGrade = "B";
                                GPA = "3.00";
                            }
                           else if (76.0 < total && total < 79.0)
                           {
                               letterGrade = "B+";
                                GPA = "3.33";
                            }
                           else if (79.0 < total && total < 84.0)
                           {
                               letterGrade = "A-";
                                GPA = "3.67";
                           }
                           else if (84.0 < total && total < 89.0)
                           {
                               letterGrade = "A";
                                GPA = "4.00";
                            }
                            else if (89.0 < total && total == 100.0)
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
            if(total <= 100.0 && total >= 0.0)
            {
                lblResult1.Text = total.ToString("F2");
            }
            else
            {
                lblResult1.Text = "";
            }
            lblLetterGrade1.Text = letterGrade;
            lblGPA1.Text = GPA;
        }
        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}
