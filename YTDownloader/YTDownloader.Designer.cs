namespace YTDownloader
{
    partial class YTDownloader
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YTDownloader));
            menuStrip1 = new MenuStrip();
            plikToolStripMenuItem = new ToolStripMenuItem();
            addUrlBtn = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            quitBtn = new ToolStripMenuItem();
            edycjaToolStripMenuItem = new ToolStripMenuItem();
            downloadBtn = new ToolStripMenuItem();
            cancelBtn = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            otwórzFolderZapisuToolStripMenuItem = new ToolStripMenuItem();
            preferencesBtn = new ToolStripMenuItem();
            pomocToolStripMenuItem = new ToolStripMenuItem();
            aboutBtn = new ToolStripMenuItem();
            dataGridView1 = new DataGridView();
            FileName = new DataGridViewTextBoxColumn();
            FileExt = new DataGridViewTextBoxColumn();
            FileState = new DataGridViewTextBoxColumn();
            FileURL = new DataGridViewLinkColumn();
            notifyIcon = new NotifyIcon(components);
            notifyIconContextMenu = new ContextMenuStrip(components);
            notifyIconVisibility = new ToolStripMenuItem();
            dodajURLToolStripMenuItem = new ToolStripMenuItem();
            notifyIconTerminate = new ToolStripMenuItem();
            zacznijToolStripMenuItem = new ToolStripMenuItem();
            anulujToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            notifyIconContextMenu.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            resources.ApplyResources(menuStrip1, "menuStrip1");
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { plikToolStripMenuItem, edycjaToolStripMenuItem, pomocToolStripMenuItem });
            menuStrip1.Name = "menuStrip1";
            menuStrip1.RenderMode = ToolStripRenderMode.System;
            // 
            // plikToolStripMenuItem
            // 
            resources.ApplyResources(plikToolStripMenuItem, "plikToolStripMenuItem");
            plikToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addUrlBtn, toolStripSeparator1, quitBtn });
            plikToolStripMenuItem.Name = "plikToolStripMenuItem";
            // 
            // addUrlBtn
            // 
            resources.ApplyResources(addUrlBtn, "addUrlBtn");
            addUrlBtn.Name = "addUrlBtn";
            addUrlBtn.Click += addUrlBtn_Click;
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(toolStripSeparator1, "toolStripSeparator1");
            toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // quitBtn
            // 
            resources.ApplyResources(quitBtn, "quitBtn");
            quitBtn.Name = "quitBtn";
            quitBtn.Click += quitBtn_Click;
            // 
            // edycjaToolStripMenuItem
            // 
            resources.ApplyResources(edycjaToolStripMenuItem, "edycjaToolStripMenuItem");
            edycjaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { downloadBtn, cancelBtn, toolStripSeparator2, otwórzFolderZapisuToolStripMenuItem, preferencesBtn });
            edycjaToolStripMenuItem.Name = "edycjaToolStripMenuItem";
            // 
            // downloadBtn
            // 
            resources.ApplyResources(downloadBtn, "downloadBtn");
            downloadBtn.Name = "downloadBtn";
            downloadBtn.Click += downloadBtn_Click;
            // 
            // cancelBtn
            // 
            resources.ApplyResources(cancelBtn, "cancelBtn");
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Click += cancelBtn_Click;
            // 
            // toolStripSeparator2
            // 
            resources.ApplyResources(toolStripSeparator2, "toolStripSeparator2");
            toolStripSeparator2.Name = "toolStripSeparator2";
            // 
            // otwórzFolderZapisuToolStripMenuItem
            // 
            resources.ApplyResources(otwórzFolderZapisuToolStripMenuItem, "otwórzFolderZapisuToolStripMenuItem");
            otwórzFolderZapisuToolStripMenuItem.Name = "otwórzFolderZapisuToolStripMenuItem";
            otwórzFolderZapisuToolStripMenuItem.Click += otwórzFolderZapisuToolStripMenuItem_Click;
            // 
            // preferencesBtn
            // 
            resources.ApplyResources(preferencesBtn, "preferencesBtn");
            preferencesBtn.Name = "preferencesBtn";
            preferencesBtn.Click += preferencesBtn_Click;
            // 
            // pomocToolStripMenuItem
            // 
            resources.ApplyResources(pomocToolStripMenuItem, "pomocToolStripMenuItem");
            pomocToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutBtn });
            pomocToolStripMenuItem.Name = "pomocToolStripMenuItem";
            // 
            // aboutBtn
            // 
            resources.ApplyResources(aboutBtn, "aboutBtn");
            aboutBtn.Name = "aboutBtn";
            aboutBtn.Click += aboutBtn_Click;
            // 
            // dataGridView1
            // 
            resources.ApplyResources(dataGridView1, "dataGridView1");
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { FileName, FileExt, FileState, FileURL });
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            // 
            // FileName
            // 
            FileName.DataPropertyName = "FileName";
            resources.ApplyResources(FileName, "FileName");
            FileName.Name = "FileName";
            FileName.ReadOnly = true;
            // 
            // FileExt
            // 
            FileExt.DataPropertyName = "FileExt";
            resources.ApplyResources(FileExt, "FileExt");
            FileExt.Name = "FileExt";
            // 
            // FileState
            // 
            FileState.DataPropertyName = "FileState";
            resources.ApplyResources(FileState, "FileState");
            FileState.Name = "FileState";
            FileState.ReadOnly = true;
            // 
            // FileURL
            // 
            FileURL.DataPropertyName = "FileURL";
            resources.ApplyResources(FileURL, "FileURL");
            FileURL.Name = "FileURL";
            FileURL.ReadOnly = true;
            FileURL.Resizable = DataGridViewTriState.True;
            FileURL.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // notifyIcon
            // 
            notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
            resources.ApplyResources(notifyIcon, "notifyIcon");
            notifyIcon.ContextMenuStrip = notifyIconContextMenu;
            notifyIcon.MouseDoubleClick += notifyIcon_MouseDoubleClick;
            // 
            // notifyIconContextMenu
            // 
            resources.ApplyResources(notifyIconContextMenu, "notifyIconContextMenu");
            notifyIconContextMenu.ImageScalingSize = new Size(20, 20);
            notifyIconContextMenu.Items.AddRange(new ToolStripItem[] { zacznijToolStripMenuItem, anulujToolStripMenuItem, dodajURLToolStripMenuItem, toolStripSeparator3, notifyIconVisibility, notifyIconTerminate });
            notifyIconContextMenu.Name = "notifyIconContextMenu";
            // 
            // notifyIconVisibility
            // 
            resources.ApplyResources(notifyIconVisibility, "notifyIconVisibility");
            notifyIconVisibility.Name = "notifyIconVisibility";
            notifyIconVisibility.Click += notifyIconVisibility_Click;
            // 
            // dodajURLToolStripMenuItem
            // 
            resources.ApplyResources(dodajURLToolStripMenuItem, "dodajURLToolStripMenuItem");
            dodajURLToolStripMenuItem.Name = "dodajURLToolStripMenuItem";
            dodajURLToolStripMenuItem.Click += dodajURLToolStripMenuItem_Click;
            // 
            // notifyIconTerminate
            // 
            resources.ApplyResources(notifyIconTerminate, "notifyIconTerminate");
            notifyIconTerminate.Name = "notifyIconTerminate";
            notifyIconTerminate.Click += notifyIconTerminate_Click;
            // 
            // zacznijToolStripMenuItem
            // 
            resources.ApplyResources(zacznijToolStripMenuItem, "zacznijToolStripMenuItem");
            zacznijToolStripMenuItem.Name = "zacznijToolStripMenuItem";
            zacznijToolStripMenuItem.Click += downloadBtn_Click;
            // 
            // anulujToolStripMenuItem
            // 
            resources.ApplyResources(anulujToolStripMenuItem, "anulujToolStripMenuItem");
            anulujToolStripMenuItem.Name = "anulujToolStripMenuItem";
            anulujToolStripMenuItem.Click += cancelBtn_Click;
            // 
            // toolStripSeparator3
            // 
            resources.ApplyResources(toolStripSeparator3, "toolStripSeparator3");
            toolStripSeparator3.Name = "toolStripSeparator3";
            // 
            // YTDownloader
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(dataGridView1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "YTDownloader";
            FormClosing += YTDownloader_FormClosing;
            Load += YTDownloader_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            notifyIconContextMenu.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem plikToolStripMenuItem;
        private ToolStripMenuItem edycjaToolStripMenuItem;
        private ToolStripMenuItem addUrlBtn;
        private ToolStripMenuItem quitBtn;
        private ToolStripMenuItem downloadBtn;
        private ToolStripMenuItem pomocToolStripMenuItem;
        private ToolStripMenuItem aboutBtn;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem preferencesBtn;
        private ToolStripMenuItem cancelBtn;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn FileName;
        private DataGridViewTextBoxColumn FileExt;
        private DataGridViewTextBoxColumn FileState;
        private DataGridViewLinkColumn FileURL;
        private ToolStripMenuItem otwórzFolderZapisuToolStripMenuItem;
        private NotifyIcon notifyIcon;
        private ContextMenuStrip notifyIconContextMenu;
        private ToolStripMenuItem notifyIconVisibility;
        private ToolStripMenuItem notifyIconTerminate;
        private ToolStripMenuItem dodajURLToolStripMenuItem;
        private ToolStripMenuItem zacznijToolStripMenuItem;
        private ToolStripMenuItem anulujToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
    }
}
