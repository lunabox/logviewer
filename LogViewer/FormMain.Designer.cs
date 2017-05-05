namespace LogViewer
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出QToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于AToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBoxEncoding = new System.Windows.Forms.ToolStripComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.打开OToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.导出UToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBoxContent = new System.Windows.Forms.PictureBox();
            this.textBoxContent = new System.Windows.Forms.TextBox();
            this.saveFileDialogZip = new System.Windows.Forms.SaveFileDialog();
            this.treeViewMenu = new System.Windows.Forms.TreeView();
            this.menuStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxContent)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件FToolStripMenuItem,
            this.关于AToolStripMenuItem,
            this.toolStripComboBoxEncoding});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(887, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件FToolStripMenuItem
            // 
            this.文件FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开OToolStripMenuItem,
            this.退出QToolStripMenuItem});
            this.文件FToolStripMenuItem.Name = "文件FToolStripMenuItem";
            this.文件FToolStripMenuItem.Size = new System.Drawing.Size(58, 25);
            this.文件FToolStripMenuItem.Text = "文件(&F)";
            // 
            // 打开OToolStripMenuItem
            // 
            this.打开OToolStripMenuItem.Name = "打开OToolStripMenuItem";
            this.打开OToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.打开OToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.打开OToolStripMenuItem.Text = "打开(&O)";
            this.打开OToolStripMenuItem.Click += new System.EventHandler(this.打开OToolStripMenuItem_Click);
            // 
            // 退出QToolStripMenuItem
            // 
            this.退出QToolStripMenuItem.Name = "退出QToolStripMenuItem";
            this.退出QToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.退出QToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.退出QToolStripMenuItem.Text = "退出(&Q)";
            this.退出QToolStripMenuItem.Click += new System.EventHandler(this.退出QToolStripMenuItem_Click);
            // 
            // 关于AToolStripMenuItem
            // 
            this.关于AToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于AToolStripMenuItem1});
            this.关于AToolStripMenuItem.Name = "关于AToolStripMenuItem";
            this.关于AToolStripMenuItem.Size = new System.Drawing.Size(60, 25);
            this.关于AToolStripMenuItem.Text = "关于(&A)";
            // 
            // 关于AToolStripMenuItem1
            // 
            this.关于AToolStripMenuItem1.Name = "关于AToolStripMenuItem1";
            this.关于AToolStripMenuItem1.Size = new System.Drawing.Size(116, 22);
            this.关于AToolStripMenuItem1.Text = "关于(&A)";
            this.关于AToolStripMenuItem1.Click += new System.EventHandler(this.关于AToolStripMenuItem1_Click);
            // 
            // toolStripComboBoxEncoding
            // 
            this.toolStripComboBoxEncoding.BackColor = System.Drawing.Color.White;
            this.toolStripComboBoxEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxEncoding.Items.AddRange(new object[] {
            "GBK",
            "UTF8",
            "UTF32",
            "Unicode"});
            this.toolStripComboBoxEncoding.Name = "toolStripComboBoxEncoding";
            this.toolStripComboBoxEncoding.Size = new System.Drawing.Size(80, 25);
            this.toolStripComboBoxEncoding.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxEncoding_SelectedIndexChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 29);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeViewMenu);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pictureBoxContent);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxContent);
            this.splitContainer1.Size = new System.Drawing.Size(887, 606);
            this.splitContainer1.SplitterDistance = 295;
            this.splitContainer1.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开OToolStripMenuItem1,
            this.导出UToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(119, 48);
            // 
            // 打开OToolStripMenuItem1
            // 
            this.打开OToolStripMenuItem1.Name = "打开OToolStripMenuItem1";
            this.打开OToolStripMenuItem1.Size = new System.Drawing.Size(118, 22);
            this.打开OToolStripMenuItem1.Text = "打开(&O)";
            this.打开OToolStripMenuItem1.Click += new System.EventHandler(this.打开OToolStripMenuItem1_Click);
            // 
            // 导出UToolStripMenuItem
            // 
            this.导出UToolStripMenuItem.Name = "导出UToolStripMenuItem";
            this.导出UToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.导出UToolStripMenuItem.Text = "导出(&U)";
            this.导出UToolStripMenuItem.Click += new System.EventHandler(this.导出UToolStripMenuItem_Click);
            // 
            // pictureBoxContent
            // 
            this.pictureBoxContent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxContent.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxContent.Name = "pictureBoxContent";
            this.pictureBoxContent.Size = new System.Drawing.Size(588, 606);
            this.pictureBoxContent.TabIndex = 1;
            this.pictureBoxContent.TabStop = false;
            this.pictureBoxContent.Visible = false;
            // 
            // textBoxContent
            // 
            this.textBoxContent.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxContent.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxContent.Location = new System.Drawing.Point(0, 0);
            this.textBoxContent.Multiline = true;
            this.textBoxContent.Name = "textBoxContent";
            this.textBoxContent.ReadOnly = true;
            this.textBoxContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxContent.Size = new System.Drawing.Size(588, 606);
            this.textBoxContent.TabIndex = 0;
            // 
            // saveFileDialogZip
            // 
            this.saveFileDialogZip.Filter = "所有文件|*.*";
            // 
            // treeViewMenu
            // 
            this.treeViewMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewMenu.ContextMenuStrip = this.contextMenuStrip1;
            this.treeViewMenu.HideSelection = false;
            this.treeViewMenu.Location = new System.Drawing.Point(0, 0);
            this.treeViewMenu.Name = "treeViewMenu";
            this.treeViewMenu.Size = new System.Drawing.Size(292, 606);
            this.treeViewMenu.TabIndex = 1;
            this.treeViewMenu.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewMenu_NodeMouseClick);
            // 
            // FormMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 635);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LogViewer";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormMain_DragEnter);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxContent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开OToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出QToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于AToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于AToolStripMenuItem1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox textBoxContent;
        private System.Windows.Forms.PictureBox pictureBoxContent;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxEncoding;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 打开OToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 导出UToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialogZip;
        private System.Windows.Forms.TreeView treeViewMenu;
    }
}

