namespace HelloworkPDFTool
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxPDFs = new System.Windows.Forms.ListBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.buttonOpenFile = new System.Windows.Forms.Button();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonImport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxPDFs
            // 
            this.listBoxPDFs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxPDFs.FormattingEnabled = true;
            this.listBoxPDFs.ItemHeight = 12;
            this.listBoxPDFs.Location = new System.Drawing.Point(0, 0);
            this.listBoxPDFs.Name = "listBoxPDFs";
            this.listBoxPDFs.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxPDFs.Size = new System.Drawing.Size(815, 419);
            this.listBoxPDFs.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.buttonImport);
            this.splitContainer1.Panel1.Controls.Add(this.buttonClear);
            this.splitContainer1.Panel1.Controls.Add(this.buttonRemove);
            this.splitContainer1.Panel1.Controls.Add(this.buttonGenerate);
            this.splitContainer1.Panel1.Controls.Add(this.buttonSettings);
            this.splitContainer1.Panel1.Controls.Add(this.buttonOpenFile);
            this.splitContainer1.Panel1MinSize = 64;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listBoxPDFs);
            this.splitContainer1.Size = new System.Drawing.Size(815, 487);
            this.splitContainer1.SplitterDistance = 64;
            this.splitContainer1.TabIndex = 1;
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.Location = new System.Drawing.Point(0, 0);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(124, 64);
            this.buttonOpenFile.TabIndex = 0;
            this.buttonOpenFile.Text = "ファイルの選択\r\nもしくは\r\nここに\r\nドラッグアンドドロップ";
            this.buttonOpenFile.UseVisualStyleBackColor = true;
            this.buttonOpenFile.Click += new System.EventHandler(this.buttonOpenFile_Click);
            // 
            // buttonSettings
            // 
            this.buttonSettings.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonSettings.Location = new System.Drawing.Point(691, 0);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(124, 64);
            this.buttonSettings.TabIndex = 1;
            this.buttonSettings.Text = "設定";
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Location = new System.Drawing.Point(130, 0);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(124, 64);
            this.buttonGenerate.TabIndex = 2;
            this.buttonGenerate.Text = "生成して保存";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(260, 0);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(124, 64);
            this.buttonRemove.TabIndex = 3;
            this.buttonRemove.Text = "選択項目を削除";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(390, 0);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(124, 64);
            this.buttonClear.TabIndex = 4;
            this.buttonClear.Text = "リストの初期化";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonImport
            // 
            this.buttonImport.Location = new System.Drawing.Point(520, 0);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(124, 64);
            this.buttonImport.TabIndex = 5;
            this.buttonImport.Text = "CSVからインポート";
            this.buttonImport.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 487);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxPDFs;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button buttonOpenFile;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonImport;
    }
}

