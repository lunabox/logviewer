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
            //this.listViewFileNames.Columns[0].Width = this.listViewFileNames.ClientSize.Width;
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
                this.treeViewMenu.Nodes.Clear();
                TreeNode node = this.treeViewMenu.Nodes.Add(Path.GetFileName(path));
                string[] files = logFile.GetFileNames(path);
                updateTreeviewNodeData(this.treeViewMenu.Nodes[0], files);
                this.Text = string.Format("LogView - {0}", path);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("解析文件错误，请检测是否是zip格式的文件\n" + e.Message, "错误警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// 更新某个节点的数据
        /// </summary>
        /// <param name="node"></param>
        /// <param name="fileNames"></param>
        private void updateTreeviewNodeData(TreeNode node, string[] fileNames)
        {
            this.treeViewMenu.BeginUpdate();
            node.Nodes.Clear();
            foreach (string file in fileNames)
            {
                if (file == null)
                    continue;
                string dir = Path.GetDirectoryName(file);
                if (dir != "")
                {
                    if (!node.Nodes.ContainsKey(dir))
                    {
                        node.Nodes.Add(dir, dir);
                    }
                    node.Nodes[dir].Nodes.Add(Path.GetFileName(file)).Tag = file;
                }
                else
                {
                    // 根目录显示的文件
                    node.Nodes.Add(file).Tag = file;
                }
            }
            // 展开根目录
            node.Expand();
            this.treeViewMenu.EndUpdate();
        }

        private void FormMain_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
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
            // 选择的节点是叶子节点
            if (this.treeViewMenu.SelectedNode.Nodes.Count == 0)
            {
                string name = this.treeViewMenu.SelectedNode.Tag.ToString();
                parser(name);
            }
            else
            {
                // 如果已经展开
                if (this.treeViewMenu.SelectedNode.IsExpanded)
                {
                    this.treeViewMenu.SelectedNode.Collapse();
                }
                else
                {
                    this.treeViewMenu.SelectedNode.Expand();
                }
            }
        }

        private void 导出UToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 叶子节点
            if (this.treeViewMenu.SelectedNode.Nodes.Count == 0)
            {
                string name = this.treeViewMenu.SelectedNode.Text;
                this.saveFileDialogZip.FileName = name;
                if (this.saveFileDialogZip.ShowDialog() == DialogResult.OK)
                {
                    string filename = this.saveFileDialogZip.FileName;
                    FileStream outs = new FileStream(filename, FileMode.Create, FileAccess.Write);
                    Stream ins = logFile.GetFileStream(this.treeViewMenu.SelectedNode.Tag.ToString());
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

        private void treeViewMenu_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                if (e.Node.Nodes.Count == 0)
                {
                    // 叶子节点，左键点击
                    parser(e.Node.Tag.ToString());
                }
            }
            else
            {
                // 非左键的时候，选中状态
                this.treeViewMenu.SelectedNode = e.Node;
            }

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (this.treeViewMenu.SelectedNode == null || this.treeViewMenu.SelectedNode.Nodes.Count > 0)
            {
                if (this.treeViewMenu.SelectedNode.IsExpanded)
                {
                    this.contextMenuStrip1.Items[0].Text = "折叠(&C)";
                }
                else
                {
                    this.contextMenuStrip1.Items[0].Text = "展开(&E)";
                }
                // 非叶子节点不能使用导出功能
                this.contextMenuStrip1.Items[1].Enabled = false;
            }
            else
            {
                this.contextMenuStrip1.Items[0].Text = "打开(&O)";
                this.contextMenuStrip1.Items[1].Enabled = true;
            }
        }

    }
}
