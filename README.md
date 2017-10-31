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
  + ENCRYPTION: CP `dotnet add package microsoft.aspnetcore.identity.entityframeworkcore -v=1.1`.
  + ENCRYPTION: Add to **YourController.cs**:
  ```
// To hash.
public IActionResult Method(Example example)
{
     if(ModelState.IsValid)
     {
           PasswordHasher<Example> Hasher = new PasswordHasher<Example>();
           example.Password = Hasher.HashPassword(example, example.Password);
           //Save your example object to the database
     }
}
// To verify:
public IActionResult LoginMethod(string Email, string PasswordToCheck)
{
     // Attempt to retrieve an example from your database based on the Email submitted
     var example = exampleFactory.GetUserByEmail(Email);
     if(example != null && PasswordToCheck != null)
     {
           var Hasher = new PasswordHasher<Example>();
           // Pass the example object, the hashed password, and the PasswordToCheck
           if(0 != Hasher.VerifyHashedPassword(example, example.Password, PasswordToCheck))
           {
                //Handle success
           }
     }
     //Handle failure
}
```
  + RELATIONSHIPS: If one (team) to many (players).
  ```
// In Model/Player.cs
public Team team { get; set; }

// In Model/Teams.cs
public ICollection<Player> players { get; set; }
  ```
  + RELATIONSHIPS: Join and select.
  ```
// Get all players on a specific team.
// Factories/TeamFactory.cs
public Team FindById(long id)
{
    using (IDbConnection dbConnection = Connection)
    {
        dbConnection.Open();
        var query =
        @"
        SELECT * FROM teams WHERE id = @Id;
        SELECT * FROM players WHERE team_id = @Id;
        ";
 
        using (var multi = dbConnection.QueryMultiple(query, new {Id = id}))
        {
            var team = multi.Read<Team>().Single();
            team.players = multi.Read<Player>().ToList();
            return team;
        }
    }
}

// Get team associated with player.
// Factories/PlayerFactory.cs
public IEnumerable<Player> PlayersForTeamById(int id)
{
    using (IDbConnection dbConnection = Connection)
    {
        var query = $"SELECT * FROM players JOIN teams ON players.team_id WHERE teams.id = players.team_id AND teams.id = {id}";
        dbConnection.Open();
 
        var myPlayers = dbConnection.Query<Player, Team, Player>(query, (player, team) => { player.team = team; return player; });
        return myPlayers;
    }
}
  ```

### 8. Securing Databases
  + Add to **appsettings.json**:
  ```
{
    "Logging": {
        "IncludeScopes": false,
        "LogLevel": {
            "Default": "Warning"
        }
    },

    "DBInfo":
    {
        "Name": "MySQLconnect",
        "ConnectionString": "server=localhost;userid=root;password=root;port=3306;database=DATEBASENAME;SslMode=None"
    }
}
  ```
  + CP `dotnet add package MySql.Data -v 7.0.7-*`.
  + Under a **Properties** folder, created a **MySqlOption.cs** file, and add:
  ```
namespace TEMPLATE
{
    public class MySqlOptions
    {
        public string Name { get; set; }
        public string ConnectionString { get; set; }
    }
}
  ```
  + Add to **.csproj** file:
  ```
<Project Sdk="Microsoft.NET.Sdk.Web">
  
  <PropertyGroup>
    
    <TargetFramework>netcoreapp1.1</TargetFramework>

  </PropertyGroup>

  <ItemGroup>

    <PackageReference Include="Microsoft.AspNetCore.Mvc" Version="1.1.2" />

    <PackageReference Include="Microsoft.AspNetCore.StaticFiles" Version="1.1.1" />

    <PackageReference Include="Microsoft.AspNetCore.Session" Version="1.1.1" />

    <PackageReference Include="Microsoft.AspNetCore.Server.Kestrel" Version="1.1.1" />

    <PackageReference Include="Microsoft.AspNetCore.Diagnostics" Version="1.1.1" />

    <PackageReference Include="Microsoft.Extensions.Logging.Console" Version="1.1.1" />

    <PackageReference Include="Microsoft.Extensions.Options.ConfigurationExtensions" Version="1.1" />

    <PackageReference Include="MySql.Data" Version="7.0.7-*" />

    <PackageReference Include="MySql.Data.EntityFrameworkCore" Version="7.0.7-*" />

    <PackageReference Include="System.Data.SqlClient" Version="4.1.0-*" />

  </ItemGroup>

  <ItemGroup>

    <DotNetCliToolReference Include="Microsoft.DotNet.Watcher.Tools" Version="1.0.0" />

  </ItemGroup>

</Project>
```
  + Add to the **Startup.cs** file:
  ```
using System;
using System.Collections.Generic;

using System.Linq;

using Microsoft.AspNetCore.Builder;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Microsoft.Extensions.Configuration;

using Microsoft.AspNetCore.Hosting;

using Microsoft.EntityFrameworkCore;

using MySQL.Data.EntityFrameworkCore;

using MySQL.Data.EntityFrameworkCore.Extensions;

using TEMPLATE.Models;

 
public IConfiguration Configuration { get; private set; }
 
public Startup(IHostingEnvironment env)
{
    var builder = new ConfigurationBuilder()
    .SetBasePath(env.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();
    Configuration = builder.Build();
}

public void ConfigureServices(IServiceCollection services)
        
{

      // INFO: For securing db.

      services.Configure<MySqlOptions>(Configuration.GetSection("DBInfo"));

      services.AddScoped<TEMPLATEContext>();


            
      // INFO: Added this for Entity Framework Core

      services.AddDbContext<TEMPLATEContext>(options => options.UseMySQL(Configuration["DBInfo:ConnectionString"]));

       
}
  ```
  + Add to **YourController.cs**:
  ```
using Microsoft.EntityFrameworkCore;

using TEMPLATE.Models;
  
private TEMPLATEContext _context;
public HomeController(TEMPLATEContext context)
{

    _context = context;

}
  ```

### 9. Using Entity Framework
  + CP `dotnet add package MySql.Data.EntityFrameworkCore -v 7.0.7-*`.  
  + Add a **TEMPLATEContext.cs** file:
  ```
using Microsoft.EntityFrameworkCore;

namespace TEMPLATE.Models
{
    public class TEMPLATEContext : DbContext
    {
        public TEMPLATEContext(DbContextOptions<TEMPLATEContext> options) : base(options) {}

        // All the SQL tables here.
        // public DbSet<Author> authors { get; set; }        
    }
}
  ```

### 10. Add Session.
  + CP `dotnet add package Microsoft.AspNetCore.Session -v=1.1`.
