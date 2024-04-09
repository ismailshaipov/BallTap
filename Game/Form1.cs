namespace Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Ball? b = null;
        private Random random = new Random();

        private void button1_Click(object sender, EventArgs e)
        {
            if (b == null)
            {
                b = new Ball();
                b.Location = new(
                    random.Next(panel1.Width - b.Width),
                    random.Next(panel1.Height - b.Height)
                    );
                panel1.Controls.Add(b);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            b = null;
        }
    }
}