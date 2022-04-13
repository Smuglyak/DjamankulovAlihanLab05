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

namespace FileTest
{
    public partial class FileTestForm : Form
    {
        public FileTestForm()
        {
            InitializeComponent();
        }

        private void inputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // determine whether user pressed Enter key
            if (e.KeyCode == Keys.Enter)
            {
                // get user - specified file or directory
                string fileName = inputTextBox.Text;

                /// get user-specified file or directory
                if (File.Exists(fileName))
                {
                    // get file's creation date, modification date, etc.
                    GetInformation(fileName);

                    // display file contents through StreamReader
                    try
                    {
                        // obtain reader and file contents
                        using (var stream = new StreamReader(fileName))
                        {
                            outputTextBox2.AppendText(stream.ReadToEnd());

                        }
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("Error reading from file",
                            "File Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                // determine whether fileName is a directory
                else if (Directory.Exists(fileName))
                {
                    // get directory's creation date, 
                    // modification date, etc.
                    GetInformation(fileName);

                    // obtain directory list of specified directory
                    string[] directoryList =
                        Directory.GetDirectories(fileName);

                    outputTextBox2.AppendText("Directory contents:\n");

                    // output directoryList contents
                    foreach (var directory in directoryList)
                    {
                        outputTextBox2.AppendText($"{directory}\n");
                    }
                }
                else
                {
                    // notify user that neither file nor directory exists
                    MessageBox.Show($"{inputTextBox.Text} does not exist", "File Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // get information on file or directory,
        // and output it to outputTextBox
        private void GetInformation(string fileName)
        {
            outputTextBox2.Clear();

            // output that file or directory exists
            outputTextBox2.AppendText($"{fileName} exists\n");

            // output when file or directory was created
            outputTextBox2.AppendText($"Created: {File.GetCreationTime(fileName)}\n"
                + Environment.NewLine);

            // output when file or directory was last modified
            outputTextBox2.AppendText($"Last modified: {File.GetCreationTime(fileName) }\n"
                + Environment.NewLine);

            // output when file or directory was last accessed
            outputTextBox2.AppendText($"Last accessed: {File.GetCreationTime(fileName)}\n"
                + Environment.NewLine);
        }

        private void outputTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void outputTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
