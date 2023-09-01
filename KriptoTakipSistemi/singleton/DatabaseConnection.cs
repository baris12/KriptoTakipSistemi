using Newtonsoft.Json.Linq;
using Npgsql;
using System;

namespace KriptoTakipSistemi.singleton
{
    public class DatabaseConnection : IDisposable
    {
        private static DatabaseConnection _instance;
        private readonly string _connectionString;
        private NpgsqlConnection _connection;
        private bool _disposed = false;

        private DatabaseConnection(string host, string username, string password, string database)
        {
            _connectionString = $"Host={host};Username={username};Password={password};Database={database};Pooling=true;";
            _connection = new NpgsqlConnection(_connectionString);
            _connection.Open();
        }

        public static DatabaseConnection Instance
        {
            get
            {
                try
                {
                    if (_instance == null)
                    {
                        _instance = new DatabaseConnection("127.0.0.1", "postgres", "test123", "test");
                    }
                    return _instance;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public NpgsqlDataReader ExecuteQuery(string query)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand(query, _connection))
            {
                return cmd.ExecuteReader();
            }
        }

        public JArray SelectQuery(string query)
        {
            try
            {
                JArray queryResult = new JArray();
                using (NpgsqlDataReader reader = ExecuteQuery(query))
                {
                    while (reader.Read())
                    {
                        JObject line = new JObject();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            string columnName = reader.GetName(i);
                            string result = reader[i].ToString();
                            line[columnName] = result;
                        }
                        queryResult.Add(line);
                    }
                }
                return queryResult;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                return null;
            }
        }

        public int ExecuteNonQuery(string queryString)
        {
            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand(queryString, _connection))
                {
                    int affectedRows = cmd.ExecuteNonQuery();
                    return affectedRows;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                return -1;
            }
        }

        public long InsertAndGetId(string insertQuery)
        {
            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand(insertQuery, _connection))
                {
                    object insertedId = cmd.ExecuteScalar();
                    if (insertedId != null && insertedId != DBNull.Value)
                    {
                        return Convert.ToInt64(insertedId);
                    }
                    else
                    {
                        return -1; // error while inserting 
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                return -1;
            }
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
                if (disposing)
                {
                    _connection.Close();
                    _connection.Dispose();
                }

                _disposed = true;
            }
        }
    }
}
