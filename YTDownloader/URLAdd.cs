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
    public partial class URLAdd : Form
    {
        public string URL { get; set; }
        public string FileName { get; set; }
        public string FileExt { get; set; }
        public URLAdd()
        {
            InitializeComponent();
        }

        private void addUrlBtn_Click(object sender, EventArgs e)
        {
            if (urlTextBox.Text == string.Empty)
            {
                MessageBox.Show("Proszę podać URL.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                URL = urlTextBox.Text;
                FileName = fileNameBox.Text;
                FileExt = fileExtBox.Text;
                this.DialogResult = DialogResult.OK;

                if (Program.defaultFileExt != FileExt)
                {
                    Program.defaultFileExt = FileExt;
                }
                this.Close();
            }
        }

        private void URLAdd_Load(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                string text = Clipboard.GetText();
                if (Uri.IsWellFormedUriString(text, UriKind.Absolute))
                {
                    urlTextBox.Text = text;
                }
            }

            fileExtBox.SelectedItem = Program.defaultFileExt;
        }
    }
}
