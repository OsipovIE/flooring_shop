using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace flooring_shop
{
    public class DatabaseConnection
    {
        private MySqlConnection connection;

        public DatabaseConnection()
        {
            string connectionString = "server=localhost;user=root;password=root;database=flooring_shop;";
            connection = new MySqlConnection(connectionString);
        }

        public MySqlConnection GetConnection()
        {
            return connection;
        }

        public bool OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                return true; // Соединение уже открыто
            }

            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }


        public bool CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                return true; // Соединение уже закрыто
            }

            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }


        public MySqlDataReader ExecuteQuery(string query)
        {
            MySqlCommand command = new MySqlCommand(query, connection);
            return command.ExecuteReader();
        }
    }
}
