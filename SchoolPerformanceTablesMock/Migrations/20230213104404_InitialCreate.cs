using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolPerformanceTablesMock.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "School",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    SchoolType = table.Column<string>(type: "TEXT", nullable: true),
                    MinAge = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxAge = table.Column<int>(type: "INTEGER", nullable: false),
                    OfstedRating = table.Column<string>(type: "TEXT", nullable: true),
                    Website = table.Column<string>(type: "TEXT", nullable: true),
                    EducationPhase = table.Column<string>(type: "TEXT", nullable: true),
                    LocalAuthority = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "School");
        }
    }
}
