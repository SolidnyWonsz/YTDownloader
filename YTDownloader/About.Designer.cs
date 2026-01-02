namespace YTDownloader
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            aboutSoftware = new TabPage();
            githubLink = new LinkLabel();
            descriptionLbl = new Label();
            tabControl1 = new TabControl();
            aboutSoftware.SuspendLayout();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // aboutSoftware
            // 
            resources.ApplyResources(aboutSoftware, "aboutSoftware");
            aboutSoftware.Controls.Add(githubLink);
            aboutSoftware.Controls.Add(descriptionLbl);
            aboutSoftware.Name = "aboutSoftware";
            aboutSoftware.UseVisualStyleBackColor = true;
            // 
            // githubLink
            // 
            resources.ApplyResources(githubLink, "githubLink");
            githubLink.Name = "githubLink";
            githubLink.TabStop = true;
            githubLink.UseCompatibleTextRendering = true;
            githubLink.LinkClicked += githubLink_LinkClicked;
            // 
            // descriptionLbl
            // 
            resources.ApplyResources(descriptionLbl, "descriptionLbl");
            descriptionLbl.Name = "descriptionLbl";
            // 
            // tabControl1
            // 
            resources.ApplyResources(tabControl1, "tabControl1");
            tabControl1.Controls.Add(aboutSoftware);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            // 
            // About
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabControl1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "About";
            ShowIcon = false;
            ShowInTaskbar = false;
            Load += About_Load;
            aboutSoftware.ResumeLayout(false);
            aboutSoftware.PerformLayout();
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabPage aboutSoftware;
        private LinkLabel githubLink;
        private Label descriptionLbl;
        private TabControl tabControl1;
    }
}