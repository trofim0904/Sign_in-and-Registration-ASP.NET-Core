using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace sign_in
{
    public class Controler
    {
        public static void EditAccount(UserModel user)
        {
            user.password = AddSymbols.ComputeSha256Hash(user.password);
            MySqlConnection conn = DbWorker.getMysqlConnection();
            conn.Open();
            string query = $"UPDATE account SET name='{user.name}',password='{user.password}',address='{user.address}',age={user.age},gender='{user.gender}' WHERE login='{user.login}';";
            MySqlCommand command = new MySqlCommand();
            command.Connection = conn;
            command.CommandText = query;
            command.ExecuteNonQuery();
            conn.Close();
        }
        public static bool CheckAccount(string login,string password)
        {
            password = AddSymbols.ComputeSha256Hash(password);
            MySqlConnection conn = DbWorker.getMysqlConnection();
            conn.Open();
            string query = $"SELECT account.login, account.password FROM account WHERE account.login='{login}' AND account.password='{password}';";
            MySqlCommand command = new MySqlCommand();
            command.Connection = conn;
            command.CommandText = query;
            using (DbDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    int loginO = reader.GetOrdinal("login");
                    string login_for_check = reader.GetString(loginO);
                    int passwordO = reader.GetOrdinal("password");
                    string password_for_check = reader.GetString(passwordO);
                    if (login_for_check.Equals(login) && password_for_check.Equals(password))
                    {
                        return true;
                    }

                }
            }
            conn.Close();
            return false;
            

        }
        public static bool CheckLogin(string login)
        {
            MySqlConnection conn = DbWorker.getMysqlConnection();
            conn.Open();
            string query = $"SELECT account.login FROM account WHERE account.login='{login}';";
            MySqlCommand command = new MySqlCommand();
            command.Connection = conn;
            command.CommandText = query;
            using (DbDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    int loginO = reader.GetOrdinal("login");
                    string login_for_check = reader.GetString(loginO);
                   
                    if (login_for_check.Equals(login))
                    {
                        return true;
                    }

                }
            }
            conn.Close();
            return false;
        }
        public static void AddAccount(UserModel user)
        {
            user.password = AddSymbols.ComputeSha256Hash(user.password);
            MySqlConnection conn = DbWorker.getMysqlConnection();
            conn.Open();
            string query = $"INSERT INTO account(name,login,password,address,age,gender) VALUES('{user.name}','{user.login}','{user.password}','{user.address}',{user.age},'{user.gender}');";
            MySqlCommand command = new MySqlCommand();
            command.Connection = conn;
            command.CommandText = query;
            command.ExecuteNonQuery();
            conn.Close();
        }
        
    }
}
