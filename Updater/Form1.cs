using System.Diagnostics;
using System.IO.Compression;

namespace Updater
{
    public partial class Form1 : Form
    {
        int pid;
        public Form1(int pid)
        {
            InitializeComponent();
            this.pid = pid;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            statusLabel.Text = "Pobieranie nowej wersji programu";
            await downloadUpdate("http://api.github.com/repos/SolidnyWonsz/YTDownloader/releases/latest");

            statusLabel.Text = "Czekanie na zakoñczenie programu";
            await waitForExit();

            statusLabel.Text = "Rozpakowywanie pliku aktualizacyjnego";
            await unzip();

            Directory.Delete("temp", true);
            statusLabel.Text = "Zakoñczono pomyœlnie!";
            MessageBox.Show("Zakoñczono aktualizacje.", "Aktualizacja");
            Process.Start("YTDownloader.exe");
        }

        async Task downloadUpdate(string url)
        {
            using (HttpClient http = new HttpClient())
            {
                try
                {
                    using HttpResponseMessage response = await http.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    using (Stream stream = await response.Content.ReadAsStreamAsync())
                    {
                        Directory.CreateDirectory("temp");
                        var fileStream = new FileStream("temp/update.zip", FileMode.OpenOrCreate, FileAccess.Write);
                        stream.CopyTo(fileStream);
                        fileStream.Close();
                    }
                }
                catch (HttpRequestException e)
                {
                    MessageBox.Show($"B³¹d podczas pobierania pliku aktualizacji!\n{e}", "Aktualizacja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        async Task waitForExit()
        {
            try
            {
                await Process.GetProcessById(pid).WaitForExitAsync();
            }
            catch
            {
                return;
            }
        }
        
        async Task unzip()
        {
            if (!File.Exists("temp/update.zip"))
            {
                MessageBox.Show("Plik aktualizacji nie istnieje!", "Aktualizacja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
            }

            try
            {
                ZipFile.ExtractToDirectory("temp/update.zip", ".", true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wyst¹pi³ b³¹d podczas wypakowywania!\n{ex}", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
            }
        }
    }
}
