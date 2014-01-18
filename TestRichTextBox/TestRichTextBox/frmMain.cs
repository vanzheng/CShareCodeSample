using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TestRichTextBox
{
    public partial class frmMain : Form
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }

        public frmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectedText = richTextBox1.SelectedText;
            int pos = 0;
            int textlen = richTextBox1.TextLength;
            richTextBox1.SelectionColor = Color.Red;
            richTextBox1.SelectionStart = 0;
            richTextBox1.SelectionLength = 2;
            richTextBox1.SelectedText = "12";
            //richTextBox1.SelectedText = richTextBox1.Text.Substring(0, textlen - 5);
            MessageBox.Show("Selected Text: "+selectedText + "\n"
                + "Selection Start: "+richTextBox1.SelectionStart+"\n"
                + "Selection Length: "+richTextBox1.SelectionLength
                );
            
        }
    }
}
