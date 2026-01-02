using System.Diagnostics;
using System.IO.Compression;

namespace Updater
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length != 2) return;

            int pid = Int32.Parse(args[0]);
            string url = args[1];

            if (pid == 0)
            {
                return;
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1(pid));
        }
    }
}