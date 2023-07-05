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
                "(1,'Camiseta personalizada anos 80',1, 'https://nerdstore.com.br/wp-content/uploads/2022/02/vitrine-camiseta-80s-blowup-estampa-nerdstore.jpg.webp', 1 ,'Camiseta anos 80', 75.90)");

            migrationBuilder.Sql("INSERT INTO Products(CategoryId,Description,InStock,ImageUrl,IsFavoriteProduct,Name,Price) " +
                "VALUES" +
                "(2,'Caneca temática sem internet',1, 'https://nerdstore.com.br/wp-content/uploads/2023/01/caneca-offline-park-1.jpg.webp', 0 ,'Caneca Offline', 35.90)");

            migrationBuilder.Sql("INSERT INTO Products(CategoryId,Description,InStock,ImageUrl,IsFavoriteProduct,Name,Price) " +
                "VALUES" +
                "(3,'Chaveiro portátil tema game',1, 'https://nerdstore.com.br/wp-content/uploads/2022/12/a639d7cab75f7d8229a18b9d73900045.jpg.webp', 1 ,'Chaveiro GameBoy', 4.00)");

            migrationBuilder.Sql("INSERT INTO Products(CategoryId,Description,InStock,ImageUrl,IsFavoriteProduct,Name,Price) " +
                "VALUES" +
                "(1,'Chaveiro portátil tema game',1, 'https://nerdstore.com.br/wp-content/uploads/2023/06/vitrine-camiseta-come-to-the-nerdside-estampa-nerdstore.jpg.webp', 0 ,'Camiseta Nerd Side', 79.90)");

            migrationBuilder.Sql("INSERT INTO Products(CategoryId,Description,InStock,ImageUrl,IsFavoriteProduct,Name,Price) " +
                "VALUES" +
                "(2,'Caneca temática Senhor dos Áneis',1, 'https://nerdstore.com.br/wp-content/uploads/2023/01/caneca-a-jornada-3-1.jpg.webp', 1 ,'Caneca A Sociedade do Anel', 65.90)");

            migrationBuilder.Sql("INSERT INTO Products(CategoryId,Description,InStock,ImageUrl,IsFavoriteProduct,Name,Price) " +
                "VALUES" +
                "(3,'Chaveiro portátil tema Harry Potter',1, 'https://nerdstore.com.br/wp-content/uploads/2020/11/chaveiro-varinha-das-varinhas-harry-potter-01.jpg.webp', 0 ,'Chaveiro Harry Potter', 10.00)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Products");
        }
    }
}
