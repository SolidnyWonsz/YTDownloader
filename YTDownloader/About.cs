using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace YTDownloader
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void githubLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo psInfo = new ProcessStartInfo
            {
                FileName = "https://github.com/SolidnyWonsz/YTDownloader",
                UseShellExecute = true
            };
            Process.Start(psInfo);
        }

        private void About_Load(object sender, EventArgs e)
        {
            descriptionLbl.Text = $"YTDownloader {Program.version}\r\n\r\nProsty i szybki menedżer pobierania filmów i utworów z serwisu Youtube.\r\n\r\nCopyright SolidnyWonsz 2025-2026";
        }
    }
}
