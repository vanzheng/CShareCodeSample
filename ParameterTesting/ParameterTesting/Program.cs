using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ParameterTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 1;
            Console.WriteLine(i.GetType().Name);
            SqlParameter parameter = new SqlParameter("@a", "ab");
            //parameter.DbType = DbType.String;
            Console.WriteLine(parameter.Value);
            Console.WriteLine(parameter.Size);
            Console.WriteLine(parameter.Direction);
            Console.WriteLine(parameter.DbType.ToString());
            Console.WriteLine(parameter.SqlDbType.ToString());
            Console.Read();
        }
    }
}
