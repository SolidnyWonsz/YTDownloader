namespace YTDownloader
{
    partial class Preferences
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Preferences));
            label1 = new Label();
            downloadDirTextBox = new TextBox();
            browseDownloadsBtn = new Button();
            browseYTDLBtn = new Button();
            YTDLTextBox = new TextBox();
            label2 = new Label();
            groupBox1 = new GroupBox();
            groupBox4 = new GroupBox();
            autoDownloadBox = new CheckBox();
            groupBox3 = new GroupBox();
            minimizeToTrayBox = new CheckBox();
            showInTrayBox = new CheckBox();
            closeToTrayBox = new CheckBox();
            ffmpegPathBtn = new Button();
            ffmpegPathTextbox = new TextBox();
            label3 = new Label();
            groupBox2 = new GroupBox();
            showSysNotifCheck = new CheckBox();
            applyBtn = new Button();
            cancelBtn = new Button();
            okBtn = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            groupBox1.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 29);
            label1.Name = "label1";
            label1.Size = new Size(107, 20);
            label1.TabIndex = 0;
            label1.Text = "Ścieżka zapisu:";
            // 
            // downloadDirTextBox
            // 
            downloadDirTextBox.Location = new Point(156, 26);
            downloadDirTextBox.Name = "downloadDirTextBox";
            downloadDirTextBox.ReadOnly = true;
            downloadDirTextBox.Size = new Size(337, 27);
            downloadDirTextBox.TabIndex = 1;
            // 
            // browseDownloadsBtn
            // 
            browseDownloadsBtn.Location = new Point(499, 24);
            browseDownloadsBtn.Name = "browseDownloadsBtn";
            browseDownloadsBtn.Size = new Size(94, 29);
            browseDownloadsBtn.TabIndex = 2;
            browseDownloadsBtn.Text = "Przeglądaj";
            browseDownloadsBtn.UseVisualStyleBackColor = true;
            browseDownloadsBtn.Click += browseDownloadsBtn_Click;
            // 
            // browseYTDLBtn
            // 
            browseYTDLBtn.Location = new Point(499, 57);
            browseYTDLBtn.Name = "browseYTDLBtn";
            browseYTDLBtn.Size = new Size(94, 29);
            browseYTDLBtn.TabIndex = 5;
            browseYTDLBtn.Text = "Przeglądaj";
            browseYTDLBtn.UseVisualStyleBackColor = true;
            browseYTDLBtn.Click += browseYTDLBtn_Click;
            // 
            // YTDLTextBox
            // 
            YTDLTextBox.Location = new Point(156, 59);
            YTDLTextBox.Name = "YTDLTextBox";
            YTDLTextBox.ReadOnly = true;
            YTDLTextBox.Size = new Size(337, 27);
            YTDLTextBox.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 62);
            label2.Name = "label2";
            label2.Size = new Size(138, 20);
            label2.TabIndex = 3;
            label2.Text = "Ścieżka youtube-dl:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(groupBox4);
            groupBox1.Controls.Add(groupBox3);
            groupBox1.Controls.Add(ffmpegPathBtn);
            groupBox1.Controls.Add(ffmpegPathTextbox);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(downloadDirTextBox);
            groupBox1.Controls.Add(browseYTDLBtn);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(YTDLTextBox);
            groupBox1.Controls.Add(browseDownloadsBtn);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(599, 412);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ogólne";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(autoDownloadBox);
            groupBox4.Location = new Point(12, 280);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(581, 125);
            groupBox4.TabIndex = 14;
            groupBox4.TabStop = false;
            groupBox4.Text = "Po dodaniu URL do kolejki:";
            // 
            // autoDownloadBox
            // 
            autoDownloadBox.AutoSize = true;
            autoDownloadBox.Location = new Point(10, 26);
            autoDownloadBox.Name = "autoDownloadBox";
            autoDownloadBox.Size = new Size(255, 24);
            autoDownloadBox.TabIndex = 0;
            autoDownloadBox.Text = "Zacznij pobieranie automatycznie";
            autoDownloadBox.UseVisualStyleBackColor = true;
            autoDownloadBox.CheckedChanged += autoDownloadBox_CheckedChanged;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(minimizeToTrayBox);
            groupBox3.Controls.Add(showInTrayBox);
            groupBox3.Controls.Add(closeToTrayBox);
            groupBox3.Location = new Point(12, 126);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(581, 86);
            groupBox3.TabIndex = 13;
            groupBox3.TabStop = false;
            // 
            // minimizeToTrayBox
            // 
            minimizeToTrayBox.AutoSize = true;
            minimizeToTrayBox.Location = new Point(10, 60);
            minimizeToTrayBox.Name = "minimizeToTrayBox";
            minimizeToTrayBox.Size = new Size(282, 24);
            minimizeToTrayBox.TabIndex = 13;
            minimizeToTrayBox.Text = "Minimalizuj do obszaru powiadomień";
            minimizeToTrayBox.UseVisualStyleBackColor = true;
            minimizeToTrayBox.CheckedChanged += minimizeToTrayBox_CheckedChanged;
            // 
            // showInTrayBox
            // 
            showInTrayBox.AutoSize = true;
            showInTrayBox.Location = new Point(6, 0);
            showInTrayBox.Name = "showInTrayBox";
            showInTrayBox.Size = new Size(316, 24);
            showInTrayBox.TabIndex = 0;
            showInTrayBox.Text = "Wyświetlaj ikonę w obszarze powiadomień";
            showInTrayBox.UseVisualStyleBackColor = true;
            showInTrayBox.CheckedChanged += showInTrayBox_CheckedChanged;
            // 
            // closeToTrayBox
            // 
            closeToTrayBox.AutoSize = true;
            closeToTrayBox.Location = new Point(10, 30);
            closeToTrayBox.Name = "closeToTrayBox";
            closeToTrayBox.Size = new Size(261, 24);
            closeToTrayBox.TabIndex = 12;
            closeToTrayBox.Text = "Zamykaj do obszaru powiadomień\r\n";
            closeToTrayBox.UseVisualStyleBackColor = true;
            closeToTrayBox.CheckedChanged += closeToTrayBox_CheckedChanged;
            // 
            // ffmpegPathBtn
            // 
            ffmpegPathBtn.Location = new Point(499, 90);
            ffmpegPathBtn.Name = "ffmpegPathBtn";
            ffmpegPathBtn.Size = new Size(94, 29);
            ffmpegPathBtn.TabIndex = 11;
            ffmpegPathBtn.Text = "Przeglądaj";
            ffmpegPathBtn.UseVisualStyleBackColor = true;
            ffmpegPathBtn.Click += ffmpegPathBtn_Click;
            // 
            // ffmpegPathTextbox
            // 
            ffmpegPathTextbox.Location = new Point(156, 92);
            ffmpegPathTextbox.Name = "ffmpegPathTextbox";
            ffmpegPathTextbox.ReadOnly = true;
            ffmpegPathTextbox.Size = new Size(337, 27);
            ffmpegPathTextbox.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 95);
            label3.Name = "label3";
            label3.Size = new Size(140, 20);
            label3.TabIndex = 9;
            label3.Text = "Ścieżka ffmpeg.exe:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(showSysNotifCheck);
            groupBox2.Location = new Point(12, 218);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(581, 56);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "Po ukończeniu pobierania:";
            // 
            // showSysNotifCheck
            // 
            showSysNotifCheck.AutoSize = true;
            showSysNotifCheck.Location = new Point(10, 26);
            showSysNotifCheck.Name = "showSysNotifCheck";
            showSysNotifCheck.Size = new Size(177, 24);
            showSysNotifCheck.TabIndex = 7;
            showSysNotifCheck.Text = "Pokaż powiadomienie";
            showSysNotifCheck.UseVisualStyleBackColor = true;
            showSysNotifCheck.CheckedChanged += showSysNotifCheck_CheckedChanged;
            // 
            // applyBtn
            // 
            applyBtn.Enabled = false;
            applyBtn.Location = new Point(519, 448);
            applyBtn.Name = "applyBtn";
            applyBtn.Size = new Size(94, 29);
            applyBtn.TabIndex = 7;
            applyBtn.Text = "Zastosuj";
            applyBtn.UseVisualStyleBackColor = true;
            applyBtn.Click += applyBtn_Click;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(419, 448);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(94, 29);
            cancelBtn.TabIndex = 8;
            cancelBtn.Text = "Anuluj";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // okBtn
            // 
            okBtn.Location = new Point(319, 448);
            okBtn.Name = "okBtn";
            okBtn.Size = new Size(94, 29);
            okBtn.TabIndex = 9;
            okBtn.Text = "OK";
            okBtn.UseVisualStyleBackColor = true;
            okBtn.Click += okBtn_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Add(groupBox1);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(12, 12);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(608, 430);
            flowLayoutPanel1.TabIndex = 10;
            // 
            // Preferences
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(625, 489);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(okBtn);
            Controls.Add(cancelBtn);
            Controls.Add(applyBtn);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Preferences";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Preferencje";
            Load += Preferences_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private TextBox downloadDirTextBox;
        private Button browseDownloadsBtn;
        private Button browseYTDLBtn;
        private TextBox YTDLTextBox;
        private Label label2;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private CheckBox showSysNotifCheck;
        private Button applyBtn;
        private Button cancelBtn;
        private Button okBtn;
        private Button ffmpegPathBtn;
        private TextBox ffmpegPathTextbox;
        private Label label3;
        private CheckBox closeToTrayBox;
        private GroupBox groupBox3;
        private CheckBox showInTrayBox;
        private CheckBox minimizeToTrayBox;
        private FlowLayoutPanel flowLayoutPanel1;
        private GroupBox groupBox4;
        private CheckBox autoDownloadBox;
    }
}