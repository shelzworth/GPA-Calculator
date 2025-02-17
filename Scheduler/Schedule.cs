using Scheduler;
using System.Text;

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
                    if (GPAtotals[subject - 1] == -1)
                    {
                        current.Text = "";
                    }
                    else
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
            double cgpa = Calculatecgpa(sem);
            _calculator.cgpaText(cgpa);
            LblCGPA.Text = cgpa.ToString("F2");
            GroupBox semBox = this.Controls.Find("gBoxS" + sem, true).FirstOrDefault() as GroupBox;
            if(!CheckCourseNames(sem))
            {
                return;
            }
            if (sem == 9)
            {
                btnSaveSem.Enabled = false;
                btnSaveSem.BackColor = Color.Gray;
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
                semBox.Enabled = false;
            }
            sem++;
        }
        private double Calculatecgpa(int currentSemester)
        {
            double total = 0;
            int filledCount = 0;

            for (int s = 1; s <= currentSemester; s++)
            {
                for (int subject = 1; subject <= 5; subject++)
                {
                    ComboBox? current = this.Controls.Find("CBox" + subject + "S" + s, true)
                                                     .FirstOrDefault() as ComboBox;
                    if (current != null && !string.IsNullOrWhiteSpace(current.Text) &&
                        double.TryParse(current.Text, out double value))
                    {
                        total += value;
                        filledCount++;
                    }
                }
            }
            return (filledCount > 0) ? (total / filledCount) : 0;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearAll(this);
            LblCGPA.Text = "_____";
            btnSaveSem.Enabled = true;
            sem = 1;
        }

        private void ClearAll(Control parent)
        {
            for(int x = 1; x < 9; x++)
            {
                GroupBox semBox = this.Controls.Find("gBoxS" + x, true).FirstOrDefault() as GroupBox;
                semBox.Enabled = true;
            }
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is ComboBox combo)
                {
                    combo.SelectedIndex = -1;
                }
                else if (ctrl is TextBox textBox)
                {
                    textBox.Clear();
                }
                if (ctrl.HasChildren)
                {
                    ClearAll(ctrl);
                }
            }
        }
        public void loadNames(String[] CourseCodes)
        {
            for (int i = 0; i < CourseCodes.Length; i++)
            {
                string courseCodeName = "TB" + (i + 1) + "S" + sem;
                TextBox? courseCode = this.Controls.Find(courseCodeName, true).FirstOrDefault() as TextBox;
                if (courseCode != null)
                {
                    courseCode.Text = CourseCodes[i] ?? "";
                }
            }
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            StringBuilder exportText = new StringBuilder();
            exportText.AppendLine("Schedule Data Export");
            exportText.AppendLine("---------------------------------------");

            int savedSemesters = sem - 1;
            if (savedSemesters < 1)
            {
                MessageBox.Show("No semester data to export.", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            for (int s = 1; s <= savedSemesters; s++)
            {
                if (!CheckCourseNames(s))
                {
                    return;
                }
                exportText.AppendLine($"Semester {s}:");

                int numSubjects = GPAtotals != null ? GPAtotals.Length : 5;

                for (int subject = 1; subject <= numSubjects; subject++)
                {
                    TextBox courseNameTextBox = this.Controls.Find("TB" + subject + "S" + s, true).FirstOrDefault() as TextBox;
                    ComboBox gpaComboBox = this.Controls.Find("CBox" + subject + "S" + s, true).FirstOrDefault() as ComboBox;

                    string courseName = courseNameTextBox != null ? courseNameTextBox.Text : "N/A";
                    string gpaValue = gpaComboBox != null ? gpaComboBox.Text : "N/A";

                    if (!string.IsNullOrWhiteSpace(courseName) || !string.IsNullOrWhiteSpace(gpaValue))
                    {
                        exportText.AppendLine($"  Subject {subject}:");
                        exportText.AppendLine($"    Course Name: {courseName}");
                        exportText.AppendLine($"    GPA: {gpaValue}");
                    }
                }
                exportText.AppendLine();
            }

            exportText.AppendLine("---------------------------------------");
            exportText.AppendLine("Overall CGPA: " + LblCGPA.Text);

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text Files|*.txt",
                Title = "Save Schedule Data Export",
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
        private bool CheckCourseNames(int sem)
        {
            // Determine the number of subjects for this semester.
            int numSubjects = GPAtotals != null ? GPAtotals.Length : 5;
            for (int subject = 1; subject <= numSubjects; subject++)
            {
                // Assume the course name textbox is named "TB{subject}S{sem}"
                TextBox courseNameTextBox = this.Controls.Find("TB" + subject + "S" + sem, true)
                                                       .FirstOrDefault() as TextBox;
                if (courseNameTextBox == null || string.IsNullOrWhiteSpace(courseNameTextBox.Text))
                {
                    MessageBox.Show($"Please ensure that the course name for Subject {subject} in Semester {sem} is filled out before exporting or saving.",
                                    "Missing Course Name",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }
    }
}
