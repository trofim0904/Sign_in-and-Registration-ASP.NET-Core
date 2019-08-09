using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace sign_in
{
    public class MySqlConnector
    {
        public static MySqlConnection getConnection(string host, int port, string db, string username, string password)
        {
            String config = "Server=" + host + ";Database=" + db + ";port=" + port + ";User Id=" + username + ";password=" + password;
            MySqlConnection conn = new MySqlConnection(config);
            return conn;
        }
    }
}
