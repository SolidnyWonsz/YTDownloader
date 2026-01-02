using System.Diagnostics;
using System.Net;
using YoutubeDLSharp;
using Microsoft.Win32;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace YTDownloader
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            using (Mutex mutex = new Mutex(true, "YTDownloader_Instance", out bool first))
            {
                if (!first)
                {
                    return;
                }

                checkAppData();
                LoadConfig();
                ytDL.OutputFolder = downloadsDir;
                ApplicationConfiguration.Initialize();
                checkForDefaultDownloadsDir();
                Application.Run(new YTDownloader());
            }
        }

        static void checkForDefaultDownloadsDir()
        {
            if (!Directory.Exists(downloadsDir))
            {
                Directory.CreateDirectory(downloadsDir);
            }
        }

        public static readonly string appData = 
            Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "YTDownloader"
        );
        static void checkAppData()
        {
            if (!Directory.Exists(appData))
            {
                Directory.CreateDirectory(appData);
            }
        }

        public static string downloadsDir = Path.Combine(Directory.GetCurrentDirectory(), "downloads");
        public static string defaultFileExt = "MP3";
        public static bool showSysNotif = true;
        public static bool showTrayIcon = true;
        public static bool closeToTray = true;
        public static bool minimizeToTray = false;
        public static bool autoDownload = true;
        public static bool checkUpdateDaily = true;
        public static string version = "1.4";
        public static bool firstBoot = true;

        public static NotifyIcon notifyIcon = null;

        public static YoutubeDL ytDL = new YoutubeDL
        {
            YoutubeDLPath = Path.Combine(Directory.GetCurrentDirectory(), "yt-dlp.exe"),
            FFmpegPath = Path.Combine(Directory.GetCurrentDirectory(), "ffmpeg.exe"),
            OutputFolder = downloadsDir
        };

        public static void LoadConfig()
        {
            var path = Path.Combine(appData, "config.json");
            if (!File.Exists(path))
            {
                SaveConfig();
                return;
            }

            string s = File.ReadAllText(path);
            try
            {
                ConfigFile? json = JsonSerializer.Deserialize<ConfigFile>(s);
                downloadsDir = json.DownloadsDir;
                showSysNotif = json.showSysNotif;
                closeToTray = json.closeToTray;
                minimizeToTray = json.minimizeToTray;
                showTrayIcon = json.showTrayIcon;
                ytDL.YoutubeDLPath = json.YtDLPath;
                ytDL.FFmpegPath = json.FfmegPath;
                autoDownload = json.autoDownload;
                firstBoot = json.firstBoot;
            }
            catch (JsonException _)
            {

            }
        }

        public static void SaveConfig()
        {
            ConfigFile config = new();
            config.DownloadsDir = downloadsDir;
            config.showSysNotif = showSysNotif;
            config.closeToTray = closeToTray;
            config.minimizeToTray = minimizeToTray;
            config.showTrayIcon = showTrayIcon;
            config.YtDLPath = ytDL.YoutubeDLPath;
            config.FfmegPath = ytDL.FFmpegPath;
            config.autoDownload = autoDownload;
            config.firstBoot = firstBoot;

            string s = JsonSerializer.Serialize(config);
            using (var f = File.CreateText(Path.Combine(appData, "config.json")))
            {
                f.Write(s);
            }
        }

        public class ConfigFile
        {
            public string DownloadsDir { get; set; } = Program.downloadsDir;
            public string YtDLPath { get; set; }
            public string FfmegPath { get; set; }
            public bool showSysNotif { get; set; } = Program.showSysNotif;
            public bool closeToTray { get; set; } = Program.closeToTray;
            public bool minimizeToTray { get; set; } = Program.minimizeToTray;
            public bool showTrayIcon { get; set; } = Program.showTrayIcon;
            public bool autoDownload { get; set; } = true;
            public bool firstBoot { get; set; } = true;
        }
    }
}