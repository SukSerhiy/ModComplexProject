using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithDb
{
    /// <summary>
    /// Connection to DB
    /// </summary>
    internal class ConnectionInfo
    {
        internal static string connectionString { get; }

        static ConnectionInfo()
        {
            connectionString = @"Data Source =(LocalDB)\MSSQLLocalDB;Initial Catalog=ModCompDB; Integrated Security=True";
        }
    }
}
