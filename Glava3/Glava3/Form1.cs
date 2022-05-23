using System;

namespace Glava3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox2.Text); 
            int y = Convert.ToInt32(textBox3.Text);
            int z = Convert.ToInt32(textBox4.Text);

            textBox1.Text = Convert.ToString(FindMax3(x, y, z));
            textBox5.Text = Convert.ToString(FindMin3(x, y, z));
            Console.ReadLine();
        }

        private int FindMin3(int a, int b, int c)
        {
            int min;
            min = Math.Min(a, Math.Min(b, c));
            return min;
        }

        private int FindMax3(int a, int b, int c)
        {
            int max;
            max = Math.Max(a, Math.Max(b, c));
            return max;
        }

        private void button2_Click(object sender, EventArgs e, double degrees)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            double degrees = Convert.ToDouble(textBox6.Text);
            double radians = (Math.PI / 180) * degrees;
            textBox7.Text = Convert.ToString(radians);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double radians = Convert.ToDouble(textBox7.Text);
            double degrees = (180 / Math.PI) * radians;
            textBox6.Text = Convert.ToString(degrees);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double Fahrenheit = Convert.ToDouble(textBox9.Text);
            double Celsius = ((5.0 / 9.0) * (Fahrenheit - 32));
            textBox8.Text = Convert.ToString(Celsius);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double Celsius = Convert.ToDouble(textBox8.Text);
            double Fahrenheit = (((9.0 / 5.0) * Celsius) + 32);
            textBox9.Text = Convert.ToString(Fahrenheit);
        }
        
        private Random m_Rnd = new Random();
        private Color RandomRGBColor()
        {
            return Color.FromArgb(255, m_Rnd.Next(0, 255),
            m_Rnd.Next(0, 255), m_Rnd.Next(0, 255));
        }
        private void button6_Click(object sender, EventArgs e)
        {
            this.BackColor = RandomRGBColor();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Glava3.Properties.Resources.arc;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Glava3.Properties.Resources.neco;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("using System;");
            listBox1.Items.Add("class A");
            listBox1.Items.Add("{");
            listBox1.Items.Add("static void Main()");
            listBox1.Items.Add("{");
            listBox1.Items.Add("string s = using System;class A{{static void Main(){{string s={0}{1}{0};char q='{0}';Console.Write(s,q,s);}}}};");
            listBox1.Items.Add("char q = ''; Console.Write(s,q,s);");
            listBox1.Items.Add("}");
            listBox1.Items.Add("}");
        }
    }
}