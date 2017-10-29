using System.Collections.Generic;
using System.Data;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using LostInTheWoods.Models;
using Dapper;
using System.Linq;

namespace LostInTheWoods.Factories
{
    public class TrailFactory
    {
        static string server = "localhost";
        static string db = "trailDb";
        static string port = "3306";
        static string user = "root";
        static string pass = "root";
        internal static IDbConnection Connection {
            get {
                return new MySqlConnection($"Server={server};Port={port};Database={db};UserID={user};Password={pass};SslMode=None");
            }
        }

        // Get all trails.
        public List<Trail> GetAllTrails()
        {
            using(IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                string query = $"SELECT * FROM trails";
                return dbConnection.Query<Trail>(query).ToList();
            }
        }

        // Add new trail.
        public void AddNewTrail(Trail trail)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                string query = $"INSERT INTO trails (name, description, length, elevation, longitude, latitude) VALUES (@name, @description, @length, @elevation, @longitude, @latitude)";
                dbConnection.Execute(query, trail);
            }
        }

        // Find trail.
        public Trail FindTrail(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Trail>("SELECT * FROM trails WHERE id = @id", new { id = id }).FirstOrDefault();
            }
        }
    }
}