using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloworkPDFTool
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Initalization
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        private void AddFile(string path)
        {
            //Add files to PDFs
            Program.pdfs.filePaths.Add(path);

            //Add files to listBox
            listBoxPDFs.Items.Add(path);
        }

        /// <summary>
        /// Load PDF File(s) from drag and drop
        /// </summary>
        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                //Get datas from data
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                Console.WriteLine(files);

                //Filter files
                foreach(string file in files)
                {
                    //Check the file is pdf or not
                    if(Path.GetExtension(file).ToLower() == ".pdf")
                    {
                        AddFile(file);
                    }
                }
            }
        }

        /// <summary>
        /// Open File(s)
        /// </summary>
        private void buttonOpenFile_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Generate SpreadSheet
        /// </summary>
        private void buttonGenerate_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Open Settings form
        /// </summary>
        private void buttonSettings_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Set cursor icon
        /// </summary>
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                //Drag and drop is available
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                //else
                e.Effect = DragDropEffects.None;
            }
        }
    }
}
