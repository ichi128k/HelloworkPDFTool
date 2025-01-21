using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloworkPDFTool
{
    internal static class Program
    {
        public static PDFs pdfs;

        public static Settings settings;

        public const int maxFileCount = 50;

        public const int maxFieldCont = 10;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Initialize
            pdfs = new PDFs();

            //Initialize Settings
            settings = new Settings();

            if(!settings.LoadSettings())
            {
                //If setting file has not been opened correctly(File is not exist, etc.),
                //Set settings values to factory settings
                settings.LoadFactorySettings();
            }

            //Launch Application
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
