using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;

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
        /// Initalization
        /// </summary>
        public PDFs()
        {
            filePaths = new List<string>();
        }

        /// <summary>
        /// Save all datas to Spreadsheet
        /// </summary>
        public string Export(string fileName)
        {
            if(filePaths.Count > 0)
            {
                //Read pdfs


                //Write to the file


                return "ファイル書き出しに成功しました。";
            }
            else
            {
                return "PDFリストが空です。ファイルを追加してください。";
            }

        }

    }
    public class HWData
    {

    }
}
