using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;

namespace CacheTest
{
    public partial class _Default : System.Web.UI.Page
    {
        private static Dictionary<string, Product> dictionary = new Dictionary<string, Product>();

        private Product _product;

        protected Product Product 
        {
            get 
            {
                return _product;
            }
            set 
            {
                _product = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            Product product = new Product()
            {
                Name = "Apple",
                Category = "Fruit",
                Description = "This is a apple."
            };
            string fullName = product.GetType().FullName;

            if (dictionary.ContainsKey(fullName) && dictionary[fullName] != null)
            {
                _product = dictionary[fullName];
            }
            else
            {
                dictionary[fullName] = product;
            }
        }
    }
}
