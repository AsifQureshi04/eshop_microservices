using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Discount.Grpc.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coupon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductName = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupon", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Coupon",
                columns: new[] { "Id", "Amount", "Description", "ProductName" },
                values: new object[,]
                {
                    { 1, 200, "Latest Apple iPhone", "iPhone X" },
                    { 2, 150, "Flagship Samsung phone", "Samsung Galaxy S21" },
                    { 3, 300, "Apple MacBook with M1 chip", "MacBook Pro" },
                    { 4, 250, "Premium Windows laptop", "Dell XPS 13" },
                    { 5, 100, "Noise-canceling headphones", "Sony WH-1000XM4" },
                    { 6, 120, "Smartwatch with fitness tracking", "Apple Watch Series 7" },
                    { 7, 180, "Apple iPad with M1 chip", "iPad Pro" },
                    { 8, 90, "Popular gaming console", "Nintendo Switch" },
                    { 9, 80, "Bluetooth speaker with deep bass", "Bose SoundLink" },
                    { 10, 160, "Google's latest flagship phone", "Google Pixel 6" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coupon");
        }
    }
}
