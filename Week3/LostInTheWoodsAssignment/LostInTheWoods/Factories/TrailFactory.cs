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
        private readonly IOptions<MySqlOptions> MySqlConfig;
 
        public TrailFactory(IOptions<MySqlOptions> config)
        {
            MySqlConfig = config;
        }
        internal IDbConnection Connection {
            get {
                return new MySqlConnection(MySqlConfig.Value.ConnectionString);
            }
        }
        
        // Get all trails.
        public List<Trail> GetAllTrails()
        {
            using(IDbConnection dbConnection = Connection)
            {
                string query = $@"SELECT * FROM trails";
                dbConnection.Open();
                return dbConnection.Query<Trail>(query).ToList();
            }
        }

        // Add new trail.
        public void AddNewTrail(Trail trail)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = $@"INSERT INTO trails (name, desc, length, elevation, longitude, latitude) VALUES (@name, @description, @length, @elevationChange, @longitude, @latitude)";
                dbConnection.Open();
                dbConnection.Execute(query, trail);
            }
        }
    }
}