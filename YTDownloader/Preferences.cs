using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YTDownloader
{
    public partial class Preferences : Form
    {
        public Preferences()
        {
            InitializeComponent();
        }

        bool _isDirty = false;
        bool isDirty
        {
            get => _isDirty;
            set
            {
                _isDirty = value;
                if (_isDirty)
                    applyBtn.Enabled = true;
            }
        }

        private void Preferences_Load(object sender, EventArgs e)
        {
            downloadDirTextBox.Text = Path.GetFullPath(Program.downloadsDir);
            YTDLTextBox.Text = Path.GetFullPath(Program.ytDL.YoutubeDLPath);
            ffmpegPathTextbox.Text = Path.GetFullPath(Program.ytDL.FFmpegPath);
            showSysNotifCheck.Checked = Program.showSysNotif;
            closeToTrayBox.Checked = Program.closeToTray;
            minimizeToTrayBox.Checked = Program.minimizeToTray;
            showInTrayBox.Checked = Program.showTrayIcon;

            applyBtn.Enabled = false;
            minimizeToTrayBox.Enabled = showInTrayBox.Checked;
            closeToTrayBox.Enabled = showInTrayBox.Checked;
        }

        private void browseDownloadsBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new();
            dialog.InitialDirectory = Directory.GetCurrentDirectory();
            var result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string folder = dialog.SelectedPath;
                downloadDirTextBox.Text = folder;

                isDirty = true;
            }
        }

        private void browseYTDLBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new();
            dialog.Filter = "YT-DLP|yt-dlp.exe|All files|*.*";
            dialog.InitialDirectory = Directory.GetCurrentDirectory();
            var result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string file = dialog.FileName;
                YTDLTextBox.Text = file;

                isDirty = true;
            }
        }

        private void showSysNotifCheck_CheckedChanged(object sender, EventArgs e)
        {
            isDirty = true;
        }

        private void applyBtn_Click(object sender, EventArgs e)
        {
            apply();
        }

        void apply()
        {
            Program.downloadsDir = downloadDirTextBox.Text;
            Program.showSysNotif = showSysNotifCheck.Checked;
            Program.closeToTray = closeToTrayBox.Checked;
            Program.minimizeToTray = minimizeToTrayBox.Checked;
            Program.showTrayIcon = showInTrayBox.Checked;
            Program.SaveConfig();
            Program.ytDL.YoutubeDLPath = YTDLTextBox.Text;
            Program.ytDL.FFmpegPath = ffmpegPathTextbox.Text;
            isDirty = false;
            applyBtn.Enabled = false;

            Program.notifyIcon.Visible = Program.showTrayIcon;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            if (isDirty)
            {
                var result = MessageBox.Show("Masz niezapisane zmiany. Czy na pewno chcesz anulować?", "Uwaga!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                    Close();
            }
            else
                Close();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            apply();
            Close();
        }

        private void ffmpegPathBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new();
            dialog.Filter = "ffmpeg.exe|ffmpeg.exe|All files|*.*";
            dialog.InitialDirectory = Directory.GetCurrentDirectory();
            var result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string file = dialog.FileName;
                ffmpegPathTextbox.Text = file;

                isDirty = true;
            }
        }

        private void closeToTrayBox_CheckedChanged(object sender, EventArgs e)
        {
            isDirty = true;
        }

        private void showInTrayBox_CheckedChanged(object sender, EventArgs e)
        {
            isDirty = true;

            minimizeToTrayBox.Enabled = showInTrayBox.Checked;
            closeToTrayBox.Enabled = showInTrayBox.Checked;
        }

        private void minimizeToTrayBox_CheckedChanged(object sender, EventArgs e)
        {
            isDirty = true;
        }
    }
}
