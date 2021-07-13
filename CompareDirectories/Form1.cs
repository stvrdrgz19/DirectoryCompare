using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

        private bool canModifyDup = true;
        private bool canModifyMissing = true;
        private bool filterString = true;
        private bool filterFile = true;
        public static char filterReplacementChar = '#';

        /// <summary>
        /// Retrieves a list of files from a directory
        /// </summary>
        /// <param name="directory">The directory to get a list of files from</param>
        /// <param name="searchSubDir">Boolean to determine whether or not to search subdirectories</param>
        /// <returns>Returns a list of files from a directory</returns>
        private static string[] GetFileList(string directory, bool searchSubDir, string filter, bool filterText)
        {
            int filterCharCount = filter.Count();
            string replaceString = "";
            for (int i = filterCharCount; i > 0; i--)
            {
                replaceString += "#";
            }
            if (searchSubDir)
            {
                if (filterText)
                {
                    var dllList = Directory.GetFiles(directory, "*", SearchOption.AllDirectories).Select(file => Path.GetFileName(file.Replace(filter, replaceString)));
                    return dllList.ToArray();
                }
                else
                {
                    var dllList = Directory.GetFiles(directory, "*", SearchOption.AllDirectories).Where(file => !file.Contains(filter)).Select(file => Path.GetFileName(file));
                    return dllList.ToArray();
                }
            }
            else
            {
                if (filterText)
                {
                    var dllList = Directory.GetFiles(directory, "*").Select(file => Path.GetFileName(file.Replace(filter, replaceString)));
                    return dllList.ToArray();
                }
                else
                {
                    var dllList = Directory.GetFiles(directory, "*").Where(file => !file.Contains(filter)).Select(file => Path.GetFileName(file));
                    return dllList.ToArray();
                }
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

        /// <summary>
        /// Adds columns to the lvCompare listview
        /// </summary>
        /// <param name="name">The name of the column header</param>
        /// <param name="text">The text to display as the column header</param>
        /// <param name="width">Width of the added column</param>
        /// <param name="alignment">Alignment of the text eg. HorizontalAlignment.Left</param>
        /// <returns>returns the information needed to add a column</returns>
        private static ColumnHeader AddColumn(string name, string text, int width, HorizontalAlignment alignment)
        {
            //object initializer syntax
            //syntatic sugar
            return new ColumnHeader()
            {
                Name = name,
                Text = text,
                Width = width,
                TextAlign = alignment
            };
        }

        private void RunCompare(string dirOne, string dirTwo)
        {
            lvCompare.Items.Clear();
            tbCompareCount.Text = "0 Files";
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
            lbDirOne.Items.Clear();
            lbDirTwo.Items.Clear();
            lbDirOne.Items.AddRange(GetFileList(dirOne, searchSubDir, tbDirOneFilter.Text, cbFilterText.Checked));
            lbDirTwo.Items.AddRange(GetFileList(dirTwo, searchSubDir, tbDirTwoFilter.Text, cbFilterText.Checked));
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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tbDirectoryOne.Text = @"C:\Program Files (x86)\SalesPad.Desktop\Release\5.2.7";
            tbDirectoryTwo.Text = @"C:\Program Files (x86)\SalesPad.Desktop\master\5.2.8.13";
            lvCompare.Columns.Add(AddColumn("chFileName", "File Name", 398, HorizontalAlignment.Left));
            lvCompare.Columns.Add(AddColumn("chNotInColumn", "Not Found In", 375, HorizontalAlignment.Left));
        }

        private void CbFindMissingFiles_CheckedChanged(object sender, EventArgs e)
        {
            canModifyDup = false;
            if (canModifyMissing)
            {
                cbFindMissingFiles.Checked = true;
                cbFindDuplicates.Checked = false;
                lvCompare.Columns[0].Width = 398;
                if (lvCompare.Columns.Count == 1)
                {
                    lvCompare.Columns.Add(AddColumn("chNotInColumn", "Not Found In", 375, HorizontalAlignment.Left));
                }
                lvCompare.Items.Clear();
                RunCompare(tbDirectoryOne.Text, tbDirectoryTwo.Text);
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
                var removeCol = lvCompare.Columns["chNotInColumn"];
                lvCompare.Columns.Remove(removeCol);
                lvCompare.Columns[0].Width = 773;
                lvCompare.Items.Clear();
                RunCompare(tbDirectoryOne.Text, tbDirectoryTwo.Text);
            }
            canModifyMissing = true;
            return;
        }

        private void CbFilterText_CheckedChanged(object sender, EventArgs e)
        {
            filterFile = false;
            if (filterString)
            {
                cbFilterText.Checked = true;
                cbFilterFile.Checked = false;
            }
            filterFile = true;
            return;
        }

        private void CbFilterFile_CheckedChanged(object sender, EventArgs e)
        {
            filterString = false;
            if (filterFile)
            {
                cbFilterFile.Checked = true;
                cbFilterText.Checked = false;
            }
            filterString = true;
            return;
        }

        private void BtnPopulateList_Click(object sender, EventArgs e)
        {
            RunCompare(tbDirectoryOne.Text, tbDirectoryTwo.Text);
            return;
        }

        private void BtnDirectoryOne_Click(object sender, EventArgs e)
        {
            string input = tbDirectoryOne.Text;
            if (Control.ModifierKeys == Keys.Shift)
            {
                if (Directory.Exists(input))
                {
                    Process.Start(input);
                }
                return;
            }
            string dirOne = GetPath(input);
            bool searchSubDir = cbSubDir.Checked;
            if (String.IsNullOrEmpty(dirOne))
            {
                return;
            }
            tbDirectoryOne.Text = dirOne;
            lbDirOne.Items.Clear();
            lbDirOne.Items.AddRange(GetFileList(dirOne, searchSubDir, tbDirOneFilter.Text, cbFilterText.Checked));
            tbCountDirOne.Text = lbDirOne.Items.Count.ToString() + " files";
            lvCompare.Items.Clear();
            tbCompareCount.Text = "0 Files";
            return;
        }

        private void BtnDirectoryTwo_Click(object sender, EventArgs e)
        {
            string input = tbDirectoryTwo.Text;
            if (Control.ModifierKeys == Keys.Shift)
            {
                if (Directory.Exists(input))
                {
                    Process.Start(input);
                }
                return;
            }
            string dirTwo = GetPath(input);
            bool searchSubDir = cbSubDir.Checked;
            if (String.IsNullOrEmpty(dirTwo))
            {
                return;
            }
            tbDirectoryTwo.Text = dirTwo;
            lbDirTwo.Items.Clear();
            lbDirTwo.Items.AddRange(GetFileList(dirTwo, searchSubDir, tbDirTwoFilter.Text, cbFilterText.Checked));
            tbCountDirTwo.Text = lbDirTwo.Items.Count.ToString() + " files";
            lvCompare.Items.Clear();
            tbCompareCount.Text = "0 Files";
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
