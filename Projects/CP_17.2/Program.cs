using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP_17._2
{
    class Program
    {
        static void Main()
        {
            string connectionString = "Data Source=mydatabase.db;Version=3;";

            using (var db = new DatabaseConnection(connectionString))
            {
                db.ExecuteQuery("CREATE TABLE IF NOT EXISTS TestTable (Id INTEGER PRIMARY KEY, Name TEXT)");

                db.ExecuteQuery("INSERT INTO TestTable (Name) VALUES ('Пример записи')");

                using (var reader = db.ExecuteReader("SELECT * FROM TestTable"))
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["Id"]}, Name: {reader["Name"]}");
                    }
                }
            } // Здесь Dispose вызовется автоматически
        }
    }

    public class DatabaseConnection : IDisposable
    {
        private SQLiteConnection _connection;
        private bool _disposed = false;

        public DatabaseConnection(string connectionString)
        {
            _connection = new SQLiteConnection(connectionString);
            _connection.Open();
        }

        public void ExecuteQuery(string query)
        {
            if (_disposed)
                throw new ObjectDisposedException("DatabaseConnection");

            using (var command = new SQLiteCommand(query, _connection))
            {
                command.ExecuteNonQuery();
            }
        }

        public SQLiteDataReader ExecuteReader(string query)
        {
            if (_disposed)
                throw new ObjectDisposedException("DatabaseConnection");

            var command = new SQLiteCommand(query, _connection);
            return command.ExecuteReader();
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing && _connection != null)
                {
                    _connection.Dispose();
                }
                _disposed = true;
            }
        }

        DatabaseConnection()
        {
            Dispose(false);
        }
    }

}
