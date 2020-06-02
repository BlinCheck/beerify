using MySql.Data;
using MySql.Data.MySqlClient;
using System;

namespace Data
{
    public class DBConnection
    {
        private static DBConnection _instance = null;
        private MySqlConnection connection = null;
        public string DatabaseName = "Beerify";
        public string Password { get; set; }

        private DBConnection()
        { }

        public MySqlConnection Connection
        {
            get { return connection; }
        }

        public static DBConnection Instance()
        {
            if (_instance == null)
                _instance = new DBConnection();
            return _instance;
        }

        public bool IsConnect()
        {
            if (Connection == null)
            {
                if (String.IsNullOrEmpty(DatabaseName))
                    return false;
                string connstring = string.Format("Server=51.158.67.202; database={0}; UID=v; password=votton", DatabaseName);
                connection = new MySqlConnection(connstring);
                connection.Open();
            }

            return true;
        }

        public static MySqlCommand Execute(string query)
        {
            DBConnection dbCon = Instance();
            if (dbCon.IsConnect())
            {
                var cmd = new MySqlCommand(query, dbCon.Connection);
                return cmd;
            }

            throw new Exception("NOT CONNECTED WHILE EXECUTING");
        }

        public void Close()
        {
            connection.Close();
        }
    }
}