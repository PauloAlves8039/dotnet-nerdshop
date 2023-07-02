using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NerdShop.WebApp.Migrations
{
    public partial class InsertProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Products(CategoryId,Description,InStock,ImageUrl,IsFavoriteProduct,Name,Price) " +
                "VALUES" +
                "(1,'Camiseta personalizada para programadores',1, 'https://drive.google.com/file/d/1oGRkrCImuKHa3uTtnXiMKvq4idNZsZig/view?usp=sharing', 1 ,'Camiseta Debugar', 79.90)");

            migrationBuilder.Sql("INSERT INTO Products(CategoryId,Description,InStock,ImageUrl,IsFavoriteProduct,Name,Price) " +
                "VALUES" +
                "(2,'Caneca temática para programadores',1, 'https://drive.google.com/file/d/10JXVozu2iC5TzmZk2qu4N1ojnyOsEcJv/view?usp=sharing', 0 ,'Caneca Starbugs', 35.90)");

            migrationBuilder.Sql("INSERT INTO Products(CategoryId,Description,InStock,ImageUrl,IsFavoriteProduct,Name,Price) " +
                "VALUES" +
                "(3,'Chaveiro portátil tema pássaro',1, 'https://drive.google.com/file/d/1Np5sQVPF-0rG3b4zfCuVNKvaDk-_xZTl/view?usp=sharing', 0 ,'Chaveiro Tucano', 10.00)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Products");
        }
    }
}
