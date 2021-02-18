using Microsoft.EntityFrameworkCore.Migrations;

namespace Vaida_Cecilia_Proiect.Migrations
{
    public partial class PublisherName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PublisherID",
                table: "Car",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublisherName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_PublisherID",
                table: "Car",
                column: "PublisherID");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Publisher_PublisherID",
                table: "Car",
                column: "PublisherID",
                principalTable: "Publisher",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_Publisher_PublisherID",
                table: "Car");

            migrationBuilder.DropTable(
                name: "Publisher");

            migrationBuilder.DropIndex(
                name: "IX_Car_PublisherID",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "PublisherID",
                table: "Car");
        }
    }
}
