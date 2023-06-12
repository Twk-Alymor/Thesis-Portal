using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace STIThesisPortal_c.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabaseScripts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ThesisModel",
                columns: table => new
                {
                    accession = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    callNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThesisModel", x => x.accession);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ThesisModel");
        }
    }
}
