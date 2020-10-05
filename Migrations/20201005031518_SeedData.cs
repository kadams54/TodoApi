using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoApi.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsComplete",
                table: "TodoItems",
                nullable: true,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.InsertData(
                table: "TodoItems",
                columns: new[] { "Id", "IsComplete", "Name" },
                values: new object[] { 1L, true, "First Item" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TodoItems",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.AlterColumn<bool>(
                name: "IsComplete",
                table: "TodoItems",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true,
                oldDefaultValue: true);
        }
    }
}
