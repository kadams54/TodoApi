# TodoApi
Replicating EF Core behavior where seeded boolean fields are continually updated in every migration, in the example TodoApi app.

I asked this question in StackOverflow: ["Why does EF Core update seeded boolean fields on every migration, despite no changes being made?"](https://stackoverflow.com/questions/64199132/why-does-ef-core-update-seeded-boolean-fields-on-every-migration-despite-no-cha?noredirect=1#comment113528084_64199132) This repository exists to replicate the behavior observed in [the TodoApi app that is created as part of ASP.NET core's intro tutorial](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-3.1&tabs=visual-studio-code).

To test locally:

1. `dotnet tool install --global dotnet-ef` - if you don't already have the EF CLI tools
1. `docker-compose up -d` - this assumes you're already running [Docker Desktop](https://www.docker.com/products/docker-desktop)
1. `dotnet ef database update`
1. `dotnet ef migrations add AnotherEmptyMigration`

Examine the newly-created migration, which should be empty. Instead, you'll see:

```csharp
using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoApi.Migrations
{
    public partial class AnotherEmptyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TodoItems",
                keyColumn: "Id",
                keyValue: 1L,
                column: "IsComplete",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TodoItems",
                keyColumn: "Id",
                keyValue: 1L,
                column: "IsComplete",
                value: true);
        }
    }
}
```
