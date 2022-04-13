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
using BankLibrary;

namespace ReadSequentialAccessFile
{
    public partial class ReadSequentialAccessFileForm : BankUIForm
    {
        private StreamReader fileReader; // reads data from a text file

        public ReadSequentialAccessFileForm()
        {
            InitializeComponent();
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            // create and show dialog box enabling user to open file 
            DialogResult result; // result of OpenFileDialog
            string fileName;  // name of file containing data

            using (OpenFileDialog fileChooser = new OpenFileDialog())
            {
                result = fileChooser.ShowDialog();
                fileName = fileChooser.FileName; // get specified name
            }

            // ensure that user clicked "OK"
            if (result == DialogResult.OK)
            {
                ClearTextBoxes();

                // show error if user specified invalid file
                if (string.IsNullOrEmpty(fileName))
                {
                    MessageBox.Show("Invalid File Name", "Error",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        // create FileStream to obtain read access to file
                        FileStream input = new FileStream(
                            fileName, FileMode.Open, FileAccess.Read);

                        // set file from where data is read
                        fileReader = new StreamReader(input);

                        openButton.Enabled = false; // disable Open File button
                        nextButton.Enabled = true; // enable Next Record button
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("Error reading from file",
                             "File Error", MessageBoxButtons.OK,
                             MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            try
            {
                // get next record available in file
                var inputRecord = fileReader.ReadLine();

                if (inputRecord != null)
                {
                    string[] inputFields = inputRecord.Split(',');

                    // copy string-array values to TextBox values
                    SetTextBoxValues(inputFields);
                }
                else
                {
                    // close StreamReader and underlying file
                    fileReader.Close();
                    openButton.Enabled = true; // enable Open File button
                    nextButton.Enabled = false; // disable Next Record button
                    ClearTextBoxes();

                    // notify user if no records in file
                    MessageBox.Show("No more records in file", string.Empty,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Error Reading from File", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
