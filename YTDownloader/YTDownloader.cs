using System;
using System.Windows.Forms;
using System.ComponentModel;
using YoutubeDLSharp;
using System.Threading.Tasks;
using Microsoft.Toolkit.Uwp.Notifications;
using YoutubeDLSharp.Options;
using System.Diagnostics;

namespace YTDownloader
{
    public partial class YTDownloader : Form
    {
        public BindingList<FileElement> downloadQueue = new();
        BindingSource bindingSource = new BindingSource();

        bool forceQuit = false;

        public YTDownloader()
        {
            InitializeComponent();
        }

        private void YTDownloader_Load(object sender, EventArgs e)
        {
            bindingSource.DataSource = downloadQueue;
            dataGridView1.DataSource = bindingSource;

            Program.notifyIcon = notifyIcon;

            if (!Program.showTrayIcon)
            {
                notifyIcon.Visible = false;
            }
        }

        private async void addUrlBtn_Click(object sender, EventArgs e)
        {
            URLAdd urladd = new();
            urladd.StartPosition = FormStartPosition.CenterParent;
            var result = urladd.ShowDialog();
            if (result == DialogResult.OK)
            {
                await addURL(urladd);
            }
        }

        async Task addURL(URLAdd urladd)
        {
            var res = await Program.ytDL.RunVideoDataFetch(urladd.URL);
            var video = res.Data;

            if (urladd.FileName == string.Empty)
            {
                urladd.FileName = $"{video.Uploader} - {video.Title}";
            }
            else
            {
                urladd.FileName = formatSongName(video, urladd.FileName);
            }
            urladd.FileName = $"{urladd.FileName}.{urladd.FileExt.ToLower()}";
            FileElement element = new FileElement
            {
                FileName = urladd.FileName,
                FileExt = urladd.FileExt,
                FileURL = urladd.URL,
                FileState = FileElement.States.Waiting
            };
            downloadQueue.Add(element);
            refreshList();

            if (Program.autoDownload)
            {
                await autoDownload(element);
            }
        }

        async Task autoDownload(FileElement file)
        {
            var tasks = downloadQueue
                        .Select(item => downloadURLAsync(file))
                        .ToList();

            await Task.WhenAll(tasks);
        }

        string formatSongName(YoutubeDLSharp.Metadata.VideoData video, string name)
        {
            var tokens = new Dictionary<string, Func<string>>
            {
                ["author"] = () => video.Uploader,
                ["title"] = () => video.Title,
                ["id"] = () => downloadQueue.Count.ToString()
            };

            foreach (var token in tokens)
            {
                name = name.Replace($"{{{token.Key}}}", token.Value());
            }

            return name;
        }

        void refreshList()
        {
            dataGridView1.Update();
        }

        private void quitBtn_Click(object sender, EventArgs e)
        {
            forceQuit = true;
            this.Close();
        }

        private void aboutBtn_Click(object sender, EventArgs e)
        {
            About about = new();
            about.ShowDialog();
        }

        async Task downloadURLAsync(FileElement file)
        {
            file.FileState = FileElement.States.Downloading;

            RunResult<string> result;
            switch (file.FileExt)
            {
                case "MP4":
                    result = await Program.ytDL.RunVideoDownload(file.FileURL, recodeFormat: VideoRecodeFormat.Mp4);
                    break;
                case "MKV":
                    result = await Program.ytDL.RunVideoDownload(file.FileURL, recodeFormat: VideoRecodeFormat.Mkv);
                    break;
                case "WEBM":
                    result = await Program.ytDL.RunVideoDownload(file.FileURL, recodeFormat: VideoRecodeFormat.Webm);
                    break;
                case "WAV":
                    result = await Program.ytDL.RunAudioDownload(file.FileURL, YoutubeDLSharp.Options.AudioConversionFormat.Wav);
                    break;
                case "FLAC":
                    result = await Program.ytDL.RunAudioDownload(file.FileURL, YoutubeDLSharp.Options.AudioConversionFormat.Flac);
                    break;
                case "OGG":
                    result = await Program.ytDL.RunAudioDownload(file.FileURL, YoutubeDLSharp.Options.AudioConversionFormat.Opus);
                    break;
                case "M4A":
                    result = await Program.ytDL.RunAudioDownload(file.FileURL, YoutubeDLSharp.Options.AudioConversionFormat.M4a);
                    break;
                case "MP3":
                default:
                    result = await Program.ytDL.RunAudioDownload(file.FileURL, YoutubeDLSharp.Options.AudioConversionFormat.Mp3);
                    break;
            }

            if (result.Success)
            {
                file.FileState = FileElement.States.Finished;
                if (Program.showSysNotif)
                    new ToastContentBuilder()
                        .AddText($"Pobrano {file.FileName}")
                        .Show();
                startDownloadingFirstWaiting();
            }
        }

