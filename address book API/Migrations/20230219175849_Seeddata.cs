using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace address_book_API.Migrations
{
    public partial class Seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
               table: "Departments",
               columns: new[] { "Name" },
               values: new object[] { "DotNet" }
           );
            migrationBuilder.InsertData(
               table: "Jobs",
               columns: new[] { "Name" },
               values: new object[] { "DotNet_developer" }
           );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [Departments]");
            migrationBuilder.Sql("DELETE FROM [Jobs]");
        }
    }
}
