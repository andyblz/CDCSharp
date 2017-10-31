using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using TheDojoLeague.Models;

namespace TheDojoLeague.Factories
{
    public class NinjaFactory
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


        // Add a new ninja.
        public void AddNewNinja(Ninja ninja)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                string query = $"INSERT INTO ninjas (name, level, dojo_id) VALUES (@name, @level, @dojo_id)";
                dbConnection.Execute(query, ninja);
            }
        }


        // Show all ninjas.
        public IEnumerable<Ninja> ShowAllNinjas()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                string query = $"SELECT * FROM ninjas JOIN dojos ON ninjas.dojo_id WHERE dojos.id = ninjas.dojo_id";

                var allNinjas = dbConnection.Query<Ninja, Dojo, Ninja>(query, (ninja, dojo) => { ninja.dojo = dojo; return ninja; });
                return allNinjas;
            }
        }


        // Show specific ninja.


    }
}