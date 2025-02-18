using System.Text;
using GPA_Calculator;

namespace Scheduler
{
    public partial class Calculator : Form
    {
        private Schedule scheduler;
        double TheorytotalPossible, LabstotalPossible, TGPA;
        double[] totals = { 0.0, 0.0, 0.0, 0.0, 0.0 };
        double[] Theory = { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 };
        double[] Labs = { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 };
        string[] CourseCodes = { "", "", "", "", "" };
        string letterGrade;
        string GPA;

        public Calculator()
        {
            InitializeComponent();
            rbtn_Disabled.Checked = false;
            rbtn_Disabled2.Checked = true;
            rbtn_Disabled3.Checked = true;
            rbtn_Disabled4.Checked = true;
            rbtn_Disabled5.Checked = true;
        }

        private bool IsControlEffectivelyEnabled(Control ctrl)
        {
            if (ctrl == null)
                return false;
            Control current = ctrl;
            while (current != null)
            {
                if (!current.Enabled)
                    return false;
                current = current.Parent;
            }
            return true;
        }

        private void rbtn_En_CheckedChanged(object sender, EventArgs e)
        {
            gBox1.Enabled = true; calculateTGPA();
        }

        private void rbtn_Disabled_CheckedChanged(object sender, EventArgs e)
        {
            gBox1.Enabled = false; calculateTGPA();
        }

        private void rbtn_Single_CheckedChanged(object sender, EventArgs e)
        {
            gBox2.Enabled = false; gBox_En2.Enabled = false;
            gBox3.Enabled = false; gBox_En3.Enabled = false;
            gBox4.Enabled = false; gBox_En4.Enabled = false;
            gBox5.Enabled = false; gBox_En5.Enabled = false;
            rbtn_Disabled2.Checked = true; rbtn_En2.Checked = true;
            rbtn_Disabled3.Checked = true; rbtn_En3.Checked = true;
            rbtn_Disabled4.Checked = true; rbtn_En4.Checked = true;
            rbtn_Disabled5.Checked = true; rbtn_En5.Checked = true;
            calculateTGPA();
        }

        private void rbtn_En2_CheckedChanged(object sender, EventArgs e)
        {
            gBox2.Enabled = true; calculateTGPA();
        }

        private void rbtn_Disabled2_CheckedChanged(object sender, EventArgs e)
        {
            gBox2.Enabled = false; calculateTGPA();
        }

        private void rBtn_Multi_CheckedChanged(object sender, EventArgs e)
        {
            gBox2.Enabled = true; gBox_En2.Enabled = true; rbtn_En2.Checked = true;
            gBox3.Enabled = true; gBox_En3.Enabled = true; rbtn_En3.Checked = true;
            gBox4.Enabled = true; gBox_En4.Enabled = true; rbtn_En4.Checked = true;
            gBox5.Enabled = true; gBox_En5.Enabled = true; rbtn_En5.Checked = true;
            calculateTGPA();
        }

        private void rbtn_En3_CheckedChanged(object sender, EventArgs e)
        {
            gBox3.Enabled = true; calculateTGPA();
        }

        private void rbtn_Disabled3_CheckedChanged(object sender, EventArgs e)
        {
            gBox3.Enabled = false; calculateTGPA();
        }

        private void rbtn_En4_CheckedChanged(object sender, EventArgs e)
        {
            gBox4.Enabled = true; calculateTGPA();
        }

        private void rbtn_Disabled4_CheckedChanged(object sender, EventArgs e)
        {
            gBox4.Enabled = false; calculateTGPA();
        }

