namespace YTDownloader
{
    partial class URLAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(URLAdd));
            urlTextBox = new TextBox();
            addUrlBtn = new Button();
            fileNameBox = new TextBox();
            fileExtBox = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // urlTextBox
            // 
            resources.ApplyResources(urlTextBox, "urlTextBox");
            urlTextBox.Name = "urlTextBox";
            // 
            // addUrlBtn
            // 
            resources.ApplyResources(addUrlBtn, "addUrlBtn");
            addUrlBtn.Name = "addUrlBtn";
            addUrlBtn.UseVisualStyleBackColor = true;
            addUrlBtn.Click += addUrlBtn_Click;
            // 
            // fileNameBox
            // 
            resources.ApplyResources(fileNameBox, "fileNameBox");
            fileNameBox.Name = "fileNameBox";
            // 
            // fileExtBox
            // 
            resources.ApplyResources(fileExtBox, "fileExtBox");
            fileExtBox.FormattingEnabled = true;
            fileExtBox.Items.AddRange(new object[] { resources.GetString("fileExtBox.Items"), resources.GetString("fileExtBox.Items1"), resources.GetString("fileExtBox.Items2"), resources.GetString("fileExtBox.Items3"), resources.GetString("fileExtBox.Items4"), resources.GetString("fileExtBox.Items5"), resources.GetString("fileExtBox.Items6"), resources.GetString("fileExtBox.Items7") });
            fileExtBox.Name = "fileExtBox";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // URLAdd
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(fileExtBox);
            Controls.Add(fileNameBox);
            Controls.Add(addUrlBtn);
            Controls.Add(urlTextBox);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "URLAdd";
            ShowIcon = false;
            ShowInTaskbar = false;
            Load += URLAdd_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox urlTextBox;
        private Button addUrlBtn;
        private TextBox fileNameBox;
        private ComboBox fileExtBox;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}