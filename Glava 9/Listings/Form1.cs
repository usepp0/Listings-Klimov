using System.Diagnostics;
namespace Listings
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string appPath = Application.ExecutablePath;
            MessageBox.Show(appPath);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(System.AppDomain.CurrentDomain.BaseDirectory);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = @"Notepad.exe";
            proc.StartInfo.Arguments = "";
            proc.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Process.Start("notepad.exe", "test.txt");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ProcessStartInfo start_info = new ProcessStartInfo
            (@"C:\windows\system32\notepad.exe");
            start_info.UseShellExecute = false;
            start_info.CreateNoWindow = true;
            Process proc = new Process();
            proc.StartInfo = start_info;
            proc.Start();
            proc.WaitForExit();
            MessageBox.Show("Код завершения: " + proc.ExitCode, "Завершение " +
            "Код", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        protected Process[] procs;
        private void button6_Click(object sender, EventArgs e)
        {
            procs = Process.GetProcessesByName("Notepad");
            int i = 0;
            while (i != procs.Length)
            {
                procs[i].Kill();
                i++;
                MessageBox.Show("Всего : " + i.ToString());
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int am = Process.GetCurrentProcess().ProcessorAffinity.ToInt32();
            int processorCount = 0;
            while (am != 0)
            {
                processorCount++;
                am &= (am - 1);
            }
            MessageBox.Show(processorCount.ToString());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            {

                MessageBox.Show(
                String.Format(
                "Число процессоров: {0}",
                Environment.ProcessorCount.ToString()));
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(3000);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            foreach (Process p in Process.GetProcesses())
                listBox1.Items.Add(p.ToString());
        }

        private void button12_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (Process p in
            Process.GetProcesses(System.Environment.MachineName))
            {
                if (p.MainWindowHandle != IntPtr.Zero)
                {
                    listBox1.Items.Add(p.ToString());
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (Process p in Process.GetProcessesByName("notepad"))
                listBox1.Items.Add(p.ToString());
        }

        private void button14_Click(object sender, EventArgs e)
        {
            OperatingSystem os = Environment.OSVersion;
            listBox1.Items.Add(os.Version);
            listBox1.Items.Add(os.Platform);
            listBox1.Items.Add(os.ServicePack);
            listBox1.Items.Add(os.VersionString);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            string fileName = @"c:\windows\regedit.exe";
            FileVersionInfo fileInfo = FileVersionInfo.GetVersionInfo(fileName);
            listBox1.Items.Add("Комментарии: " + fileInfo.Comments);
            listBox1.Items.Add("Производитель: " + fileInfo.CompanyName);
            listBox1.Items.Add("Имя файла: " + fileInfo.FileName);
            listBox1.Items.Add("Номер сборки файла: " + fileInfo.FileBuildPart);
            listBox1.Items.Add("Описание файла: " + fileInfo.FileDescription);
            listBox1.Items.Add("Номер версии файла: " + fileInfo.FileVersion);
            listBox1.Items.Add("Основная часть номера версии: " +
            fileInfo.FileMajorPart);
            listBox1.Items.Add("Вспомогательная часть номера версии: " +
            fileInfo.FileMinorPart);
            listBox1.Items.Add("Номер закрытой части файла: " +
            fileInfo.FilePrivatePart);
            listBox1.Items.Add("Авторские права: " + fileInfo.LegalCopyright);
            listBox1.Items.Add("Товарные знаки: " + fileInfo.LegalTrademarks);
            listBox1.Items.Add("Название продукта: " + fileInfo.ProductName);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            MessageBox.Show(SystemInformation.UserName);
        }

        private void button17_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Listings.Properties.Resources.arc;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Listings.Properties.Resources.neco;
        }
    }
}
