# ASP.NET CORE REFERENCE

#### 1. Setup App
  + Make a **main** folder.
  + Add a **test** folder.

#### 2. Inside **Main** Folder
  + Inside the **main** folder, `yo candyman <appName>`.

#### 3. Inside **Test** Folder
  + `dotnet new xunit`.
  + `dotnet add reference ../<appName>/<appName>.csproj`.
  + Inside the **Unit1Test.cs**, add `using <appName>;` and `using <appName>.Controllers;`.