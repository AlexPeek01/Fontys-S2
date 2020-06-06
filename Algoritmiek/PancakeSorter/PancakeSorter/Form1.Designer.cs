namespace PancakeSorter
{
    partial class Form1
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
            this.DisplayTextBox = new System.Windows.Forms.TextBox();
            this.FlipBtn = new System.Windows.Forms.Button();
            this.OrigTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // DisplayTextBox
            // 
            this.DisplayTextBox.Location = new System.Drawing.Point(234, 12);
            this.DisplayTextBox.Multiline = true;
            this.DisplayTextBox.Name = "DisplayTextBox";
            this.DisplayTextBox.Size = new System.Drawing.Size(260, 321);
            this.DisplayTextBox.TabIndex = 0;
            // 
            // FlipBtn
            // 
            this.FlipBtn.Location = new System.Drawing.Point(234, 340);
            this.FlipBtn.Name = "FlipBtn";
            this.FlipBtn.Size = new System.Drawing.Size(260, 23);
            this.FlipBtn.TabIndex = 1;
            this.FlipBtn.Text = "Flip";
            this.FlipBtn.UseVisualStyleBackColor = true;
            this.FlipBtn.Click += new System.EventHandler(this.FlipBtn_Click);
            // 
            // OrigTextBox
            // 
            this.OrigTextBox.Location = new System.Drawing.Point(12, 12);
            this.OrigTextBox.Multiline = true;
            this.OrigTextBox.Name = "OrigTextBox";
            this.OrigTextBox.Size = new System.Drawing.Size(208, 321);
            this.OrigTextBox.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.OrigTextBox);
            this.Controls.Add(this.FlipBtn);
            this.Controls.Add(this.DisplayTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox DisplayTextBox;
        private System.Windows.Forms.Button FlipBtn;
        private System.Windows.Forms.TextBox OrigTextBox;
    }
}

