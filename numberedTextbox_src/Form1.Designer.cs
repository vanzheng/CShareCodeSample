namespace NumberedTextBox
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
            this.numberedTextBoxUC1 = new NumberedTextBox.NumberedTextBoxUC();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // numberedTextBoxUC1
            // 
            this.numberedTextBoxUC1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numberedTextBoxUC1.Dock = System.Windows.Forms.DockStyle.Top;
            this.numberedTextBoxUC1.Location = new System.Drawing.Point(0, 0);
            this.numberedTextBoxUC1.Name = "numberedTextBoxUC1";
            this.numberedTextBoxUC1.Size = new System.Drawing.Size(434, 261);
            this.numberedTextBoxUC1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 268);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(409, 44);
            this.label1.TabIndex = 1;
            this.label1.Text = "Line numbers are displayed as multiline label in fixed left panel of splitter con" +
                "trol. Line numbers do not handle multiple different font sizes in richTextbox.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 321);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numberedTextBoxUC1);
            this.Name = "Form1";
            this.Text = "Numbered richTextbox";
            this.ResumeLayout(false);

        }

        #endregion

        private NumberedTextBoxUC numberedTextBoxUC1;
        private System.Windows.Forms.Label label1;
    }
}

