# ASP.NET CORE REFERENCE
Reference to self for how to set up an ASP.NET CORE app.

### 1. Setup App
  + Make a **main** folder.
  + Add a **test** folder.

### 2. Inside **Main** Folder
  + Inside the **main** folder, CP `yo candyman <appName>`.
  + Go into the **app** folder, and inside **appName.csproj**, add the following code to setup Watcher tool:  
  ```  
  <ItemGroup>   
  <DotNetCliToolReference Include="Microsoft.DotNet.Watcher.Tools" Version="1.0.0"/>  
  </ItemGroup>  
  ```
  + CP `set ASPNETCORE_ENVIRONMENT=Development`.
  + CP `dotnet restore`.

### 3. Inside **Test** Folder
  + CP `dotnet new xunit`.
  + CP `dotnet add reference ../<appName>/<appName>.csproj`.
  + Inside **Unit1Test.cs**, add `using <appName>;` and `using <appName>.Controllers;`.

### 4. Connect to Database
  + CP `dotnet add package MySql.Data -v 7.0.7-*`.
  + CP `dotnet add package System.Data.SqlClient -v 4.1.0-*`.
  + Create a **DbConnection.cs**, and add this block of code to it:
  ```   
  using System.Collections.Generic;
  using System.Data;
  using MySql.Data.MySqlClient;
   
  namespace DbConnection
  {
     public class DbConnector
     {
        static string server = "localhost";
        static string db = "myDatabase"; //Change to your schema name
        static string port = "3306"; //Potentially 8889
        static string user = "root";
        static string pass = "root";
        internal static IDbConnection Connection {
            get {
                return new MySqlConnection($"Server={server};Port={port};Database={db};UserID={user};Password={pass};SslMode=None");
            }
        }
          
        //This method runs a query and stores the response in a list of dictionary records
        public static List<Dictionary<string, object>> Query(string queryString)
        {
            using(IDbConnection dbConnection = Connection)
            {
                using(IDbCommand command = dbConnection.CreateCommand())
                {
                   command.CommandText = queryString;
                   dbConnection.Open();
                   var result = new List<Dictionary<string, object>>();
                   using(IDataReader rdr = command.ExecuteReader())
                   {
                      while(rdr.Read())
                      {
                          var dict = new Dictionary<string, object>();
                          for( int i = 0; i < rdr.FieldCount; i++ ) {
                              dict.Add(rdr.GetName(i), rdr.GetValue(i));
                          }
                          result.Add(dict);
                      }
                      return result;
                                      }
                }
            }
        }
        //This method run a query and returns no values
        public static void Execute(string queryString)
        {
            using (IDbConnection dbConnection = Connection)
            {
                using(IDbCommand command = dbConnection.CreateCommand())
                {
                    command.CommandText = queryString;
                    dbConnection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
 }
   ```
  + Inside **YourController.cs**, add `using DbConnection;`.

### 5. Using Model Binding & Validations
  + In your model validation **.cs** page, add `using System.ComponentModel.DataAnnotations;`.
  + In your model, **Example.cs**:
  ```
using System.ComponentModel.DataAnnotations;
 
namespace YourNamespace.Models
{
    public class Product : BaseEntity
    {
         [Required]
         [MinLength(2)]
         public string Name { get; set; }
 
         [Required]
         public double Price { get; set; }
    }
}
 ```
  + In your controller, **YourController.cs**:
  ```
namespace YourNamespace.Controllers
{
    [Route("RouteName")]
    public IActionResult Register(User user)
    {
        if(ModelState.IsValid)
        {
            //Handle success
        }
        return View(user);
    }
}
  ```
  + In your HTML, **Example.cshtml**:
  ```
@model YourNamespace.Models.User
<form asp-controller="User" asp-action="Register" method="post">
    <span asp-validation-for="FirstName"></span>
    <label asp-for="FirstName"></label>
    <input asp-for="FirstName"/>
    <span asp-validation-for="LastName"></span>
    <label asp-for="LastName"></label>
    <input asp-for="LastName"/>
    <span asp-validation-for="Email"></span>
    <label asp-for="Email"></label>
    <input asp-for="Email"/>
    <span asp-validation-for="Password"></span>
    <label asp-for="Password"></label>
    <input asp-for="Password"/>
    <button type="submit">Create new User</button>
</form>
  ```

### 6. Using Partials
  + To add Partials, in your **Example.cshtml**, add `@Html.Partial("ExampleModel")`.
  + To add your model to your Partial, add `@model LoginRegistration.Models.Login`.


### 7. Using Dapper
  + CP `dotnet add package Dapper`.
  + Create a **Factories** folder.
  + Create a **Example.cs** file under the **Factories** folder:
  ```
using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using DapperApp.Models;


public void Add(Example item)
        {
            using (IDbConnection dbConnection = Connection) {
                string query =  "INSERT INTO example (user_name, email, password, created_at, updated_at) VALUES (@Name, @Email, @Password, NOW(), NOW())";
                dbConnection.Open();
                dbConnection.Execute(query, item);
            }
        }

        public IEnumerable<Example> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Example>("SELECT * FROM example");
            }
        }

        public Example FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Example>("SELECT * FROM example WHERE id = @Id", new { Id = id }).FirstOrDefault();
            }
        }
  ```
  + Call SQL query methods in **YourController.cs**:
  ```
// Other namespaces added here.
using Example.Factory; 

namespace YourNamespace.Controllers
{
    public class HomeController : Controller
    {
        private readonly ExampleFactory exampleFactory;

        public HomeController()
        {
            //Instantiate a ExampleFactory object that is immutable (READONLY)
            //This establishes the initial DB connection for us.
            exampleFactory = new ExampleFactory();
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            //We can call upon the methods of the exampleFactory directly now.
            ViewBag.Example = exampleFactory.FindAll();
            return View();
        }
    }
}
  ```