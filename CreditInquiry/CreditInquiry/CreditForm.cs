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

namespace CreditInquiry
{
    public partial class CreditInquiryForm : Form
    {
        private FileStream input; // maintains the connection to the file
        private StreamReader fileReader; // reads data from text file 

        public CreditInquiryForm()
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
                if (string.IsNullOrEmpty(fileName))
                {
                    MessageBox.Show("Invalid File Name", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    input = new FileStream(fileName,
                        FileMode.Open, FileAccess.Read);
                    fileReader = new StreamReader(input);
                }

                openButton.Enabled = false;
                creditButton.Enabled = true;
                debitButton.Enabled = true;
                zeroButton.Enabled = true;
            }
        }

        // invoked when user clicks credit balances,
        // debit balances or zero balances button
        private void getBalances_Click(object sender, System.EventArgs e)
        {
            // convert sender explicitly to object of type button
            Button senderButton = (Button) sender;

            // get text from clicked Button, which stores account type
            string accountType = senderButton.Text;

            try
            {
                // go back to the beginning of the file
                input.Seek(0, SeekOrigin.Begin);

                displayTextBox.Text =
                    $"Account with {accountType}{Environment.NewLine}";

                // traverse file until end of file
                while (true)
                {
                    // get next Record available in file
                    string inputRecord = fileReader.ReadLine();

                    // when at the end of file, exit method
                    if (inputRecord == null)
                    {
                        return;
                    }

                    // parse input
                    string[] inputFields = inputRecord.Split(',');

                    // create Record from input
                    var record = new Record(int.Parse(inputFields[0]), inputFields[1],
                        inputFields[2], decimal.Parse(inputFields[3]));

                    // determine whether to display balance
                    if (ShouldDisplay(record.Balance, accountType))
                    {
                        // display record
                        displayTextBox.AppendText($"{record.Account}\t" +
                            $"{record.FirstName}\t{record.LastName}\t" +
                            $"{record.Balance:C}{Environment.NewLine}");
                    }

                }
            }
            catch (IOException)
            {
                MessageBox.Show("Cannot Read File", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // determine whether to display given record
        private bool ShouldDisplay(decimal balance, string accountType)
        {
            if (balance > 0M && accountType == "Credit Balances")
            {
                return true; // should display credit balances
            }
            else if (balance < 0M && accountType == "Debit Balances")
            {
                return true; // should display debit balances
            }
            else if (balance == 0 && accountType == "Zero Balances")
            {
                return true; // should display zero balances
            }

            return false;
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            try
            {
                fileReader?.Close();  // close StreamReader and underlying file
            }
            catch (IOException)
            {
                // notify user of error closing file
                MessageBox.Show("Cannot close file", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Application.Exit();
        }
    }
}
