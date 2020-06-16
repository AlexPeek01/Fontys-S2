namespace Mastermind
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.InputField = new System.Windows.Forms.TextBox();
            this.Guess_Btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 68);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(217, 293);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // InputField
            // 
            this.InputField.Location = new System.Drawing.Point(13, 13);
            this.InputField.Name = "InputField";
            this.InputField.Size = new System.Drawing.Size(216, 20);
            this.InputField.TabIndex = 1;
            this.InputField.TextChanged += new System.EventHandler(this.InputField_TextChanged);
            this.InputField.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InputField_KeyPress);
            // 
            // Guess_Btn
            // 
            this.Guess_Btn.Location = new System.Drawing.Point(12, 39);
            this.Guess_Btn.Name = "Guess_Btn";
            this.Guess_Btn.Size = new System.Drawing.Size(217, 23);
            this.Guess_Btn.TabIndex = 3;
            this.Guess_Btn.Text = "Guess";
            this.Guess_Btn.UseVisualStyleBackColor = true;
            this.Guess_Btn.Click += new System.EventHandler(this.Guess_Btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 369);
            this.Controls.Add(this.Guess_Btn);
            this.Controls.Add(this.InputField);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox InputField;
        private System.Windows.Forms.Button Guess_Btn;
    }
}

