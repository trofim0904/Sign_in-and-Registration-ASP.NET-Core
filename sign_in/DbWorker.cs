using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sign_in
{
    public class DbWorker
    {
        static string host = "127.0.0.1";
        static int port = 3306;
        static string db = "accounts";
        static string username = "root";
        static string password = "";

        public static MySqlConnection getMysqlConnection()
        {
            return MySqlConnector.getConnection(host, port, db, username, password);
        }
    }
}
