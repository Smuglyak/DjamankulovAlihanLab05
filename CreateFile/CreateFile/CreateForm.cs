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

namespace CreateFile
{
    public partial class CreateFileForm : BankUIForm
    {
        private StreamWriter fileWriter; // writes data to text file

        public CreateFileForm()
        {
            InitializeComponent();
        }

        // event handler for Save Button
        private void saveButton_Click(object sender, EventArgs e)
        {
            // create and show dialog box enabling user to save file
            DialogResult result; // result of SaveFileDialog
            string fileName; // name of file containing data

            using (var fileChooser = new SaveFileDialog())
            {
                fileChooser.CheckFileExists = false; // let user create file 
                result = fileChooser.ShowDialog();
                fileName = fileChooser.FileName;  // name of file to save data
            }

            // ensure that user clicked "OK"
            if (result == DialogResult.OK)
            {
                // show error if user specified invalid file
                if (string.IsNullOrEmpty(fileName))
                {
                    MessageBox.Show("Invalid File Name", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // save file via FileStream 
                    try
                    {
                        // open file with write access
                        var output = new FileStream(fileName,
                            FileMode.OpenOrCreate, FileAccess.Write);

                        // sets file to where data is written
                        fileWriter = new StreamWriter(output);

                        // disable Save button and enable Enter button
                        saveButton.Enabled = false;
                        enterButton.Enabled = true;
                    }
                    catch (IOException)
                    {
                        // notify user if file does not exist
                        MessageBox.Show("Error opening file", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            // store TextBox values string array
            String[] values = GetTextBoxValues();

            // determine whether TextBox account field is empty
            if (!string.IsNullOrEmpty(values[(int)TextBoxIndices.Account]))
            {
                // store TextBox values in Record and output it
                try
                {
                    // get account-number value from TextBox
                    int accountNumber =
                        int.Parse(values[(int)TextBoxIndices.Account]);

                    // determine whether accountNumber is valid
                    if (accountNumber > 0)
                    {
                        // Record containing TextBox values to output
                        var record = new Record(accountNumber,
                            values[(int)TextBoxIndices.First],
                            values[(int)TextBoxIndices.Last],
                            decimal.Parse(values[(int)TextBoxIndices.Balance]));

                        // write Record to file, fields separated by commas
                        fileWriter.WriteLine(
                            $"{record.Account},{record.FirstName}," +
                            $"{record.LastName},{record.Balance}");
                    }
                    else
                    {
                        // notify user if invalid account number
                        MessageBox.Show("Invalid Account Number", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (IOException)
                {
                    MessageBox.Show("Error Writing to File", "Error",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Invalid Format", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            ClearTextBoxes(); // clear TextBox values
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            try
            {
                fileWriter?.Close(); // close StreamWriter and underlying file

            }
            catch (IOException)
            {
                MessageBox.Show("Cannot close file", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Application.Exit();
        }

        private void CreateFileForm_Load(object sender, EventArgs e)
        {

        }
    }
}
