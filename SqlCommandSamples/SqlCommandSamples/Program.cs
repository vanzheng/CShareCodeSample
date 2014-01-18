using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SqlCommandSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection conn = null;
            SqlCommand cmd = new SqlCommand("insert MyName(FirstName, LastName) Values(@FirstName, @LastName)");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@FirstName", 'A'));
            cmd.Parameters.Add(new SqlParameter("@LastName", 'B'));
            DataTable dt = null;

            Execute(conn, cmd, dt);

            if (conn != null)
            {
                Console.WriteLine("SqlConnection is not null.");
                if (conn.State == ConnectionState.Closed)
                {
                    Console.WriteLine("SqlConnection is closed.");
                }
            }

            if (cmd != null)
            {
                Console.WriteLine("SqlCommand is not null.");

                if (cmd.Parameters != null && cmd.Parameters.Count > 0)
                {
                    Console.WriteLine("FirstName: " + cmd.Parameters["@FirstName"].Value);
                    Console.WriteLine("LastName: " + cmd.Parameters["@LastName"].Value);
                }
            }

            if (dt != null)
            {
                int rowsLen = dt.Rows.Count;
                int columnLen = dt.Columns.Count;

                for (int i = 0; i < rowsLen; i++)
                {
                    for (int j = 0; j < columnLen; j++)
                    {
                        Console.Write(dt.Rows[i][j] + "  ");
                    }
                    Console.WriteLine();
                }
            }

            Console.ReadLine();
        }

        private static void Execute(SqlConnection conn, SqlCommand cmd, DataTable dt) 
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["Sample"];
            using (conn = new SqlConnection(settings.ConnectionString))
            {
                conn.Open();
                dt = conn.GetSchema();
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                cmd.Dispose();
            }
        }
    }
}
