namespace ContainerShip
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
            this.button1 = new System.Windows.Forms.Button();
            this.NC_Box = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CC_Box = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.VC_Box = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.VCC_Box = new System.Windows.Forms.NumericUpDown();
            this.placedLabel = new System.Windows.Forms.Label();
            this.shipsizeLabel = new System.Windows.Forms.Label();
            this.shiplengthLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ShipLengthNumeric = new System.Windows.Forms.NumericUpDown();
            this.ShipWidthNumeric = new System.Windows.Forms.NumericUpDown();
            this.ShipHeightNumeric = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.NC_Box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CC_Box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VC_Box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VCC_Box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipLengthNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipWidthNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipHeightNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 115);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 39);
            this.button1.TabIndex = 0;
            this.button1.Text = "Confirm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // NC_Box
            // 
            this.NC_Box.Location = new System.Drawing.Point(12, 37);
            this.NC_Box.Name = "NC_Box";
            this.NC_Box.Size = new System.Drawing.Size(120, 20);
            this.NC_Box.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Normal Containers";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Cooled Containers";
            // 
            // CC_Box
            // 
            this.CC_Box.Location = new System.Drawing.Point(12, 89);
            this.CC_Box.Name = "CC_Box";
            this.CC_Box.Size = new System.Drawing.Size(120, 20);
            this.CC_Box.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(148, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Valuable Containers";
            // 
            // VC_Box
            // 
            this.VC_Box.Location = new System.Drawing.Point(148, 37);
            this.VC_Box.Name = "VC_Box";
            this.VC_Box.Size = new System.Drawing.Size(120, 20);
            this.VC_Box.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(148, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Valuable Cooled Containers";
            // 
            // VCC_Box
            // 
            this.VCC_Box.Location = new System.Drawing.Point(148, 89);
            this.VCC_Box.Name = "VCC_Box";
            this.VCC_Box.Size = new System.Drawing.Size(120, 20);
            this.VCC_Box.TabIndex = 7;
            // 
            // placedLabel
            // 
            this.placedLabel.AutoSize = true;
            this.placedLabel.Location = new System.Drawing.Point(173, 128);
            this.placedLabel.Name = "placedLabel";
            this.placedLabel.Size = new System.Drawing.Size(104, 13);
            this.placedLabel.TabIndex = 9;
            this.placedLabel.Text = "Containers placed: 0";
            // 
            // shipsizeLabel
            // 
            this.shipsizeLabel.AutoSize = true;
            this.shipsizeLabel.Location = new System.Drawing.Point(342, 18);
            this.shipsizeLabel.Name = "shipsizeLabel";
            this.shipsizeLabel.Size = new System.Drawing.Size(86, 13);
            this.shipsizeLabel.TabIndex = 11;
            this.shipsizeLabel.Text = "Ship dimensions:";
            // 
            // shiplengthLabel
            // 
            this.shiplengthLabel.AutoSize = true;
            this.shiplengthLabel.Location = new System.Drawing.Point(337, 40);
            this.shiplengthLabel.Name = "shiplengthLabel";
            this.shiplengthLabel.Size = new System.Drawing.Size(46, 13);
            this.shiplengthLabel.TabIndex = 12;
            this.shiplengthLabel.Text = "Length: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(342, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Width: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(342, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Height: ";
            // 
            // ShipLengthNumeric
            // 
            this.ShipLengthNumeric.Location = new System.Drawing.Point(389, 38);
            this.ShipLengthNumeric.Name = "ShipLengthNumeric";
            this.ShipLengthNumeric.Size = new System.Drawing.Size(71, 20);
            this.ShipLengthNumeric.TabIndex = 16;
            this.ShipLengthNumeric.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // ShipWidthNumeric
            // 
            this.ShipWidthNumeric.Location = new System.Drawing.Point(389, 63);
            this.ShipWidthNumeric.Name = "ShipWidthNumeric";
            this.ShipWidthNumeric.Size = new System.Drawing.Size(71, 20);
            this.ShipWidthNumeric.TabIndex = 17;
            this.ShipWidthNumeric.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // ShipHeightNumeric
            // 
            this.ShipHeightNumeric.Location = new System.Drawing.Point(389, 89);
            this.ShipHeightNumeric.Name = "ShipHeightNumeric";
            this.ShipHeightNumeric.Size = new System.Drawing.Size(71, 20);
            this.ShipHeightNumeric.TabIndex = 18;
            this.ShipHeightNumeric.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 166);
            this.Controls.Add(this.ShipHeightNumeric);
            this.Controls.Add(this.ShipWidthNumeric);
            this.Controls.Add(this.ShipLengthNumeric);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.shiplengthLabel);
            this.Controls.Add(this.shipsizeLabel);
            this.Controls.Add(this.placedLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.VCC_Box);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.VC_Box);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CC_Box);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NC_Box);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.NC_Box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CC_Box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VC_Box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VCC_Box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipLengthNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipWidthNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipHeightNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown NC_Box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown CC_Box;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown VC_Box;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown VCC_Box;
        private System.Windows.Forms.Label placedLabel;
        private System.Windows.Forms.Label shipsizeLabel;
        private System.Windows.Forms.Label shiplengthLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown ShipLengthNumeric;
        private System.Windows.Forms.NumericUpDown ShipWidthNumeric;
        private System.Windows.Forms.NumericUpDown ShipHeightNumeric;
    }
}

