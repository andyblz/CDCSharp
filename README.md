# ASP.NET CORE REFERENCE

### 1. Setup App
  + Make a **main** folder.
  + Add a **test** folder.

### 2. Inside **Main** Folder
  + Inside the **main** folder, CP `yo candyman <appName>`.
  + Go into the **app** folder, and inside **appName.csproj**, add the following code:  
  `<ItemGroup>`  
    `<DotNetCliToolReference Include="Microsoft.DotNet.Watcher.Tools" Version="1.0.0"/>`  
   `</ItemGroup>`
  + CP `set ASPNETCORE_ENVIRONMENT=Development`.

### 3. Inside **Test** Folder
  + CP `dotnet new xunit`.
  + CP `dotnet add reference ../<appName>/<appName>.csproj`.
  + Inside **Unit1Test.cs**, add `using <appName>;` and `using <appName>.Controllers;`.