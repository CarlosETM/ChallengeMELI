using Microsoft.EntityFrameworkCore.Migrations;

namespace TopSecret.API.Migrations
{
    public partial class firstMigrationQuasar1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Satellite",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(maxLength: 50, nullable: false),
                    postionX = table.Column<string>(nullable: true),
                    postionY = table.Column<string>(nullable: true),
                    word1 = table.Column<string>(nullable: true),
                    word2 = table.Column<string>(nullable: true),
                    word3 = table.Column<string>(nullable: true),
                    word4 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Satellite", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Satellite");
        }
    }
}
