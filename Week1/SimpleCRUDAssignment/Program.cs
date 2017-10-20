using System;
using System.Collections.Generic;
using DbConnection;

namespace SimpleCRUDAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Read();
            Create("newName", "newLName");
            Update("newjennifer", "newfeng", 1);
            Delete(5);
        }


        // Read function that displays all current users' info.
        static void Read()
        {
            Console.WriteLine("\n");           
            var result = DbConnector.Query("SELECT FirstName, LastName FROM users");
            
            foreach (var val in result)
            {
                foreach (var key in val)
                {
                    Console.WriteLine(key);
                }
            }
        }

        static void Create(string firstName, string lastName)
        {
            Console.WriteLine("\n");
            Console.WriteLine("CREATE A NEW USER");
            Console.WriteLine("SEE UPDATED LIST OF USERS");
            DbConnector.Query(String.Format("INSERT INTO users (FirstName, LastName, created_at) VALUES ('{0}', '{1}', NOW())", firstName, lastName));

            Read();
        }

        static void Update(string firstName, string lastName, int userId)
        {
            Console.WriteLine("\n");
            Console.WriteLine("UPDATE A USER");
            Console.WriteLine("SEE UPDATED LIST OF USERS");
            DbConnector.Query(String.Format("UPDATE users SET FirstName = '{0}', LastName = '{1}' WHERE id = {2}", firstName, lastName, userId));

            Read();
        }

        static void Delete(int userId)
        {
            Console.WriteLine("\n");
            Console.WriteLine("DELETE A USER");
            Console.WriteLine("SEE UPDATED LIST OF USERS");
            DbConnector.Query(String.Format("DELETE FROM users WHERE id = {0}", userId));

            Read();
        }
    }
}
