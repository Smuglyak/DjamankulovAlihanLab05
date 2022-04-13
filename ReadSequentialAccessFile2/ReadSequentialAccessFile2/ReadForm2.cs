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

namespace ReadSequentialAccessFile2
{
    public partial class ReadSequentialAccessFileForm2 : BankUIForm
    {
        // object for deserializing RecordSerializable in binary format
        private BinaryFormatter reader = new BinaryFormatter();
        private FileStream input; // stream for reading from a file

        public ReadSequentialAccessFileForm2()
        {
            InitializeComponent();
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            DialogResult result;
            string fileName;

            using (OpenFileDialog fileChooser = new OpenFileDialog())
            {
                result = fileChooser.ShowDialog();
                fileName = fileChooser.FileName;
            }

            if (result == DialogResult.OK)
            {
                ClearTextBoxes();
                if (string.IsNullOrEmpty(fileName))
                {
                    MessageBox.Show("Invalid File Name", "Error",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // create FileStream to obtain read access to file
                    input = new FileStream(fileName, FileMode.Open, FileAccess.Read);

                    openButton.Enabled = false; // disable Open File button
                    nextButton.Enabled = true; // enable Next Record button
                }
            }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            // deserialize RecordSerializable and store data in TextBoxes
            try
            {
                // get next RecordSerializable available in file
                RecordSerializable record =
                    (RecordSerializable)reader.Deserialize(input);

                // store RecordSerializable values in temporary string array
                var values = new string[] {
                    record.Account.ToString(),
                    record.FirstName.ToString(),
                    record.LastName.ToString(),
                    record.Balance.ToString()
                };

                // copy string-array values to TextBox values
                SetTextBoxValues(values);

            }
            catch (SerializationException)
            {
                input?.Close(); // close FileStream
                openButton.Enabled = true; // enable Open File button
                nextButton.Enabled = false; // disable Next Record button

                ClearTextBoxes();

                // notify user if no RecordSerializables in file
                MessageBox.Show("No more records in file", string.Empty,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
