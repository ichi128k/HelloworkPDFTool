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
using System.Diagnostics;

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
        /// 
        private List<PDFExtractSettingsAndPageNum> extractOptions;


        /// <summary>
        /// Data cache for writing spreadsheet
        /// </summary>
        private List<List<string>> temp;

        /// <summary>
        /// Initalization
        /// </summary>
        public PDFs()
        {
            filePaths = new List<string>();
            temp = new List<List<string>>();
            extractOptions = new List<PDFExtractSettingsAndPageNum>();
        }

        /// <summary>
        /// Save all datas to Spreadsheet
        /// </summary>
        public string Export(string fileName,ToolStripProgressBar tsp)
        {
            if(filePaths.Count > 0)
            {
                //Clear HWD Data
                temp.Clear();
                extractOptions.Clear();

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

        /// <summary>
        /// Read PDFs and write datas to hwds
        /// </summary>
        private bool ReadPDFs()
        {
            //Create extract options from Program.settings.hwFields
            foreach (HWField hwf in Program.settings.hwFields)
            {
                PDFExtractSettingsAndPageNum pesap = new PDFExtractSettingsAndPageNum();
                pesap.pageNum = hwf.pageNumber;
                pesap.option.ExtractArea = hwf.rect;

                extractOptions.Add(pesap);
            }

            foreach (string path in filePaths)
            {
                //Read each pdf file
                PdfDocument pdf = new PdfDocument();

                try 
                {
                    pdf.LoadFromFile(path);
                }
                catch (Exception e)
                {
                    MessageBox.Show(path + ": 読み込み失敗もしくはその他のエラーがが発生しました。");
                    pdf.Close();

                    continue;
                }

                //Check whether the file is Hello Work-compatible or not
                if (pdf.Pages.Count >= 2)
                {
                    PdfPageBase page0 = pdf.Pages[0];
                    PdfPageBase page1 = pdf.Pages[1];

                    PdfTextExtractor extractor0 = new PdfTextExtractor(page0);
                    PdfTextExtractor extractor1 = new PdfTextExtractor(page1);

                    List<string> tempField = new List<string>();

                    foreach(PDFExtractSettingsAndPageNum p in extractOptions)
                    {
                        string s = p.pageNum == 0 ? FormatText(extractor0.ExtractText(p.option)) : 
                            FormatText(extractor1.ExtractText(p.option));
                        
                        tempField.Add(s);
                    }

                    temp.Add(tempField);
                }
                else
                {

                }

                pdf.Close();
            }

            return true;
        }

        private bool WriteSheet(string path, ToolStripProgressBar tsp)
        {
            //Set properties of progress bar
            tsp.Maximum = temp.Count;

            using (StreamWriter sw = new StreamWriter(path))
            using (CsvWriter csv = new CsvWriter(sw, CultureInfo.InvariantCulture))
            {
                //Initialize CsvWriter

                //Add CSV header
                foreach (HWField hwf in Program.settings.hwFields)
                {
                    csv.WriteField(hwf.name);
                }
                csv.NextRecord();

                //Write records
                int i = 0;
                foreach (List<string> record in temp)
                {
                    tsp.Value = i;
                    foreach(string s in record)
                    {
                        csv.WriteField(s);
                    }

                    csv.NextRecord();

                    i++;
                }

                //Flush
                csv.Flush();
                sw.Flush();
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

    public class PDFExtractSettingsAndPageNum
    {
        public PdfTextExtractOptions option;
        public int pageNum;

        public PDFExtractSettingsAndPageNum()
        {
            option = new PdfTextExtractOptions();
            pageNum = 0;
        }
    }
}
