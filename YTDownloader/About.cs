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

        readonly string[] LICENSES =
        {
            "Json.NET (NewtonSoft) (MIT)",
            "YoutubeExtractor (Dennis Daume) (GPL 2.0)"
        };

        private void githubLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo psInfo = new ProcessStartInfo
            {
                FileName = "https://github.com/SolidnyWonsz",
                UseShellExecute = true
            };
            Process.Start(psInfo);
        }

        private void About_Load(object sender, EventArgs e)
        {
            foreach (string s in LICENSES)
            {
                licensesLabel.Text += s + "\n";
            }
        }
    }
}