        async void startDownloadingFirstWaiting()
        {
            if (downloadQueue.Count > 0)
            {
                FileElement? file = null;
                foreach (var f in downloadQueue)
                {
                    if (f.FileState == FileElement.States.InQueue)
                    {
                        file = f;
                        break;
                    }
                }

                if (file != null)
                {
                    var tasks = downloadQueue
                        .Select(item => downloadURLAsync(file))
                        .ToList();

                    await Task.WhenAll(tasks);
                }
            }
        }

        void addWaitingToQueue()
        {
            foreach (var f in downloadQueue)
            {
                if (f.FileState == FileElement.States.Waiting)
                {
                    f.FileState = FileElement.States.InQueue;
                }
            }
        }

        private async void downloadBtn_Click(object sender, EventArgs e)
        {
            addWaitingToQueue();
            startDownloadingFirstWaiting();
        }

        private void YTDownloader_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Program.closeToTray || forceQuit || !Program.showTrayIcon)
            {
                bool canCloseSafely = true;

                foreach (var file in downloadQueue)
                {
                    if (file.FileState == FileElement.States.Waiting || file.FileState == FileElement.States.Downloading)
                    {
                        canCloseSafely = false;
                        break;
                    }
                }

                if (!canCloseSafely)
                {
                    var result = MessageBox.Show("Niektóre pliki jeszcze oczekuj¹ pobrania lub siê pobieraj¹. Czy aby na pewno chcesz opuœciæ program?", "YTDownloader", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                    {
                        e.Cancel = true;
                        forceQuit = false;
                    }
                }
            }
            else
            {
                e.Cancel = true;
                toggleVisibility(false);
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            downloadQueue.Clear();
        }

        private void preferencesBtn_Click(object sender, EventArgs e)
        {
            Preferences pref = new();
            pref.ShowDialog();
        }

        private void otwórzFolderZapisuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Program.downloadsDir);
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            toggleVisibility(true);
        }

        void toggleVisibility(bool value)
        {
            if (value)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.BringToFront();
                notifyIconVisibility.Text = "Ukryj";
            }
            else
            {
                this.WindowState = FormWindowState.Minimized;
                this.Hide();
                notifyIconVisibility.Text = "Poka¿";
            }
        }

        private void notifyIconTerminate_Click(object sender, EventArgs e)
        {
            forceQuit = true;
            Close();
        }

        private void notifyIconVisibility_Click(object sender, EventArgs e)
        {
            toggleVisibility(!Visible);
        }

        private async void dodajURLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            URLAdd urladd = new();
            urladd.StartPosition = FormStartPosition.CenterScreen;
            var result = urladd.ShowDialog();
            if (result == DialogResult.OK)
            {
                await addURL(urladd);
            }
        }
    }

    public class FileElement : INotifyPropertyChanged
    {
        public string FileName { get; set; } = string.Empty;
        public string FileExt { get; set; } = string.Empty;
        public string FileURL { get; set; } = string.Empty;
        public enum States
        {
            Waiting,
            InQueue,
            Downloading,
            Finished,
            Error
        }

        States _fileState = States.Waiting;
        public States FileState
        {
            get => _fileState;
            set
            {
                if (_fileState == value) return;
                _fileState = value;
                OnPropertyChanged(nameof(FileState));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string prop) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
