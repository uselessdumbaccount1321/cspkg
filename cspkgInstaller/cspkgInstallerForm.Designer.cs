namespace cspkgInstaller
{
    partial class cspkgInstallerForm
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
            this.outputTextBox = new System.Windows.Forms.RichTextBox();
            this.packageIdLabel = new System.Windows.Forms.Label();
            this.packageVersionLabel = new System.Windows.Forms.Label();
            this.installButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.pathBox = new System.Windows.Forms.TextBox();
            this.aboutLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // outputTextBox
            // 
            this.outputTextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputTextBox.Location = new System.Drawing.Point(12, 105);
            this.outputTextBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ReadOnly = true;
            this.outputTextBox.Size = new System.Drawing.Size(531, 343);
            this.outputTextBox.TabIndex = 0;
            this.outputTextBox.Text = "<00:00:00> Installer";
            // 
            // packageIdLabel
            // 
            this.packageIdLabel.AutoSize = true;
            this.packageIdLabel.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.packageIdLabel.Location = new System.Drawing.Point(12, 9);
            this.packageIdLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.packageIdLabel.Name = "packageIdLabel";
            this.packageIdLabel.Size = new System.Drawing.Size(285, 33);
            this.packageIdLabel.TabIndex = 1;
            this.packageIdLabel.Text = "author.packagename";
            // 
            // packageVersionLabel
            // 
            this.packageVersionLabel.AutoSize = true;
            this.packageVersionLabel.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.packageVersionLabel.Location = new System.Drawing.Point(14, 45);
            this.packageVersionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.packageVersionLabel.Name = "packageVersionLabel";
            this.packageVersionLabel.Size = new System.Drawing.Size(37, 22);
            this.packageVersionLabel.TabIndex = 2;
            this.packageVersionLabel.Text = "1.0";
            // 
            // installButton
            // 
            this.installButton.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.installButton.Location = new System.Drawing.Point(469, 74);
            this.installButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.installButton.Name = "installButton";
            this.installButton.Size = new System.Drawing.Size(74, 25);
            this.installButton.TabIndex = 3;
            this.installButton.Text = "Install";
            this.installButton.UseVisualStyleBackColor = true;
            this.installButton.Click += new System.EventHandler(this.InstallButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.Location = new System.Drawing.Point(391, 74);
            this.closeButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(74, 25);
            this.closeButton.TabIndex = 4;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // pathBox
            // 
            this.pathBox.Location = new System.Drawing.Point(12, 76);
            this.pathBox.Name = "pathBox";
            this.pathBox.ReadOnly = true;
            this.pathBox.Size = new System.Drawing.Size(374, 20);
            this.pathBox.TabIndex = 5;
            // 
            // aboutLabel
            // 
            this.aboutLabel.AutoSize = true;
            this.aboutLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboutLabel.Location = new System.Drawing.Point(527, 451);
            this.aboutLabel.Name = "aboutLabel";
            this.aboutLabel.Size = new System.Drawing.Size(15, 16);
            this.aboutLabel.TabIndex = 6;
            this.aboutLabel.TabStop = true;
            this.aboutLabel.Text = "?";
            this.aboutLabel.VisitedLinkColor = System.Drawing.Color.Blue;
            this.aboutLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
            // 
            // cspkgInstallerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 472);
            this.Controls.Add(this.aboutLabel);
            this.Controls.Add(this.pathBox);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.installButton);
            this.Controls.Add(this.packageVersionLabel);
            this.Controls.Add(this.packageIdLabel);
            this.Controls.Add(this.outputTextBox);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.Name = "cspkgInstallerForm";
            this.ShowIcon = false;
            this.Text = "Installer — null (author.packagename)";
            this.Load += new System.EventHandler(this.CspkgInstallerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox outputTextBox;
        private System.Windows.Forms.Label packageIdLabel;
        private System.Windows.Forms.Label packageVersionLabel;
        private System.Windows.Forms.Button installButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.TextBox pathBox;
        private System.Windows.Forms.LinkLabel aboutLabel;
    }
}

