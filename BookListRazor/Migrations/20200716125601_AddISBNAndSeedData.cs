using Microsoft.EntityFrameworkCore.Migrations;

namespace BookListRazor.Migrations
{
    public partial class AddISBNAndSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ISBN",
                table: "Book",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "Author", "ISBN", "Name" },
                values: new object[,]
                {
                    { 1, null, null, "Book name 1" },
                    { 2, "Author 1", null, "Book name 2" },
                    { 3, "Author 1", null, "Book name 3" },
                    { 4, "Author 1", "234234234234", "Book name 4" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "ISBN",
                table: "Book");
        }
    }
}
