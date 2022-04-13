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

namespace LINQToFileDirectory
{
    public partial class LINQToFileDirectoryForm : Form
    {
        // store extensions found, and number of each extension found
        Dictionary<string, int> found = new Dictionary<string, int>();

        public LINQToFileDirectoryForm()
        {
            InitializeComponent();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            // check whether user specified path exists
            if (!string.IsNullOrEmpty(pathTextBox.Text) &&
               !Directory.Exists(pathTextBox.Text))
            {
                // show error if user does not specify valid directory
                MessageBox.Show("Invalid Directory", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // directory to search; if not specified use current directory
                string currentDirectory =
                    (!string.IsNullOrEmpty(pathTextBox.Text)) ?
                        pathTextBox.Text : Directory.GetCurrentDirectory();

                directoryTextBox.Text = currentDirectory; // show directory

                // clear TextBoxes
                pathTextBox.Clear();
                resultsTextBox.Clear();

                SearchDirectory(currentDirectory); // search the directory

                // allow user to delete .bak files
                CleanDirectory(currentDirectory);

                // allow user to delete .bak files
                foreach (var current in found.Keys)
                {
                    // display the number of files with current extension
                    resultsTextBox.AppendText(
                        $"* Found {found[current]} {current} files." +
                            Environment.NewLine);
                }

                found.Clear(); // clear results for new search
            }

        }

        // search directory using LINQ
        private void SearchDirectory(string folder)
        {
            // files contained in the directory
            string[] files = Directory.GetFiles(folder);

            // subdirectories in the directory
            string[] directories = Directory.GetDirectories(folder);

            // find all file extensions in this directory
            var extensions =
                from file in files
                group file by Path.GetExtension(file);

            foreach (var extension in extensions)
            {
                if (found.ContainsKey(extension.Key))
                {
                    found[extension.Key] += extension.Count();  // update count
                }
                else
                {
                    found[extension.Key] = extension.Count();  // add count
                }
            }

            // recursive call to search subdirectories
            foreach (var subdirectory in directories)
            {
                SearchDirectory(subdirectory);
            }
        }

        // allow user to delete backup files (.bak)
        private void CleanDirectory(string folder)
        {
            // files contained in the directory
            string[] files = Directory.GetFiles(folder);

            // subdirectories in the directory
            string[] directories = Directory.GetDirectories(folder);

            // select all the backup files in this directory
            var backupFiles =
                from file in files
                where Path.GetExtension(file) == ".bak"
                select file;

            // iterate over all backup files (.bak)
            foreach (var backup in backupFiles)
            {
                DialogResult result = MessageBox.Show($"Found backup file {Path.GetFileName(backup)}. Delete?",
                    "Delete Backup", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                
                // delete file if user clicked 'yes'
                if (result == DialogResult.Yes)
                {
                    File.Delete(backup);
                    --found[".bak"]; // decrement count in Dictionary

                    // if there are no .bak files, delete key from Dictionary
                    if (found[".bak"] == 0)
                    {
                        found.Remove(".bak");
                    }
                }
            }

            // recursive call to clean subdirectories
            foreach (var subdirectory in directories)
            {
                CleanDirectory(subdirectory);
            }
        }
    }
}
