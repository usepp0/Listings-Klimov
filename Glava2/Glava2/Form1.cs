using System.ComponentModel;
using System.Text;

namespace Glava2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string partBookTitle = "C#.������";
            string insertText = "�������� ";
            string bookTitle = partBookTitle.Insert(3, insertText);
            MessageBox.Show(bookTitle);
            label1.Text = bookTitle;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string bookTitle = "C#.�������� ������";
            bookTitle = bookTitle.Remove(2);
            MessageBox.Show(bookTitle);
            label1.Text = bookTitle;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string bookTitle = "C#.�������� ������";
            bookTitle = bookTitle.Substring(5, 3);
            MessageBox.Show(bookTitle);
            label1.Text = bookTitle;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string str1 = "���";
            string str2 = "����-�������";
            int i = str2.IndexOf(str1);
            // ���������, ������ �� ������ ��� � ����� ����-�������
            if (i >= 0) MessageBox.Show(str1 + " ������ � ������ " + str2);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string tankman = "4";
            string dog = "1";
            textBox1.Text = tankman + dog; // ������� 41
            int all = int.Parse(tankman) + int.Parse(dog);
            textBox1.Text += Environment.NewLine + all.ToString(); // ������� 5
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int charCode = 169;
            char specialChar = Convert.ToChar(charCode);
            textBox1.Text = specialChar.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int charCode = 0x00AE;
            char specialChar = Convert.ToChar(charCode);
            textBox1.Text += specialChar.ToString();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            System.String FiveStars = new System.String('*', 5);
            textBox1.Text = FiveStars;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            // ������ ����
            Color clr = BackColor;
            textBox1.Text = (TypeDescriptor.GetConverter(clr).ConvertToString(clr));
            clr = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString("Green");
            this.BackColor = clr;
        }

        public static string ReverseString(string str)
        {
            // �������� �� ��������� ������.
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }

            StringBuilder revStr = new StringBuilder(str.Length);
            for (int count = str.Length - 1; count > -1; count--)
            {
                revStr.Append(str[count]);
            }
            return revStr.ToString();
        }
        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text = ReverseString(textBox1.Text);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (button11.Text == "�����")
            {
                timer1.Enabled = true;
                button11.Text = "����";
            }
            else
            {
                timer1.Enabled = false;
            button11.Text = "�����";
            }
        }
        public static int counter = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            string typingText = "C#.�������� ������";
            this.Text = typingText.Substring(0, counter);
            counter++;
            if (counter > typingText.Length)
                counter = 0;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            timer2.Enabled = true;
        }
        private string scrollText = "C#.�������� ������ ";
        private void timer2_Tick(object sender, EventArgs e)
        {
            scrollText = scrollText.Substring(1,
            (scrollText.Length - 1)) + scrollText.Substring(0, 1);
            this.Text = scrollText;
        }

        private void label1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Glava2.Properties.Resources.arc;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Glava2.Properties.Resources.neco;
        }
    }
    }
