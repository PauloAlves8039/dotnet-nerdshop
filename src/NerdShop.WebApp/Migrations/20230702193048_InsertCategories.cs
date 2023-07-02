using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NerdShop.WebApp.Migrations
{
    public partial class InsertCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categories(CategoryName, Description) VALUES ('Camiseta', 'Camisetas temáticas')");
            migrationBuilder.Sql("INSERT INTO Categories(CategoryName, Description) VALUES ('Caneca', 'Canecas diversas')");
            migrationBuilder.Sql("INSERT INTO Categories(CategoryName, Description) VALUES ('Chaveiro', 'Chaveiros Portáteis')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categories");
        }
    }
}
