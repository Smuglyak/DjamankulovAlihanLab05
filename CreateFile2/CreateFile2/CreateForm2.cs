using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankLibrary;

namespace CreateFile2
{
    public partial class CreateFileForm2 : BankUIForm
    {
        // object for serializing RecordSerializables in binary format
        private BinaryFormatter formatter = new BinaryFormatter();
        private FileStream output; // stream for writing to a file

        public CreateFileForm2()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            // create and show dialog box enabling user to save file
            DialogResult result; // result of SaveFileDialog
            string fileName; // name of file containing data

            using (SaveFileDialog fileChooser = new SaveFileDialog())
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
                         output = new FileStream(fileName,
                            FileMode.OpenOrCreate, FileAccess.Write);

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
                        var record = new RecordSerializable(accountNumber,
                            values[(int)TextBoxIndices.First],
                            values[(int)TextBoxIndices.Last],
                            decimal.Parse(values[(int)TextBoxIndices.Balance]));

                        // write Record to FileStream (serialize object)
                        formatter.Serialize(output, record);

                    }
                    else
                    {
                        // notify user if invalid account number
                        MessageBox.Show("Invalid Account Number", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (SerializationException)
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
                output?.Close(); // close fileStream

            }
            catch (IOException)
            {
                MessageBox.Show("Cannot close file", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Application.Exit();
        }
    }
}
