namespace Updater
{
    partial class Form1
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
            statusLabel = new Label();
            SuspendLayout();
            // 
            // statusLabel
            // 
            statusLabel.Location = new Point(12, 9);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(398, 117);
            statusLabel.TabIndex = 0;
            statusLabel.Text = "status";
            statusLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(422, 135);
            Controls.Add(statusLabel);
            MaximizeBox = false;
            Name = "Form1";
            ShowIcon = false;
            Text = "Updater";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Label statusLabel;
    }
}
