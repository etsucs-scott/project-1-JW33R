
## Getting Started (CLI)

You may use **Visual Studio**, **VS Code**, or the **terminal**.

### Create a solution
```bash
dotnet new sln -n ProjectName
```

### Create a project (example: console app)
```bash
dotnet new console -n ProjectName.App
```

### Add the project to the solution
```bash
dotnet sln add ProjectName.App
```

### Build and run
```bash
dotnet build
dotnet run --project ProjectName.App
```
