using System.Reflection;
using NHibernate;
using NHibernate.Cfg;

namespace Business
{
    public static class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory = null;

        public static ISessionFactory SessionFactory 
        {
            get 
            {
                if (_sessionFactory == null) 
                {
                    _sessionFactory =(new Configuration()).Configure().BuildSessionFactory();
                }

                return _sessionFactory;
            }
        }
    }
}
