using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using TheDojoLeague.Models;

namespace TheDojoLeague.Factories
{
    public class DojoFactory
    {
        static string server = "localhost";
        static string db = "dojoDb";
        static string port = "3306";
        static string user = "root";
        static string pass = "root";
        internal static IDbConnection Connection {
            get {
                return new MySqlConnection($"Server={server};Port={port};Database={db};UserID={user};Password={pass};SslMode=None");
            }
        }


        // Show all dojos.
        public IEnumerable<Dojo> ShowAllDojos()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                string query = $"SELECT name FROM dojos";
                return dbConnection.Query<Dojo>(query).ToList();
            }
        }

        // Register dojo.
        public void RegisterDojo(Dojo dojo)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                string query = $"INSERT INTO dojos (name, location) VALUES (@name, @location)";
                dbConnection.Execute(query, dojo);
            }
        }
    }
}