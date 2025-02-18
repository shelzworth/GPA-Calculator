using GPA_Calculator;

namespace Scheduler
{

    public partial class Start : Form
    {
        public Calculator calculator = new Calculator();

        public Schedule schedule;

        public Start()
        {
            InitializeComponent();
            schedule = new Schedule(calculator);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            calculator.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Start_Load(object sender, EventArgs e)
        {

        }

        private void btnLinkedin_Click(object sender, EventArgs e)
        {
            string url = "https://www.linkedin.com/in/sheldon-cerejo/";
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }

        private void btnGithub_Click(object sender, EventArgs e)
        {
            string url = "https://github.com/shelzworth";
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }
    }
}
