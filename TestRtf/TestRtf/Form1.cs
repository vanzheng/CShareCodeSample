using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestRtf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e) 
        {
            //StringBuilder builder = new StringBuilder();
            //builder.Append(@"{\rtf1\ansi\ansicpg936\deff0\deflang1033\deflangfe2052");
            //builder.Append(@"{\fonttbl{\f0\fmodern\fprq1\fcharset0 Courier New;}");
            //builder.Append(@"{\colortbl ;\red0\green0\blue0;\red0\green128\blue0;}");
            //builder.Append(@"\viewkind4\uc1\pard\f0\fs20 d ");
            //builder.Append(@"}");
            //this.richTextBox1.Rtf = builder.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.richTextBox1.Rtf);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.richTextBox1.SelectedRtf);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.richTextBox1.SelectionColor = Color.Blue;
        }
    }
}
