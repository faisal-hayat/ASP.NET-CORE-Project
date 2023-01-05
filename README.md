# Example Project in ASP.NET CORE


--- ---
## First Example Project

- A simple **_Web Form_** 
- Let's write the code
--- ---
## Routing in MVC
### General pattern for routing in MVC
```C#
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
```
--- ---
## Adding Database Connection in .NET CORE

- Connection string in **_appsettings.json_**
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=DESKTOP-6DNJ4RQ;Database=Bulky;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

- Db Context File 
```C#
using ExampleProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace ExampleProject.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
    }
}
```

- Final settings is add it to the **_program.cs_** file

```C#
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));
```
--- ---
## Tools That needs to be instaleld

- EntityFrameworkCore
- EntityFrameworkCore.SqlServer
- EntityFrameworkCore.Tools
--- ---
## Commands for migrating the database

```shell
make-migration [migration_name]
update-database
```
--- ---