        private void calculateCard(object sender, EventArgs e)
        {
            Button picked = (Button)sender;
            string buttonName = picked.Name;
            char index = buttonName[5];
            int n = index - '1';

            string resultBoxName = "lblResult" + (n + 1);
            string theoryBoxName = "lblTheory" + (n + 1);
            string labBoxName = "lblLab" + (n + 1);
            string letterGradeBoxName = "lblLetterGrade" + (n + 1);
            string GPABoxName = "lblGPA" + (n + 1);

            Label? resultBox = this.Controls.Find(resultBoxName, true).FirstOrDefault() as Label;
            Label? theoryBox = this.Controls.Find(theoryBoxName, true).FirstOrDefault() as Label;
            Label? labBox = this.Controls.Find(labBoxName, true).FirstOrDefault() as Label;
            Label? letterGradeBox = this.Controls.Find(letterGradeBoxName, true).FirstOrDefault() as Label;
            Label? GPABox = this.Controls.Find(GPABoxName, true).FirstOrDefault() as Label;

            totals[n] = 0;
            Theory[n] = 0;
            Labs[n] = 0;
            TheorytotalPossible = 0;
            LabstotalPossible = 0;

            for (int i = 0; i < 12; i++)
            {
                string weightTextBoxName = "txt_Weight" + i + "B" + (n + 1);
                string gradeTextBoxName = "txtGrade" + i + "B" + (n + 1);
                string courseCodeName = "txt_CourseCodeB" + (n + 1);

                TextBox? weightTextBox = this.Controls.Find(weightTextBoxName, true).FirstOrDefault() as TextBox;
                TextBox? gradeTextBox = this.Controls.Find(gradeTextBoxName, true).FirstOrDefault() as TextBox;
                TextBox? courseCode = this.Controls.Find(courseCodeName, true).FirstOrDefault() as TextBox;

                if (weightTextBox == null || gradeTextBox == null ||
                    !IsControlEffectivelyEnabled(weightTextBox) || !IsControlEffectivelyEnabled(gradeTextBox))
                {
                    continue;
                }

                double weight = 0;
                double grade = 0;

                if (double.TryParse(weightTextBox.Text, out weight) &&
                    double.TryParse(gradeTextBox.Text, out grade))
                {
                    if (weight < 0.0 || grade < 0.0)
                    {
                        MessageBox.Show("You cannot have a negative weight or grade.");
                        weightTextBox.Clear();
                        gradeTextBox.Clear();
                        if (resultBox != null)
                        {
                            resultBox.Text = "0";
                        }
                        return;
                    }

                    weight /= 100.0;
                    double current = weight * grade;
                    double tempWeight = 100 * weight;

                    if (i < 8)
                    {
                        TheorytotalPossible += tempWeight;
                        Theory[n] += current;
                    }
                    else
                    {
                        LabstotalPossible += tempWeight;
                        Labs[n] += current;
                    }
                }

                if (courseCode != null && IsControlEffectivelyEnabled(courseCode))
                {
                    CourseCodes[n] = courseCode.Text;
                }
                else
                {
                    CourseCodes[n] = null;
                }
            }

            totals[n] = Theory[n] + Labs[n];

            if (totals[n] >= 0.0 && totals[n] <= 100.0)
            {
                if (resultBox != null)
                    resultBox.Text = totals[n].ToString("F2");
                if (theoryBox != null)
                    theoryBox.Text = (TheorytotalPossible == 0) ? "N/A" : ((Theory[n] / TheorytotalPossible) * 100).ToString("F2");
                if (labBox != null)
                    labBox.Text = (LabstotalPossible == 0) ? "N/A" : ((Labs[n] / LabstotalPossible) * 100).ToString("F2");
            }
            else
            {
                if (resultBox != null) resultBox.Text = "";
                if (theoryBox != null) theoryBox.Text = "";
                if (labBox != null) labBox.Text = "";
            }

            if (totals[n] > 100.0)
            {
                MessageBox.Show("Your total grade is above 100%.");
            }
            else if (totals[n] < 0.0)
            {
                MessageBox.Show("Your grade is negative.");
                if (resultBox != null) resultBox.Text = "";
            }

            if ((TheorytotalPossible == 0 || (Theory[n] / TheorytotalPossible) >= 0.5) &&
                (LabstotalPossible == 0 || (Labs[n] / LabstotalPossible) >= 0.5))
            {
                if (totals[n] < 49.5) { letterGrade = "F"; GPA = "0.00"; }
                else if (totals[n] < 52.5) { letterGrade = "D-"; GPA = "0.67"; }
                else if (totals[n] < 56.5) { letterGrade = "D"; GPA = "1.00"; }
                else if (totals[n] < 59.5) { letterGrade = "D+"; GPA = "1.33"; }
                else if (totals[n] < 62.5) { letterGrade = "C-"; GPA = "1.67"; }
                else if (totals[n] < 66.5) { letterGrade = "C"; GPA = "2.00"; }
                else if (totals[n] < 69.5) { letterGrade = "C+"; GPA = "2.33"; }
                else if (totals[n] < 72.5) { letterGrade = "B-"; GPA = "2.67"; }
                else if (totals[n] < 76.5) { letterGrade = "B"; GPA = "3.00"; }
                else if (totals[n] < 79.5) { letterGrade = "B+"; GPA = "3.33"; }
                else if (totals[n] < 84.5) { letterGrade = "B+"; GPA = "3.67"; }
                else if (totals[n] < 89.5) { letterGrade = "A-"; GPA = "4.00"; }
                else { letterGrade = "A+"; GPA = "4.33"; }
            }
            else
            {
                letterGrade = "F";
                GPA = "0.00";
            }

            if (totals[n] >= 0.0 && totals[n] <= 100.0)
            {
                if (letterGradeBox != null)
                    letterGradeBox.Text = letterGrade;
                if (GPABox != null)
                    GPABox.Text = GPA;
            }
            else
            {
                if (letterGradeBox != null)
                    letterGradeBox.Text = "";
                if (GPABox != null)
                    GPABox.Text = "";
            }

            calculateTGPA();
        }

