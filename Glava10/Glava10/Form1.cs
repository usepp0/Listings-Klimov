using System.IO;

namespace Glava10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            TreeNode rootNode = new TreeNode(@"C:\");
            treeDirectory.Nodes.Add(rootNode);
            FillNodes(rootNode);
            treeDirectory.Nodes[0].Expand();

        }

        private void FillNodes(TreeNode dirNode)
        {
            DirectoryInfo dir = new DirectoryInfo(dirNode.FullPath);
            foreach (DirectoryInfo dirItem in dir.GetDirectories())
            {
                // Добавляем узел для каждой папки
                TreeNode newNode = new TreeNode(dirItem.Name);
                dirNode.Nodes.Add(newNode);
                newNode.Nodes.Add("*");
            }
        }

        private void treeDirectory_BeforeExpand(object sender,
TreeViewCancelEventArgs e)
        {
            // Если найден узел со звездочкой *, то удаляем его
            // и получаем список подпапок.
            if (e.Node.Nodes[0].Text == "*")
            {
                e.Node.Nodes.Clear();
                FillNodes(e.Node);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string[] astrLogicalDrives = System.IO.Directory.GetLogicalDrives();
            foreach (string disk in astrLogicalDrives)
                listBox1.Items.Add(disk);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.IO.DriveInfo drv = new System.IO.DriveInfo(@"d:\");
            listBox1.Items.Clear();
            listBox1.Items.Add("Диск: " + drv.Name);
            if (drv.IsReady)
            {
                listBox1.Items.Add("Тип диска: " + drv.DriveType.ToString());
                listBox1.Items.Add("Файловая система: " +
                drv.DriveFormat.ToString());
                listBox1.Items.Add("Свободное место на диске: " +
                drv.AvailableFreeSpace.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string[] astrFolders = System.IO.Directory.GetDirectories(@"c:\");
            foreach (string folder in astrFolders)
                listBox1.Items.Add(folder);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(@"c:\");
            System.IO.DirectoryInfo[] folders = di.GetDirectories("*pro*");
            foreach (System.IO.DirectoryInfo maskdirs in folders)
                listBox1.Items.Add(maskdirs);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (System.IO.Directory.Exists(@"C:\windows"))
                listBox1.Items.Add("Папка " + @"C:\Windows" + " существует");
            else
                listBox1.Items.Add("Папка не существует");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string oldPathString = @"C:\MyFolder";
            string newPathString = @"C:\NewFolder";
            Directory.Move(oldPathString, newPathString);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                System.IO.Directory.Delete(@"c:\wutemp");
                MessageBox.Show("Папка удалена.");
            }
            catch (Exception)
            {
                MessageBox.Show("Нельзя удалить непустую папку.");
            }
            finally { }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            fbd.Description = "Выберите папку";
            fbd.ShowNewFolderButton = false;
            if (fbd.ShowDialog() == DialogResult.OK)
                this.Text = fbd.SelectedPath;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Environment.GetFolderPath(
            Environment.SpecialFolder.Personal));
        }

        private void button10_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new
            System.IO.DirectoryInfo(@"c:\wutemp");
            listBox1.Items.Clear();
            listBox1.Items.Add("Проверка папки: " + dir.Name);
            listBox1.Items.Add("Родительская папка: " + dir.Parent.Name);
            listBox1.Items.Add("Папка существует: ");
            listBox1.Items.Add(dir.Exists.ToString());
            if (dir.Exists)
            {
                listBox1.Items.Add("Папка создана: ");
                listBox1.Items.Add(dir.CreationTime.ToString());
                listBox1.Items.Add("Папка изменена: ");
                listBox1.Items.Add(dir.LastWriteTime.ToString());
                listBox1.Items.Add("Время последнего доступа: ");
                listBox1.Items.Add(dir.LastAccessTime.ToString());
                listBox1.Items.Add("Атрибуты папки: ");
                listBox1.Items.Add(dir.Attributes.ToString());
                listBox1.Items.Add("Папка содержит: " +
                dir.GetFiles().Length.ToString() + " файла");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string[] directoryEntries =
            System.IO.Directory.GetFileSystemEntries(@"c:\windows");
            foreach (string str in directoryEntries)
            {
                listBox1.Items.Add(str);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string[] astrFiles = System.IO.Directory.GetFiles(@"c:\");
            listBox1.Items.Add("Всего файлов: " + astrFiles.Length);
            foreach (string file in astrFiles)
                listBox1.Items.Add(file);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string[] astrFiles = System.IO.Directory.GetFiles(@"c:\", "*.in?");
            listBox1.Items.Add("Всего файлов: " + astrFiles.Length);
            foreach (string file in astrFiles)
                listBox1.Items.Add(file);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(Application.StartupPath + "\\test.txt"))
                listBox1.Items.Add("Файл test.txt существует");
            else
                listBox1.Items.Add("Файл test.txt не существует");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            System.IO.FileInfo file = new
            System.IO.FileInfo(@"c:\wutemp\text.txt");
            listBox1.Items.Clear();
            listBox1.Items.Add("Свойства для файла: " + file.Name);
            listBox1.Items.Add("Наличие файла: " + file.Exists.ToString());
            if (file.Exists)
            {
                listBox1.Items.Add("Время создания файла: ");
                listBox1.Items.Add(file.CreationTime.ToString());
                listBox1.Items.Add("Последнее изменение файла: ");
                listBox1.Items.Add(file.LastWriteTime.ToString());
                listBox1.Items.Add("Файл был открыт в последний раз: ");
                listBox1.Items.Add(file.LastAccessTime.ToString());
                listBox1.Items.Add("Размер файла (в байтах): ");
                listBox1.Items.Add(file.Length.ToString());
                listBox1.Items.Add("Атрибуты файла: ");
                listBox1.Items.Add(file.Attributes.ToString());
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            System.Diagnostics.FileVersionInfo info =
            System.Diagnostics.FileVersionInfo.GetVersionInfo(@"C:\windows\system32\mspaint.exe");
            listBox1.Items.Add("Выбранный файл: " + info.FileName);
            listBox1.Items.Add("Product Name: " + info.ProductName);
            listBox1.Items.Add("Product Version: " + info.ProductVersion);
            listBox1.Items.Add("Company Name: " + info.CompanyName);
            listBox1.Items.Add("File Version: " + info.FileVersion);
            listBox1.Items.Add("File Description: " + info.FileDescription);
            listBox1.Items.Add("Original Filename: " + info.OriginalFilename);
            listBox1.Items.Add("Legal Copyright: " + info.LegalCopyright);
            listBox1.Items.Add("InternalName: " + info.InternalName);
            listBox1.Items.Add("IsDebug: " + info.IsDebug);
            listBox1.Items.Add("IsPatched: " + info.IsPatched);
            listBox1.Items.Add("IsPreRelease: " + info.IsPreRelease);
            listBox1.Items.Add("IsPrivateBuild: " + info.IsPrivateBuild);
            listBox1.Items.Add("IsSpecialBuild: " + info.IsSpecialBuild);
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Glava10.Properties.Resources.arc;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_MouseEnter_1(object sender, EventArgs e)
        {
            pictureBox1.Image = Glava10.Properties.Resources.arc;
        }

        private void pictureBox1_MouseLeave_1(object sender, EventArgs e)
        {
            pictureBox1.Image = Glava10.Properties.Resources.neco;
        }
    }
}