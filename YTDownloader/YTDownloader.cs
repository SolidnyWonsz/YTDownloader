using Microsoft.Toolkit.Uwp.Notifications;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.UI.Notifications;
using YoutubeDLSharp;
using YoutubeDLSharp.Options;

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

            ToastNotificationManagerCompat.OnActivated += toastNotif_Activated;

            if (Program.checkUpdateDaily) checkUpdate();
        }

        void checkUpdate()
        {
            var path = Path.Combine(Program.appData, "last-update.txt");
            if (File.Exists(path))
            {
                DateTime lastDate = DateTime.Parse(File.ReadAllText(path));
                if (lastDate.Date < DateTime.Now.Date)
                {
                    processUpdate();
                }
                File.WriteAllText(path, DateTime.Now.ToString());
            }
            else
            {
                File.WriteAllText(path, DateTime.Now.ToString());
                processUpdate();
            }
        }

        internal struct ProgramVer
        {
            public int major, minor;

            public static bool operator >(ProgramVer lhs, ProgramVer rhs)
            {
                return lhs.major > rhs.major && lhs.minor > rhs.minor;
            }

            public static bool operator <(ProgramVer lhs, ProgramVer rhs)
            {
                return lhs.major < rhs.major && lhs.minor < rhs.minor;
            }

            /// <summary>
            /// Zamienia wersje programu z tekstu na ProgramVer
            /// </summary>
            /// <param name="ver">Wersja w postaci tekstu</param>
            /// <returns>Nowy obiekt</returns>
            /// <exception cref="VersionFormatWrongException"></exception>
            public static ProgramVer FromString(string ver)
            {
                var str = ver.Split(".");
                return new ProgramVer { major = int.Parse(str[0]), minor = int.Parse(str[1]) };
            }
        }

        internal class VersionFormatWrongException : Exception
        {
            public VersionFormatWrongException() { }
            public VersionFormatWrongException(string message) : base(message) { }
        }

        async Task<int> processUpdate()
        {
            HttpClient http = new HttpClient();
            http.DefaultRequestHeaders.UserAgent.ParseAdd("request");
            using HttpResponseMessage response = await http.GetAsync("http://api.github.com/repos/SolidnyWonsz/YTDownloader/releases/latest");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(jsonResponse);
            JToken? tagName = json["tag_name"];

            try
            {
                ProgramVer currentVer = ProgramVer.FromString(Program.version);
                ProgramVer newVer = ProgramVer.FromString(tagName.ToString());
                if (currentVer < newVer)
                {
                    var result = MessageBox.Show("Dostêpna jest nowa aktualizacja dla programu. Zaktualizowaæ?", "Aktualizacja", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (result == DialogResult.Yes)
                    {
                        JToken? url = json["assets"]?[0]?["browser_download_url"];
                        try
                        {
                            Process.Start("Updater.exe", $"{Process.GetCurrentProcess().Id} {url?.ToString()}");
                            Environment.Exit(0);
                        }
                        catch (Exception ex)
                        {
                            if (ex is Win32Exception || ex is FileNotFoundException)
                                MessageBox.Show("Nie znaleziono programu aktualizacyjnego! Anulowanie procesu aktualizacji.", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }

                return -1;
            }
            catch (Exception e)
            {
                MessageBox.Show($"Wyst¹pi³ b³¹d podczas sprawdzania wersji programu\n{e}", "B³¹d podczas aktualizacji", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return -2;
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
            var video = res?.Data;

            if (video == null)
            {
                MessageBox.Show("Link prawdopodobnie jest nieprawid³owy.", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (urladd.FileName == string.Empty)
            {
                urladd.FileName = $"{video?.Uploader} - {video?.Title}";
            }
            else
            {
                urladd.FileName = formatSongName(video, urladd.FileName);
            }
            urladd.FileName = $"{urladd.FileName}.{urladd.FileExt.ToLower()}";

            if (File.Exists(Path.Combine(Program.downloadsDir, urladd.FileName)))
            {
                var result = MessageBox.Show($"Plik o nazwie {urladd.FileName} ju¿ istnieje.\nChcesz go nadpisaæ?", "Pobieranie", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Cancel)
                {
                    return;
                }
            }

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
                    result = await Program.ytDL.RunVideoDownload(file.FileURL, recodeFormat: VideoRecodeFormat.Mp4, overrideOptions: new OptionSet { Output = Path.Combine(Program.downloadsDir, file.FileName) });
                    break;
                case "MKV":
                    result = await Program.ytDL.RunVideoDownload(file.FileURL, recodeFormat: VideoRecodeFormat.Mkv, overrideOptions: new OptionSet { Output = Path.Combine(Program.downloadsDir, file.FileName) });
                    break;
                case "WEBM":
                    result = await Program.ytDL.RunVideoDownload(file.FileURL, recodeFormat: VideoRecodeFormat.Webm, overrideOptions: new OptionSet { Output = Path.Combine(Program.downloadsDir, file.FileName) });
                    break;
                case "WAV":
                    result = await Program.ytDL.RunAudioDownload(file.FileURL, YoutubeDLSharp.Options.AudioConversionFormat.Wav, overrideOptions: new OptionSet { Output = Path.Combine(Program.downloadsDir, file.FileName) });
                    break;
                case "FLAC":
                    result = await Program.ytDL.RunAudioDownload(file.FileURL, YoutubeDLSharp.Options.AudioConversionFormat.Flac, overrideOptions: new OptionSet { Output = Path.Combine(Program.downloadsDir, file.FileName) });
                    break;
                case "OGG":
                    result = await Program.ytDL.RunAudioDownload(file.FileURL, YoutubeDLSharp.Options.AudioConversionFormat.Vorbis, overrideOptions: new OptionSet { Output = Path.Combine(Program.downloadsDir, file.FileName) });
                    break;
                case "M4A":
                    result = await Program.ytDL.RunAudioDownload(file.FileURL, YoutubeDLSharp.Options.AudioConversionFormat.M4a, overrideOptions: new OptionSet { Output = Path.Combine(Program.downloadsDir, file.FileName) });
                    break;
                case "MP3":
                default:
                    result = await Program.ytDL.RunAudioDownload(file.FileURL, YoutubeDLSharp.Options.AudioConversionFormat.Mp3, overrideOptions: new OptionSet { Output = Path.Combine(Program.downloadsDir, file.FileName) });
                    break;
            }

            if (result.Success)
            {
                file.FileState = FileElement.States.Finished;
                if (Program.showSysNotif)
                    new ToastContentBuilder()
                        .AddText("Zakoñczono pobieranie pliku")
                        .AddText($"{file.FileName}")
                        .AddButton(new ToastButton()
                            .SetContent("Poka¿ plik")
                            .AddArgument("action", "viewFile")
                            .AddArgument("file", file.FileName))
                        .Show();
                startDownloadingFirstWaiting();
            }
        }

        void toastNotif_Activated(ToastNotificationActivatedEventArgsCompat toastArgs)
        {
            ToastArguments args = ToastArguments.Parse(toastArgs.Argument);
            var fileName = args["file"];
            Process.Start(new ProcessStartInfo
            {
                FileName = "explorer.exe",
                Arguments = $"/select,\"{Path.Combine(Program.downloadsDir, fileName)}\"",
                UseShellExecute = true
            });
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

        private async void checkUpdateBtn_Click(object sender, EventArgs e)
        {
            File.WriteAllText(Path.Combine(Program.appData, "last-update.txt"), DateTime.Now.ToString());
            int result = await processUpdate();
            if (result == -1)
            {
                MessageBox.Show("Nie znaleziono ¿adnej aktualizacji");
            }
        }

        private void manualBtn_Click(object sender, EventArgs e)
        {
            ProcessStartInfo psInfo = new ProcessStartInfo
            {
                FileName = "https://github.com/SolidnyWonsz/YTDownloader?tab=readme-ov-file#obs³uga",
                UseShellExecute = true
            };
            Process.Start(psInfo);
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
