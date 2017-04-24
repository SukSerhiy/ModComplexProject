using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithDb
{
    public class Select
    {
        private string tableName;
        private string predicate;
        private List<List<string>> data;

        public Select(string tableName, string predicate = "")
        {
            this.tableName = tableName;
            this.predicate = predicate;
            data = new List<List<string>>();
        }

        private SqlDataReader getDataReader()
        {
            string conStr = ConnectionInfo.connectionString;


            SqlConnection connection = new SqlConnection(conStr);
            connection.Open();

            Console.WriteLine(connection.State);

            SqlCommand cmd;
            if (String.IsNullOrEmpty(predicate))
            {
                cmd = new SqlCommand("Select * from " + tableName, connection);
            }
            else
            {
                cmd = new SqlCommand("Select * FROM " + tableName + " WHERE " + predicate, connection);
            }

            SqlDataReader reader = cmd.ExecuteReader();

            return reader;


        }

        public IEnumerable<string> getHeaders()
        {
            List<string> headers = new List<string>();
            using (SqlDataReader reader = getDataReader())
            {
                if (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        headers.Add(reader.GetName(i));
                    }
                }
                return headers;
            }


        }

        public IEnumerable<IEnumerable<string>> getData()
        {
            using (SqlDataReader reader = getDataReader())
            {
                List<List<string>> data = new List<List<string>>();
                while (reader.Read())
                {
                    List<string> dataRow = new List<string>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        dataRow.Add("" + reader[i]);
                    }
                    data.Add(dataRow);
                }
                return data;
            }


        }
    }
}
