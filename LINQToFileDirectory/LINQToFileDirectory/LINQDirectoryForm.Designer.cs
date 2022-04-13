
namespace LINQToFileDirectory
{
    partial class LINQToFileDirectoryForm
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
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.directoryTextBox = new System.Windows.Forms.TextBox();
            this.resultsTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.enterPathLabel = new System.Windows.Forms.Label();
            this.directoryLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pathTextBox
            // 
            this.pathTextBox.Location = new System.Drawing.Point(13, 89);
            this.pathTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(481, 22);
            this.pathTextBox.TabIndex = 0;
            // 
            // directoryTextBox
            // 
            this.directoryTextBox.Location = new System.Drawing.Point(72, 140);
            this.directoryTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.directoryTextBox.Name = "directoryTextBox";
            this.directoryTextBox.Size = new System.Drawing.Size(481, 22);
            this.directoryTextBox.TabIndex = 1;
            // 
            // resultsTextBox
            // 
            this.resultsTextBox.Location = new System.Drawing.Point(72, 181);
            this.resultsTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.resultsTextBox.Multiline = true;
            this.resultsTextBox.Name = "resultsTextBox";
            this.resultsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.resultsTextBox.Size = new System.Drawing.Size(481, 326);
            this.resultsTextBox.TabIndex = 2;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(520, 89);
            this.searchButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(133, 22);
            this.searchButton.TabIndex = 5;
            this.searchButton.Text = "Search Directory";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // enterPathLabel
            // 
            this.enterPathLabel.AutoSize = true;
            this.enterPathLabel.Location = new System.Drawing.Point(269, 31);
            this.enterPathLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.enterPathLabel.Name = "enterPathLabel";
            this.enterPathLabel.Size = new System.Drawing.Size(128, 16);
            this.enterPathLabel.TabIndex = 6;
            this.enterPathLabel.Text = "Enter path to search:";
            // 
            // directoryLabel
            // 
            this.directoryLabel.AutoSize = true;
            this.directoryLabel.Location = new System.Drawing.Point(0, 184);
            this.directoryLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.directoryLabel.Name = "directoryLabel";
            this.directoryLabel.Size = new System.Drawing.Size(64, 16);
            this.directoryLabel.TabIndex = 7;
            this.directoryLabel.Text = "Directory:";
            // 
            // LINQToFileDirectoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 530);
            this.Controls.Add(this.directoryLabel);
            this.Controls.Add(this.enterPathLabel);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.resultsTextBox);
            this.Controls.Add(this.directoryTextBox);
            this.Controls.Add(this.pathTextBox);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "LINQToFileDirectoryForm";
            this.Text = "Search Directory";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.TextBox directoryTextBox;
        private System.Windows.Forms.TextBox resultsTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label enterPathLabel;
        private System.Windows.Forms.Label directoryLabel;
    }
}

