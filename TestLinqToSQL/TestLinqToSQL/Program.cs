using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace TestLinqToSQL
{
    public class Program
    {
        private static NorthwindDataContext northwind = new NorthwindDataContext();

        static void Main(string[] args)
        {
            Table<Customer> customers = northwind.Customers;
            var query = from cust in customers
                        where cust.City == "London"
                        select cust;

            foreach (var cus in query) 
            {
                Console.WriteLine("Id = {0}, City = {1}", cus.CustomerID, cus.City);
            }

            CUD();
            Console.ReadKey();
        }


        private static void CUD() 
        {
            var cust = (from cus in northwind.Customers
                       where cus.CustomerID == "ALFKI"
                       select cus).First();

            // Update
            cust.ContactName = "New Contact";

            // Insert
            Order ord = new Order { OrderDate = DateTime.Now };
            cust.Orders.Add(ord);

            Order ord0 = cust.Orders[0];

            var cust2 = from cus in northwind.Customers
                        where cus.CustomerID == "WOLZB"
                        select cus;

            if (cust2 != null) 
            {
                northwind.Customers.DeleteOnSubmit(cust2.First());
            }

            northwind.SubmitChanges();
        }

        private static void Insert() 
        {
            
        }
    }
}
