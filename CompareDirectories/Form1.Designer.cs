namespace CompareDirectories
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tbDirectoryOne = new System.Windows.Forms.TextBox();
            this.btnDirectoryOne = new System.Windows.Forms.Button();
            this.btnDirectoryTwo = new System.Windows.Forms.Button();
            this.tbDirectoryTwo = new System.Windows.Forms.TextBox();
            this.lbDirOne = new System.Windows.Forms.ListBox();
            this.lbDirTwo = new System.Windows.Forms.ListBox();
            this.lvCompare = new System.Windows.Forms.ListView();
            this.btnPopulateList = new System.Windows.Forms.Button();
            this.tbCountDirOne = new System.Windows.Forms.TextBox();
            this.tbCountDirTwo = new System.Windows.Forms.TextBox();
            this.tbCompareCount = new System.Windows.Forms.TextBox();
            this.cbFindMissingFiles = new System.Windows.Forms.CheckBox();
            this.cbFindDuplicates = new System.Windows.Forms.CheckBox();
            this.btnCopySelected = new System.Windows.Forms.Button();
            this.btnCopyAll = new System.Windows.Forms.Button();
            this.cbSubDir = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // tbDirectoryOne
            // 
            this.tbDirectoryOne.Location = new System.Drawing.Point(2, 27);
            this.tbDirectoryOne.Name = "tbDirectoryOne";
            this.tbDirectoryOne.Size = new System.Drawing.Size(773, 20);
            this.tbDirectoryOne.TabIndex = 0;
            this.tbDirectoryOne.Text = "Enter/Select Directory 1...";
            // 
            // btnDirectoryOne
            // 
            this.btnDirectoryOne.Image = ((System.Drawing.Image)(resources.GetObject("btnDirectoryOne.Image")));
            this.btnDirectoryOne.Location = new System.Drawing.Point(776, 26);
            this.btnDirectoryOne.Name = "btnDirectoryOne";
            this.btnDirectoryOne.Size = new System.Drawing.Size(23, 22);
            this.btnDirectoryOne.TabIndex = 1;
            this.btnDirectoryOne.UseVisualStyleBackColor = true;
            this.btnDirectoryOne.Click += new System.EventHandler(this.BtnDirectoryOne_Click);
            // 
            // btnDirectoryTwo
            // 
            this.btnDirectoryTwo.Image = ((System.Drawing.Image)(resources.GetObject("btnDirectoryTwo.Image")));
            this.btnDirectoryTwo.Location = new System.Drawing.Point(776, 48);
            this.btnDirectoryTwo.Name = "btnDirectoryTwo";
            this.btnDirectoryTwo.Size = new System.Drawing.Size(23, 22);
            this.btnDirectoryTwo.TabIndex = 3;
            this.btnDirectoryTwo.UseVisualStyleBackColor = true;
            this.btnDirectoryTwo.Click += new System.EventHandler(this.BtnDirectoryTwo_Click);
            // 
            // tbDirectoryTwo
            // 
            this.tbDirectoryTwo.Location = new System.Drawing.Point(2, 49);
            this.tbDirectoryTwo.Name = "tbDirectoryTwo";
            this.tbDirectoryTwo.Size = new System.Drawing.Size(773, 20);
            this.tbDirectoryTwo.TabIndex = 2;
            this.tbDirectoryTwo.Text = "Enter/Select Directory 2...";
            // 
            // lbDirOne
            // 
            this.lbDirOne.FormattingEnabled = true;
            this.lbDirOne.Location = new System.Drawing.Point(2, 95);
            this.lbDirOne.Name = "lbDirOne";
            this.lbDirOne.Size = new System.Drawing.Size(397, 199);
            this.lbDirOne.TabIndex = 4;
            // 
            // lbDirTwo
            // 
            this.lbDirTwo.FormattingEnabled = true;
            this.lbDirTwo.Location = new System.Drawing.Point(401, 95);
            this.lbDirTwo.Name = "lbDirTwo";
            this.lbDirTwo.Size = new System.Drawing.Size(397, 199);
            this.lbDirTwo.TabIndex = 5;
            // 
            // lvCompare
            // 
            this.lvCompare.FullRowSelect = true;
            this.lvCompare.GridLines = true;
            this.lvCompare.HideSelection = false;
            this.lvCompare.Location = new System.Drawing.Point(2, 320);
            this.lvCompare.Name = "lvCompare";
            this.lvCompare.Size = new System.Drawing.Size(796, 175);
            this.lvCompare.TabIndex = 6;
            this.lvCompare.UseCompatibleStateImageBehavior = false;
            this.lvCompare.View = System.Windows.Forms.View.Details;
            // 
            // btnPopulateList
            // 
            this.btnPopulateList.Location = new System.Drawing.Point(347, 496);
            this.btnPopulateList.Name = "btnPopulateList";
            this.btnPopulateList.Size = new System.Drawing.Size(107, 23);
            this.btnPopulateList.TabIndex = 7;
            this.btnPopulateList.Text = "Compare Lists";
            this.btnPopulateList.UseVisualStyleBackColor = true;
            this.btnPopulateList.Click += new System.EventHandler(this.BtnPopulateList_Click);
            // 
            // tbCountDirOne
            // 
            this.tbCountDirOne.Location = new System.Drawing.Point(150, 73);
            this.tbCountDirOne.Name = "tbCountDirOne";
            this.tbCountDirOne.ReadOnly = true;
            this.tbCountDirOne.Size = new System.Drawing.Size(100, 20);
            this.tbCountDirOne.TabIndex = 9;
            this.tbCountDirOne.Text = "0 Files";
            this.tbCountDirOne.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbCountDirTwo
            // 
            this.tbCountDirTwo.Location = new System.Drawing.Point(549, 73);
            this.tbCountDirTwo.Name = "tbCountDirTwo";
            this.tbCountDirTwo.ReadOnly = true;
            this.tbCountDirTwo.Size = new System.Drawing.Size(100, 20);
            this.tbCountDirTwo.TabIndex = 10;
            this.tbCountDirTwo.Text = "0 Files";
            this.tbCountDirTwo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbCompareCount
            // 
            this.tbCompareCount.Location = new System.Drawing.Point(350, 298);
            this.tbCompareCount.Name = "tbCompareCount";
            this.tbCompareCount.ReadOnly = true;
            this.tbCompareCount.Size = new System.Drawing.Size(100, 20);
            this.tbCompareCount.TabIndex = 11;
            this.tbCompareCount.Text = "0 Files";
            this.tbCompareCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbFindMissingFiles
            // 
            this.cbFindMissingFiles.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbFindMissingFiles.AutoSize = true;
            this.cbFindMissingFiles.Checked = true;
            this.cbFindMissingFiles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFindMissingFiles.Location = new System.Drawing.Point(1, 1);
            this.cbFindMissingFiles.Name = "cbFindMissingFiles";
            this.cbFindMissingFiles.Size = new System.Drawing.Size(75, 23);
            this.cbFindMissingFiles.TabIndex = 12;
            this.cbFindMissingFiles.Text = "Find Missing";
            this.cbFindMissingFiles.UseVisualStyleBackColor = true;
            this.cbFindMissingFiles.CheckedChanged += new System.EventHandler(this.CbFindMissingFiles_CheckedChanged);
            // 
            // cbFindDuplicates
            // 
            this.cbFindDuplicates.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbFindDuplicates.AutoSize = true;
            this.cbFindDuplicates.Location = new System.Drawing.Point(78, 1);
            this.cbFindDuplicates.Name = "cbFindDuplicates";
            this.cbFindDuplicates.Size = new System.Drawing.Size(90, 23);
            this.cbFindDuplicates.TabIndex = 13;
            this.cbFindDuplicates.Text = "Find Duplicates";
            this.cbFindDuplicates.UseVisualStyleBackColor = true;
            this.cbFindDuplicates.CheckedChanged += new System.EventHandler(this.CbFindDuplicates_CheckedChanged);
            // 
            // btnCopySelected
            // 
            this.btnCopySelected.Location = new System.Drawing.Point(2, 496);
            this.btnCopySelected.Name = "btnCopySelected";
            this.btnCopySelected.Size = new System.Drawing.Size(100, 23);
            this.btnCopySelected.TabIndex = 14;
            this.btnCopySelected.Text = "Copy Selected";
            this.btnCopySelected.UseVisualStyleBackColor = true;
            this.btnCopySelected.Click += new System.EventHandler(this.BtnCopySelected_Click);
            // 
            // btnCopyAll
            // 
            this.btnCopyAll.Location = new System.Drawing.Point(104, 496);
            this.btnCopyAll.Name = "btnCopyAll";
            this.btnCopyAll.Size = new System.Drawing.Size(100, 23);
            this.btnCopyAll.TabIndex = 15;
            this.btnCopyAll.Text = "Copy All";
            this.btnCopyAll.UseVisualStyleBackColor = true;
            this.btnCopyAll.Click += new System.EventHandler(this.BtnCopyAll_Click);
            // 
            // cbSubDir
            // 
            this.cbSubDir.AutoSize = true;
            this.cbSubDir.Checked = true;
            this.cbSubDir.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSubDir.Location = new System.Drawing.Point(175, 5);
            this.cbSubDir.Name = "cbSubDir";
            this.cbSubDir.Size = new System.Drawing.Size(131, 17);
            this.cbSubDir.TabIndex = 16;
            this.cbSubDir.Text = "Include Subdirectories";
            this.cbSubDir.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 521);
            this.Controls.Add(this.cbSubDir);
            this.Controls.Add(this.btnCopyAll);
            this.Controls.Add(this.btnCopySelected);
            this.Controls.Add(this.cbFindDuplicates);
            this.Controls.Add(this.cbFindMissingFiles);
            this.Controls.Add(this.tbCompareCount);
            this.Controls.Add(this.tbCountDirTwo);
            this.Controls.Add(this.tbCountDirOne);
            this.Controls.Add(this.btnPopulateList);
            this.Controls.Add(this.lvCompare);
            this.Controls.Add(this.lbDirTwo);
            this.Controls.Add(this.lbDirOne);
            this.Controls.Add(this.btnDirectoryTwo);
            this.Controls.Add(this.tbDirectoryTwo);
            this.Controls.Add(this.btnDirectoryOne);
            this.Controls.Add(this.tbDirectoryOne);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Directory Compare";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbDirectoryOne;
        private System.Windows.Forms.Button btnDirectoryOne;
        private System.Windows.Forms.Button btnDirectoryTwo;
        private System.Windows.Forms.TextBox tbDirectoryTwo;
        private System.Windows.Forms.ListBox lbDirOne;
        private System.Windows.Forms.ListBox lbDirTwo;
        private System.Windows.Forms.ListView lvCompare;
        private System.Windows.Forms.Button btnPopulateList;
        private System.Windows.Forms.TextBox tbCountDirOne;
        private System.Windows.Forms.TextBox tbCountDirTwo;
        private System.Windows.Forms.TextBox tbCompareCount;
        private System.Windows.Forms.CheckBox cbFindMissingFiles;
        private System.Windows.Forms.CheckBox cbFindDuplicates;
        private System.Windows.Forms.Button btnCopySelected;
        private System.Windows.Forms.Button btnCopyAll;
        private System.Windows.Forms.CheckBox cbSubDir;
    }
}

