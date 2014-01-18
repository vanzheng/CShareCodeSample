using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.IO;
using System.Data.OleDb;
using System.Data.Common;
using System.Data.SqlClient;

namespace DatabaseSchema
{
    public class Program
    {
        public static readonly string connstr = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
        public static readonly string sqlconnstr = ConfigurationManager.ConnectionStrings["SqlTest"].ConnectionString;

        static void Main(string[] args)
        {
            SqlClientReadCollectionName("Tables");
            SqlClientReadCollectionName("Columns");
            SqlClientReadCollectionName("Columns", null, "ORDINAL_POSITION ASC");
            SqlClientReadCollectionName("Views");
            SqlClientReadCollectionName("Procedures");
            SqlClientReadCollectionName("ProcedureParameters");
            SqlClientReadCollectionName("Indexes");
            SqlClientReadCollectionName("IndexColumns");

            OleDbReadCollectionName("Tables");
            OleDbReadCollectionName("Columns");
            //OleDbReadCollectionName("Views");
            //OleDbReadCollectionName("Procedures");
            //OleDbReadCollectionName("ProcedureParameters");
            OleDbReadCollectionName("Indexes");

            Console.Read();
        }

        private static void SqlClientReadCollectionName(string name)
        {
            using (SqlConnection conn = new SqlConnection(sqlconnstr))
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                StringBuilder sb = new StringBuilder();

                DataTable dataTable = conn.GetSchema(name);

                foreach (DataColumn dataColumn in dataTable.Columns)
                {
                    sb.Append(dataColumn.ColumnName.PadRight(40));
                }

                sb.AppendLine();

                foreach (DataRow row in dataTable.Rows)
                {
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        sb.Append(row[column].ToString().PadRight(40));
                    }

                    sb.AppendLine();
                }

                using (StreamWriter writer = new StreamWriter(String.Format("sqlserver-{0}-schema.txt", name.ToLowerInvariant())))
                {
                    writer.Write(sb.ToString());
                    writer.Flush();
                }

            }
        }

        private static void SqlClientReadCollectionName(string name, string filter, string sort)
        {
            using (SqlConnection conn = new SqlConnection(sqlconnstr))
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                StringBuilder sb = new StringBuilder();

                DataTable dataTable = conn.GetSchema(name);
                DataRow[] rows = dataTable.Select(filter, sort);

                foreach (DataColumn dataColumn in dataTable.Columns)
                {
                    sb.Append(dataColumn.ColumnName.PadRight(40));
                }

                sb.AppendLine();

                foreach (DataRow row in rows)
                {
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        sb.Append(row[column].ToString().PadRight(40));
                    }

                    sb.AppendLine();
                }

                using (StreamWriter writer = new StreamWriter(String.Format("sqlserver-filter-{0}-schema.txt", name.ToLowerInvariant())))
                {
                    writer.Write(sb.ToString());
                    writer.Flush();
                }

            }
        }

        private static void OleDbReadCollectionName(string name) 
        {
            using (OleDbConnection conn = new OleDbConnection(connstr))
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                StringBuilder sb = new StringBuilder();

                DataTable dataTable = conn.GetSchema(name);

                foreach (DataColumn dataColumn in dataTable.Columns)
                {
                    sb.Append(dataColumn.ColumnName.PadRight(40));
                }

                sb.AppendLine();

                foreach (DataRow row in dataTable.Rows)
                {
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        sb.Append(row[column].ToString().PadRight(40));
                    }

                    sb.AppendLine();
                }

                using (StreamWriter writer = new StreamWriter(String.Format("oledb-{0}-schema.txt", name.ToLowerInvariant())))
                {
                    writer.Write(sb.ToString());
                    writer.Flush();
                }

            }
        }
    }
}
