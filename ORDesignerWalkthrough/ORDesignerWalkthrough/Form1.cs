using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Data.Linq;
using System.Windows.Forms;

namespace ORDesignerWalkthrough
{
    public partial class Form1 : Form
    {
        private NorthwindDataContext db = new NorthwindDataContext();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //var customerQuery = from customers in db.Customers
            //                    where customers.City == cityTextBox.Text
            //                    select customers;
            customerBindingSource.DataSource = db.Customers;
        }

        private void customerBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            db.UpdateCustomers();  
        }
    }
}