        private void calculateTGPA()
        {
            double TGPATemp = 0, counter = 0;

            for (int n = 1; n <= 5; n++)
            {
                string radioBoxName = "rbtn_En" + n;
                RadioButton? radBox = this.Controls.Find(radioBoxName, true).FirstOrDefault() as RadioButton;

                if (radBox != null && radBox.Checked)
                {
                    string GPABoxName = "lblGPA" + n;
                    Label? GPABox = this.Controls.Find(GPABoxName, true).FirstOrDefault() as Label;

                    if (GPABox != null && !string.IsNullOrWhiteSpace(GPABox.Text))
                    {
                        if (double.TryParse(GPABox.Text, out double GPAValue))
                        {
                            TGPATemp += GPAValue;
                            counter++;
                            TGPA = TGPATemp / counter;
                        }
                    }
                }
                else
                {
                    totals[n - 1] = -1.0;
                }
            }
            LblTGPA.Text = TGPA.ToString("F2");
        }

        private void rbtn_Disabled5_CheckedChanged(object sender, EventArgs e)
        {
            gBox5.Enabled = false;
        }
        private void rbtn_En5_CheckedChanged(object sender, EventArgs e)
        {
            gBox5.Enabled = true;
        }
        private void pbHelp_Click(object sender, EventArgs e)
        {
        }
        private void label27_Click(object sender, EventArgs e)
        {
        }
        private void btn_Scheduler_Click(object sender, EventArgs e)
        {
            calculateTGPA();
            if (scheduler == null || scheduler.IsDisposed)
            {
                scheduler = new Schedule(this);
            }
            scheduler.LoadTotals(totals);
            scheduler.loadNames(CourseCodes);
            this.Hide();
            scheduler.Show();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            bool atLeastOneEnabled = false;

            for (int i = 0; i < 5; i++)
            {
                int subjectNumber = i + 1;
                GroupBox courseCard = this.Controls.Find("gBox" + subjectNumber, true).FirstOrDefault() as GroupBox;

                if (courseCard != null && courseCard.Enabled)
                {
                    atLeastOneEnabled = true;
                    TextBox courseNameTextBox = this.Controls.Find("txt_CourseNameB" + subjectNumber, true).FirstOrDefault() as TextBox;

                    if (courseNameTextBox == null || string.IsNullOrWhiteSpace(courseNameTextBox.Text))
                    {
                        MessageBox.Show($"Please ensure that the course name field for Subject {subjectNumber} is filled out before exporting.",
                                        "Missing Course Name",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            if (!atLeastOneEnabled)
            {
                MessageBox.Show("There are no enabled course cards to export.",
                                "Export Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            StringBuilder exportText = new StringBuilder();
            exportText.AppendLine("GPA Calculator Data Export");
            exportText.AppendLine("---------------------------------------");

            for (int i = 0; i < 5; i++)
            {
                int subjectNumber = i + 1;
                GroupBox courseCard = this.Controls.Find("gBox" + subjectNumber, true).FirstOrDefault() as GroupBox;

                if (courseCard != null && courseCard.Enabled)
                {
                    TextBox courseName = this.Controls.Find("txt_CourseNameB" + (i + 1), true).FirstOrDefault() as TextBox;
                    TextBox courseCodeTextBox = this.Controls.Find("txt_CourseCodeB" + (i + 1), true).FirstOrDefault() as TextBox;
                    Label resultLabel = this.Controls.Find("lblResult" + subjectNumber, true).FirstOrDefault() as Label;
                    Label theoryLabel = this.Controls.Find("lblTheory" + subjectNumber, true).FirstOrDefault() as Label;
                    Label labLabel = this.Controls.Find("lblLab" + subjectNumber, true).FirstOrDefault() as Label;
                    Label letterGradeLabel = this.Controls.Find("lblLetterGrade" + subjectNumber, true).FirstOrDefault() as Label;
                    Label GPALabel = this.Controls.Find("lblGPA" + subjectNumber, true).FirstOrDefault() as Label;

                    exportText.AppendLine($"Subject: {courseName?.Text} - {courseCodeTextBox?.Text}");
                    exportText.AppendLine($"   Total Grade: {(resultLabel != null ? resultLabel.Text : "N/A")}");
                    exportText.AppendLine($"   Theory Score: {(theoryLabel != null ? theoryLabel.Text : "N/A")}");
                    exportText.AppendLine($"   Lab Score: {(labLabel != null ? labLabel.Text : "N/A")}");
                    exportText.AppendLine($"   Letter Grade: {(letterGradeLabel != null ? letterGradeLabel.Text : "N/A")}");
                    exportText.AppendLine($"   GPA: {(GPALabel != null ? GPALabel.Text : "N/A")}");
                    exportText.AppendLine();
                }
            }

            exportText.AppendLine("Overall TGPA: " + LblTGPA.Text);
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text File|*.txt",
                Title = "Save GPA Data",
                FileName = "TermGPAData.txt"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(saveFileDialog.FileName, exportText.ToString());
                    MessageBox.Show("Data exported successfully!", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while exporting data:\n" + ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void cgpaText(double cgpa)
        {
            LblTCGPATag.Visible = true;
            LblCGPA.Visible = true;
            LblCGPA.Text = cgpa.ToString("F2");
        }

        private void label28_Click(object sender, EventArgs e)
        {

        }
    }
}
