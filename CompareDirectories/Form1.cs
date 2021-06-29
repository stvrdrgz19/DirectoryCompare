﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompareDirectories
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static bool canModifyDup = true;
        public static bool canModifyMissing = true;

        /// <summary>
        /// Retrieves a list of files from a directory
        /// </summary>
        /// <param name="directory">The directory to get a list of files from</param>
        /// <param name="searchSubDir">Boolean to determine whether or not to search subdirectories</param>
        /// <returns>Returns a list of files from a directory</returns>
        private static string[] GetFileList(string directory, bool searchSubDir)
        {
            if (searchSubDir)
            {
                var dllList = Directory.GetFiles(directory, "*", SearchOption.AllDirectories).Select(file => Path.GetFileName(file));
                return dllList.ToArray();
            }
            else
            {
                var dllList = Directory.GetFiles(directory, "*").Select(file => Path.GetFileName(file));
                return dllList.ToArray();
            }
        }

        /// <summary>
        /// Lets the user select a folder to compare files from
        /// </summary>
        /// <param name="existingPath">If there was an existing path, this will be used as the starting location for the folder select</param>
        /// <returns>The selected folder path</returns>
        private static string GetPath(string existingPath)
        {
            using (FolderBrowserDialog selectedFolder = new FolderBrowserDialog())
            {
                if (Directory.Exists(existingPath))
                {
                    selectedFolder.SelectedPath = existingPath;
                }
                else
                {
                    selectedFolder.SelectedPath = @"C:\";
                }
                if (selectedFolder.ShowDialog() == DialogResult.OK)
                {
                    return selectedFolder.SelectedPath;
                }
                else
                {
                    return String.Empty;
                }
            }
        }

        private void BtnPopulateList_Click(object sender, EventArgs e)
        {
            lvCompare.Items.Clear();
            tbCompareCount.Text = "0 Files";
            string dirOne = tbDirectoryOne.Text;
            string dirTwo = tbDirectoryTwo.Text;
            bool searchSubDir = cbSubDir.Checked;
            //  MAKE SURE THE PROVIDED PATHS ARE VALID/EXIST
            if (String.IsNullOrWhiteSpace(dirOne) || String.IsNullOrWhiteSpace(dirTwo))
            {
                MessageBox.Show("Please enter a first directory to compare.");
                lbDirOne.Items.Clear();
                return;
            }
            if (String.IsNullOrWhiteSpace(dirTwo))
            {
                MessageBox.Show("Please enter a second directory to compare");
                lbDirTwo.Items.Clear();
                return;
            }
            if (dirOne == "Enter/Select Directory 1...")
            {
                MessageBox.Show("Please enter a directory to compare.");
                lbDirOne.Items.Clear();
                return;
            }
            if (dirTwo == "Enter/Select Directory 2...")
            {
                MessageBox.Show("Please enter a directory to compare.");
                lbDirTwo.Items.Clear();
                return;
            }
            if (!Directory.Exists(dirOne))
            {
                MessageBox.Show("The following directory doesn't exist:\n\n" + dirOne);
                lbDirOne.Items.Clear();
                return;
            }
            if (!Directory.Exists(dirTwo))
            {
                MessageBox.Show("The following directory doesn't exist:\n\n" + dirTwo);
                lbDirTwo.Items.Clear();
                return;
            }

            //  ADD FILES FROM DIRECTORIES TO THEIR RESPECTIVE LISTBOXES
            //  INCREMENT FILE COUNT
            lbDirOne.Items.Clear();
            lbDirTwo.Items.Clear();
            lbDirOne.Items.AddRange(GetFileList(dirOne, searchSubDir));
            lbDirTwo.Items.AddRange(GetFileList(dirTwo, searchSubDir));
            tbCountDirOne.Text = lbDirOne.Items.Count.ToString() + " files";
            tbCountDirTwo.Text = lbDirTwo.Items.Count.ToString() + " files";

            //  CREATE LISTS TO STORE ITEMS THAT DON'T EXIST IN THE OTHER DIRECTORY
            List<string> dirOneList = new List<string>();
            List<string> dirTwoList = new List<string>();
            //  FIND ITEMS THAT DON'T EXIST IN THE OTHER DIRECTORY
            if (cbFindMissingFiles.Checked)
            {
                foreach (var listBoxItem in lbDirOne.Items)
                {
                    if (!lbDirTwo.Items.Contains(listBoxItem))
                    {
                        dirOneList.Add(listBoxItem.ToString());
                    }
                }
                foreach (var listBoxItem in lbDirTwo.Items)
                {
                    if (!lbDirOne.Items.Contains(listBoxItem))
                    {
                        dirTwoList.Add(listBoxItem.ToString());
                    }
                }
                lvCompare.Items.Clear();
                tbCompareCount.Text = "0 Files";
                foreach (string file in dirOneList)
                {
                    ListViewItem item = new ListViewItem(file);
                    item.SubItems.Add(dirTwo);
                    lvCompare.Items.Add(item);
                }
                foreach (string file in dirTwoList)
                {
                    ListViewItem item = new ListViewItem(file);
                    item.SubItems.Add(dirOne);
                    lvCompare.Items.Add(item);
                }
            }

            if (cbFindDuplicates.Checked)
            {
                foreach (var listBoxItem in lbDirOne.Items)
                {
                    if (lbDirTwo.Items.Contains(listBoxItem))
                    {
                        dirOneList.Add(listBoxItem.ToString());
                    }
                }
                foreach (var listBoxItem in lbDirTwo.Items)
                {
                    if (lbDirOne.Items.Contains(listBoxItem))
                    {
                        dirTwoList.Add(listBoxItem.ToString());
                    }
                }
                lvCompare.Items.Clear();
                tbCompareCount.Text = "0 Files";
                var combinedList = dirOneList.Concat(dirTwoList).Distinct().ToList();
                foreach (string file in combinedList)
                {
                    ListViewItem item = new ListViewItem(file);
                    lvCompare.Items.Add(item);
                }
            }
            tbCompareCount.Text = lvCompare.Items.Count.ToString() + " files";
            return;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //tbDirectoryOne.Text = @"C:\Program Files (x86)\SalesPad.Desktop\Release\5.2.7";
            //tbDirectoryTwo.Text = @"C:\Program Files (x86)\SalesPad.Desktop\master\5.2.8.13";
        }

        private void BtnDirectoryOne_Click(object sender, EventArgs e)
        {
            string dirOne = GetPath(tbDirectoryOne.Text);
            bool searchSubDir = cbSubDir.Checked;
            if (String.IsNullOrEmpty(dirOne))
            {
                return;
            }
            tbDirectoryOne.Text = dirOne;
            lbDirOne.Items.Clear();
            lbDirOne.Items.AddRange(GetFileList(dirOne, searchSubDir));
            tbCountDirOne.Text = lbDirOne.Items.Count.ToString() + " files";
            lvCompare.Items.Clear();
            tbCompareCount.Text = "0 Files";
            return;
        }

        private void BtnDirectoryTwo_Click(object sender, EventArgs e)
        {
            string dirTwo = GetPath(tbDirectoryTwo.Text);
            bool searchSubDir = cbSubDir.Checked;
            if (String.IsNullOrEmpty(dirTwo))
            {
                return;
            }
            tbDirectoryTwo.Text = dirTwo;
            lbDirTwo.Items.Clear();
            lbDirTwo.Items.AddRange(GetFileList(dirTwo, searchSubDir));
            tbCountDirTwo.Text = lbDirTwo.Items.Count.ToString() + " files";
            lvCompare.Items.Clear();
            tbCompareCount.Text = "0 Files";
            return;
        }

        private void CbFindMissingFiles_CheckedChanged(object sender, EventArgs e)
        {
            canModifyDup = false;
            if (canModifyMissing)
            {
                cbFindMissingFiles.Checked = true;
                cbFindDuplicates.Checked = false;
                lvCompare.Columns[0].Width = 398;
                ColumnHeader colHeaderX = new ColumnHeader();
                colHeaderX.Name = "Not Found In";
                colHeaderX.Width = 375;
                colHeaderX.TextAlign = HorizontalAlignment.Left;
                colHeaderX.Text = "Not Found In";
                this.lvCompare.Columns.Add(colHeaderX);
                lvCompare.Columns[1].Width = 375;
                lvCompare.Items.Clear();
                lvCompare.Refresh();
            }
            canModifyDup = true;
            return;
        }

        private void CbFindDuplicates_CheckedChanged(object sender, EventArgs e)
        {
            canModifyMissing = false;
            if (canModifyDup)
            {
                cbFindDuplicates.Checked = true;
                cbFindMissingFiles.Checked = false;
                //===============================================================
                //  Gotta remove the column "twice"
                //  Quotes because it's different methods of removing
                //  I think it's because I have a default set initially
                //  When when re-adding it's using a different method
                //      Fix is TODO
                var removeCol = lvCompare.Columns["Not Found In"];
                lvCompare.Columns.Remove(removeCol);
                lvCompare.Columns.Remove(chNotInColumn);
                //===============================================================
                lvCompare.Columns[0].Width = 773;
                lvCompare.Items.Clear();
            }
            canModifyMissing = true;
            return;
        }

        private void BtnCopySelected_Click(object sender, EventArgs e)
        {
            List<string> selectedFileList = new List<string>();
            if (lvCompare.SelectedItems.Count <= 0)
            {
                return;
            }
            foreach (ListViewItem item in lvCompare.SelectedItems)
            {
                selectedFileList.Add(item.SubItems[0].Text);
            }
            string result = string.Join("\n", selectedFileList);
            Clipboard.SetText(result);
            if (lvCompare.SelectedItems.Count > 10)
            {
                MessageBox.Show("All of the selected files were copied to the clipboard.");
                return;
            }
            MessageBox.Show("The following file names were copied to the clipboard:\n\n" + result);
            return;
        }

        private void BtnCopyAll_Click(object sender, EventArgs e)
        {
            List<string> files = new List<string>();
            if (lvCompare.Items.Count <= 0)
            {
                return;
            }
            foreach (ListViewItem item in lvCompare.Items)
            {
                files.Add(item.SubItems[0].Text);
            }
            string result = string.Join("\n", files);
            Clipboard.SetText(result);
            if (lvCompare.Items.Count > 10)
            {
                MessageBox.Show("All of the selected files were copied to the clipboard.");
                return;
            }
            MessageBox.Show("The following file names were copied to the clipboard:\n\n" + result);
            return;
        }
    }
}
