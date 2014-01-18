using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using Domain;

namespace Business
{
    public class ProductRepository
    {

        public void Add(Product product)
        {
            using (ISession session = NHibernateHelper.SessionFactory.OpenSession())
            {
                session.Save(product);
                session.Flush();
            }
        }

        public Product GetModel(int Id)
        {
            using (ISession session = NHibernateHelper.SessionFactory.OpenSession())
            {
                return session.Get<Product>(Id);
            }
        }

        public IList<Product> GetList() 
        {
            using (ISession session = NHibernateHelper.SessionFactory.OpenSession()) 
            {
                return session.CreateQuery("from Product").List<Product>();
            }
        }

        public IList<Product> GetListAsAlias() 
        {
            using (ISession session = NHibernateHelper.SessionFactory.OpenSession())
            {
                return session.CreateQuery("from Product as p").List<Product>();
            }
        }
    }
}
