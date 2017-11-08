# ASP.NET CORE REFERENCE
Reference to self for how to set up an ASP.NET CORE app.

### 1. Setup App (VS Code, ASP.NET Core 1.0 MVC with Candyman)
  + Make a **main** folder.
  + Add a **test** folder.  
  + Inside the **main** folder, CP `yo candyman <appName>`.
  + Go into the **app** folder, and inside **appName.csproj**, add the following code to setup Watcher tool:  
  ```  
  <ItemGroup>   
  <DotNetCliToolReference Include="Microsoft.DotNet.Watcher.Tools" Version="1.0.0"/>  
  </ItemGroup>  
  ```
  + CP `set ASPNETCORE_ENVIRONMENT=Development`.
  + CP `dotnet restore`.
  + Inside the **test** folder, CP `dotnet new xunit`.
  + CP `dotnet add reference ../<appName>/<appName>.csproj`.
  + Inside **Unit1Test.cs**, add `using <appName>;` and `using <appName>.Controllers;`.

### 2. Using Model Binding & Validations & Partials (VS Code, ASP.NET Core 1.0 MVC with Candyman)
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
            // Handle success
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
  + To add Partials, in your **Example.cshtml**, add `@Html.Partial("ExampleModel")`.
  + To add your model to your Partial, add `@model LoginRegistration.Models.Login`.

### 3. Securing Databases (VS Community, ASP.NET Core 2.0 MVC???)
  + Add to **appsettings.json**:
  ```
{
    "Logging": {
        "IncludeScopes": false,
        "LogLevel": {
            "Default": "Warning"
        }
    },  
    "ConnectionStrings": {  
        "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=PROJECTNAME;Trusted_Connection=True;MultipleActiveResultSets=true"  
    }  
    // "DBInfo":
    // {
    //    "Name": "MySQLconnect",
    //    "ConnectionString": "server=localhost;userid=root;password=root;port=3306;database=DATEBASENAME;SslMode=None"
    // }
}
  ```
  + ~~CP `dotnet add package MySql.Data -v 7.0.7-*`.~~
  + ~~Under a **Properties** folder, created a **MySqlOption.cs** file, and add:~~
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
  + Add to the **Startup.cs** file:
  ```
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

      services.Configure<MySqlOptions>(Configuration.GetSection("DefaultConnection"));

      services.AddScoped<TEMPLATEContext>();


      
      // INFO: Added this for Entity Framework Core

      services.AddDbContext<TEMPLATEContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

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
  + ~~Add packages to **.csproj** file:~~
  ```
<Project Sdk="Microsoft.NET.Sdk.Web">

  <PropertyGroup>

    <TargetFramework>netcoreapp1.1</TargetFramework>

  </PropertyGroup>

  <ItemGroup>

    <PackageReference Include="microsoft.aspnetcore.identity.entityframeworkcore" Version="1.1" />
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

### 4. Using Entity Framework Core (VS Community, ASP.NET Core 2.0 MVC???)
  + ~~CP `dotnet add package MySql.Data.EntityFrameworkCore -v 7.0.7-*`.~~  
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
  + PMC `Install-Package Microsoft.EntityFrameworkCore.SqlServer`.  
  + PMC `Install-Package Microsoft.EntityFrameworkCore.Tools`.  
  + PMC `Install-Package Microsoft.VisualStudio.Web.CodeGeneration.Design`.  
  + PMC `Add-Migration MIGRATIOFILENAME`.  
  + PMC `Update-Database`.  

### 5. View Database. (VS Community, ASP.NET Core 2.0 MVC)
  + **View** > **SQL Server Object Explorer** > find the table database file.  
  + Right-click, **View Designer** or **View Data**.  

### 6. Add Session. (VS Community, ASP.NET Core 2.0 MVC???)
  + ~~CP `dotnet add package Microsoft.AspNetCore.Session -v=1.1`.~~
