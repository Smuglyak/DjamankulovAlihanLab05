
namespace FileTest
{
    partial class FileTestForm
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
            this.enterFileOrDirectoryLabel = new System.Windows.Forms.Label();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.outputTextBox2 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // enterFileOrDirectoryLabel
            // 
            this.enterFileOrDirectoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enterFileOrDirectoryLabel.Location = new System.Drawing.Point(255, 23);
            this.enterFileOrDirectoryLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.enterFileOrDirectoryLabel.Name = "enterFileOrDirectoryLabel";
            this.enterFileOrDirectoryLabel.Size = new System.Drawing.Size(192, 28);
            this.enterFileOrDirectoryLabel.TabIndex = 0;
            this.enterFileOrDirectoryLabel.Text = "Enter file or directory:";
            // 
            // inputTextBox
            // 
            this.inputTextBox.Location = new System.Drawing.Point(73, 55);
            this.inputTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(557, 22);
            this.inputTextBox.TabIndex = 1;
            this.inputTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputTextBox_KeyDown);
            // 
            // outputTextBox2
            // 
            this.outputTextBox2.Location = new System.Drawing.Point(73, 113);
            this.outputTextBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.outputTextBox2.Name = "outputTextBox2";
            this.outputTextBox2.Size = new System.Drawing.Size(557, 363);
            this.outputTextBox2.TabIndex = 3;
            this.outputTextBox2.Text = "";
            this.outputTextBox2.TextChanged += new System.EventHandler(this.outputTextBox2_TextChanged);
            // 
            // FileTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 567);
            this.Controls.Add(this.outputTextBox2);
            this.Controls.Add(this.inputTextBox);
            this.Controls.Add(this.enterFileOrDirectoryLabel);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FileTestForm";
            this.Text = "File Test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label enterFileOrDirectoryLabel;
        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.RichTextBox outputTextBox2;
    }
}

