## dotNet Package Installation

```bash
dotnet add package Microsoft.AspNetCore.SignalR
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet tool install --global dotnet-ef
dotnet ef migrations add InitChatSchema
dotnet ef database update
```

