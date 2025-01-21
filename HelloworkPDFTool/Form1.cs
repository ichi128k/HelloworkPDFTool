using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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

        /// <summary>
        /// Add path name to each file lists
        /// </summary>
        private void AddFile(string path)
        {
            if(!Program.pdfs.filePaths.Contains(path))
            {
                //Remove files of PDFs
                Program.pdfs.filePaths.Add(path);

                //Remove files of listBox
                listBoxPDFs.Items.Add(path);
            }
        }

        /// <summary>
        /// Remove path name to each file lists
        /// </summary>
        private void RemoveFile(string path)
        {
            //Add files to PDFs
            Program.pdfs.filePaths.Remove(path);

            //Add files to listBox
            listBoxPDFs.Items.Remove(path);
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
                bool showMessage = false;

                //Filter files
                foreach(string file in files)
                {
                    //Check the extension of file and uniqueness
                    if (Path.GetExtension(file).ToLower() == ".pdf")
                    {
                        if (Program.pdfs.filePaths.Count < Program.maxFileCount)
                        {
                            AddFile(file);
                        }
                        else
                        {
                            showMessage = true;
                        }
                    }
                }

                //Show message
                if(showMessage)
                {
                    ShowMaxMessage();
                }
            }
        }

        /// <summary>
        /// Open File(s)
        /// </summary>
        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            //Create OpenFileDialog
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PDFファイル|*.pdf";
            ofd.Multiselect = true;
            ofd.CheckFileExists = true;

            //Check whether OFD has been opened or not
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                bool showMessage = false;

                //Add the path to each list
                foreach (string fileName in ofd.FileNames)
                {
                    if (Program.pdfs.filePaths.Count < Program.maxFileCount)
                    {
                        AddFile(fileName);
                    }
                    else
                    {
                        showMessage = true;
                    }
                }

                //Show message
                if (showMessage)
                {
                    ShowMaxMessage();
                }
            }

        }

        /// <summary>
        /// Generate SpreadSheet
        /// </summary>
        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSVファイル|*.csv";

            if(sfd.ShowDialog() == DialogResult.OK)
            {
                //Disable buttons
                SetAllButtonsState(false);

                //Save to SpreadSheet
                string message = Program.pdfs.Export(sfd.FileName,toolStripProgressBar1);
                MessageBox.Show(message);

                //Re-enable buttons
                SetAllButtonsState(true);

            }
        }

        /// <summary>
        /// Open Settings form
        /// </summary>
        private void buttonSettings_Click(object sender, EventArgs e)
        {
            SettingsForm sf = new SettingsForm();
            sf.ShowDialog();
        }

        /// <summary>
        /// Remove selected item
        /// </summary>
        private void buttonRemove_Click(object sender, EventArgs e)
        {
            //Remove an item
            if(listBoxPDFs.SelectedIndex != -1)
            {
                RemoveFile(listBoxPDFs.SelectedItem.ToString());
            }
        }

        /// <summary>
        /// Clear both lists
        /// </summary>
        private void buttonClear_Click(object sender, EventArgs e)
        {
            //Show dialog
            DialogResult result = MessageBox.Show("リストを初期化しますか?", "リストの初期化", MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if(result == DialogResult.Yes)
            {
                Program.pdfs.filePaths.Clear();
                listBoxPDFs.Items.Clear();
            }
        }

        /// <summary>
        /// Set cursor icon
        /// </summary>
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
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

        private void SetAllButtonsState(bool state)
        {
            buttonOpenFile.Enabled = state;
            buttonGenerate.Enabled = state;
            buttonRemove.Enabled = state;
            buttonClear.Enabled = state;
            buttonSettings.Enabled = state;
        }

        private void ShowMaxMessage()
        {
            MessageBox.Show("登録できる件数は最大" + Program.maxFileCount + "件までです。");
        }
    }
}
