using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class LatestVisitors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LatestVisitors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileVisitedId = table.Column<int>(type: "int", nullable: true),
                    VisitedById = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LatestVisitors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LatestVisitors_User_ProfileVisitedId",
                        column: x => x.ProfileVisitedId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LatestVisitors_User_VisitedById",
                        column: x => x.VisitedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LatestVisitors_ProfileVisitedId",
                table: "LatestVisitors",
                column: "ProfileVisitedId");

            migrationBuilder.CreateIndex(
                name: "IX_LatestVisitors_VisitedById",
                table: "LatestVisitors",
                column: "VisitedById");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LatestVisitors");
        }
    }
}
