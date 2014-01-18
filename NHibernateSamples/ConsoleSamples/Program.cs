using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using Business;

namespace ConsoleSamples
{
    public class Program
    {
        static void Main(string[] args)
        {
            ProductRepository dal = new ProductRepository();
            Product product = new Product()
            {
                Name = "Test 2",
                Category = "cate 2",
                Discontinued = false,
            };
            //dal.Add(product);
            IList<Product> products = dal.GetList();
            foreach (Product pro in products)
            {
                Console.WriteLine("Id: " + pro.Id);
                Console.WriteLine("Name: " + pro.Name);
                Console.WriteLine("Category: " + pro.Category);
            }

            Console.ReadKey();
        }
    }
}
