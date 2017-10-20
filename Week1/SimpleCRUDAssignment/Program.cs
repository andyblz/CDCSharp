using System;
using DbConnection;

namespace SimpleCRUDAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = DbConnector.Query("SELECT FirstName, LastName FROM users");
            
            Console.WriteLine(result);

            // DbConnector.Execute("hey");
        }
    }
}
