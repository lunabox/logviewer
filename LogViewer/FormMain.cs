using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace LogViewer
{
    public partial class FormMain : Form
    {
        private string currentFilePath = null;
        private LogFile logFile = new LogFile();
        private Encoding currentEncoding = Encoding.Default;
        private string currentFileName = null;

        public FormMain(string[] Args)
        {
            InitializeComponent();
            if (Args.Length > 0)
            {
                currentFilePath = Args[0];
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.toolStripComboBoxEncoding.SelectedIndex = 1; // 默认UTF-8
            if (!string.IsNullOrEmpty(currentFilePath))
            {
                if (!parserZipFile(currentFilePath))
                {
                    this.Close();
                }
            }
        }

        private void 关于AToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.ShowDialog();
        }

        private void 退出QToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 打开OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.RestoreDirectory = true;
            dialog.Filter = "所有文件(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                parserZipFile(dialog.FileName);
            }
        }

        private void listViewFileNames_Resize(object sender, EventArgs e)
        {
            this.listViewFileNames.Columns[0].Width = this.listViewFileNames.ClientSize.Width;
        }

        private void FormMain_DragDrop(object sender, DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].Trim() != "")
                {
                    parserZipFile(s[i].Trim());
                }
            }
        }

        /// <summary>
        /// 解析压缩文件
        /// </summary>
        /// <param name="path"></param>
        private bool parserZipFile(string path)
        {
            try
            {
                string[] files = logFile.GetFileNames(path);
                updateListviewData(files);
                this.Text = string.Format("LogView - {0}", path);
                return true;
            }
            catch
            {
                MessageBox.Show("解析文件错误，请检测是否是zip格式的文件", "错误警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void updateListviewData(string[] fileNames)
        {
            this.listViewFileNames.BeginUpdate();
            this.listViewFileNames.Items.Clear();
            foreach (string file in fileNames)
            {
                this.listViewFileNames.Items.Add(file);
            }
            this.listViewFileNames.EndUpdate();
        }

        private void FormMain_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void listViewFileNames_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.ItemIndex >= 0)
            {
                parser(e.Item.Text);
            }
        }

        private void parser(string fileName)
        {
            try
            {
                FileType type = logFile.GetFileType(fileName);
                switchContentVisble(type);
                switch (type)
                {
                    case FileType.Image:
                        Image image = logFile.GetFileImage(fileName);
                        this.pictureBoxContent.BackgroundImage = image;
                        break;
                    case FileType.PCM:
                        SoundPlayer player = new SoundPlayer(logFile.GetFileStream(fileName));
                        player.PlaySync();//另起线程播放
                        break;
                    default:
                        string content = logFile.GetFileContent(fileName, this.currentEncoding);
                        this.textBoxContent.Text = content;
                        this.currentFileName = fileName;
                        break;
                }
            }
            catch
            {
                this.currentFileName = null;
                this.textBoxContent.Text = "不能解析";
            }
        }

        /// <summary>
        /// 切换显示类型
        /// </summary>
        /// <param name="type"></param>
        private void switchContentVisble(FileType type)
        {
            if (type == FileType.Image)
            {
                this.pictureBoxContent.Visible = true;
                this.textBoxContent.Visible = false;
            }
            else
            {
                this.pictureBoxContent.Visible = false;
                this.textBoxContent.Visible = true;
            }
        }

        private void toolStripComboBoxEncoding_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = this.toolStripComboBoxEncoding.SelectedIndex;
            switch (index)
            {
                case 0:
                    this.currentEncoding = Encoding.Default;
                    break;
                case 1:
                    this.currentEncoding = Encoding.UTF8;
                    break;
                case 2:
                    this.currentEncoding = Encoding.UTF32;
                    break;
                case 3:
                    this.currentEncoding = Encoding.Unicode;
                    break;
            }
            if (this.textBoxContent.Visible && currentFileName != null)
            {
                parser(this.currentFileName);
            }
        }

        private void 打开OToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.listViewFileNames.SelectedItems.Count > 0)
            {
                string name = this.listViewFileNames.SelectedItems[0].Text;
                parser(name);
            }
            
        }

        private void 导出UToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listViewFileNames.SelectedItems.Count > 0)
            {
                string name = this.listViewFileNames.SelectedItems[0].Text;
                this.saveFileDialogZip.FileName = name;
                if (this.saveFileDialogZip.ShowDialog() == DialogResult.OK)
                {
                    string filename = this.saveFileDialogZip.FileName;
                    FileStream outs = new FileStream(filename, FileMode.Create, FileAccess.Write);
                    Stream ins = logFile.GetFileStream(name);
                    byte[] buffer = new byte[1024];
                    int len = ins.Read(buffer, 0, buffer.Length);
                    while (len > 0)
                    {
                        outs.Write(buffer, 0, len);
                        len = ins.Read(buffer, 0, buffer.Length);
                    }
                    outs.Close();
                    ins.Close();
                }
            }
        }

    }
}
