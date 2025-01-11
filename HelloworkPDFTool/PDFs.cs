using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spire.Pdf;
using Spire.Pdf.Texts;
using Spire.Pdf.Widget;
using CsvHelper;
using CsvHelper.Configuration;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Globalization;

namespace HelloworkPDFTool
{
    /// <summary>
    /// The list and process methods of PDF
    /// </summary>
    ///
    public class PDFs
    {
        /// <summary>
        /// List of PDF paths
        /// </summary>
        public List<string> filePaths;

        /// <summary>
        /// Rect positions of pdf string
        /// </summary>
        private PdfTextExtractOptions optionsPosition;
        private PdfTextExtractOptions optionsDetails;
        private PdfTextExtractOptions optionsNum;
        private PdfTextExtractOptions optionsStart;
        private PdfTextExtractOptions optionsExpire;

        /// <summary>
        /// Data cache for writing spreadsheet
        /// </summary>
        private List<HWData> hwds;

        /// <summary>
        /// Initalization
        /// </summary>
        public PDFs()
        {
            filePaths = new List<string>();
            hwds = new List<HWData>();

            optionsPosition = new PdfTextExtractOptions();
            optionsDetails = new PdfTextExtractOptions();
            optionsNum = new PdfTextExtractOptions();
            optionsStart = new PdfTextExtractOptions();
            optionsExpire = new PdfTextExtractOptions();

            optionsPosition.ExtractArea = new Rectangle(30, 250, 260, 30);
            optionsDetails.ExtractArea = new Rectangle(30, 270, 260, 120);
            optionsNum.ExtractArea = new Rectangle(0, 50, 200, 10);
            optionsStart.ExtractArea = new Rectangle(300, 0, 100, 40);
            optionsExpire.ExtractArea = new Rectangle(450, 0, 100, 40);
        }

        /// <summary>
        /// Save all datas to Spreadsheet
        /// </summary>
        public string Export(string fileName,ToolStripProgressBar tsp)
        {
            if(filePaths.Count > 0)
            {
                //Clear HWD Data
                hwds.Clear();

                //Read pdfs
                ReadPDFs();

                //Write to the file
                WriteSheet(fileName, tsp);

                return "ファイル書き出しに成功しました。";
            }
            else
            {
                return "PDFリストが空です。ファイルを追加してください。";
            }

        }

        private bool ReadPDFs()
        {
            foreach(string path in filePaths)
            {
                //Read each pdf file
                PdfDocument pdf = new PdfDocument();
                pdf.LoadFromFile(path);

                //Check whether the file is Hello Work-compatible or not
                if(pdf.Pages.Count >= 2)
                {
                    PdfPageBase page = pdf.Pages[0];
                    PdfTextExtractor extractor = new PdfTextExtractor(page);
                    HWData hwd;

                    string p = FormatText(extractor.ExtractText(optionsPosition));
                    string d = FormatText(extractor.ExtractText(optionsDetails));
                    string n = FormatText(extractor.ExtractText(optionsNum));
                    string s = FormatText(extractor.ExtractText(optionsStart));
                    string e = FormatText(extractor.ExtractText(optionsExpire));

                    hwd = new HWData { position = p, details = d, number = n, start = s, expire = e };
                    hwds.Add(hwd);
                }
                else
                {
                    Console.WriteLine("Skipped.");
                    Console.WriteLine();
                }

                pdf.Close();
            }

            return true;
        }

        private bool WriteSheet(string path, ToolStripProgressBar tsp)
        {
            //Set properties of progress bar
            tsp.Maximum = Program.pdfs.filePaths.Count;

            using (StreamWriter sw = new StreamWriter(path))
            using (CsvWriter csv = new CsvWriter(sw,CultureInfo.InvariantCulture))
            {
                //Initialize CsvWriter
                csv.Context.RegisterClassMap<HWDataMap>();

                //Write records
                int i = 0;
                foreach (HWData hwd in hwds)
                {
                    tsp.Value = i;
                    csv.WriteRecord(hwd);
                    i++;
                }
            }

            //Reset TSP
            tsp.Value = 0;

            return true;
        }

        private string FormatText(string str)
        {
            string nStr = str.Trim();
            nStr = nStr.Replace(" ", "");

            return nStr;
        }

    }
    public class HWData
    {
        public string position { get; set; }
        public string details { get; set; }
        public string number { get; set; }
        public string start { get; set; }
        public string expire { get; set; }

    }

    public class HWDataMap : ClassMap<HWData>
    {
        public HWDataMap()
        {
            Map(m => m.position);
            Map(m => m.details);
            Map(m => m.number);
            Map(m => m.start);
            Map(m => m.expire);
        }
    }
}
