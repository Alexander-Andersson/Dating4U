using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class miFriends : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friends_User_User1Id",
                table: "Friends");

            migrationBuilder.DropForeignKey(
                name: "FK_Friends_User_User2Id",
                table: "Friends");

            migrationBuilder.RenameColumn(
                name: "User2Id",
                table: "Friends",
                newName: "Friend_2Id");

            migrationBuilder.RenameColumn(
                name: "User1Id",
                table: "Friends",
                newName: "Friend_1Id");

            migrationBuilder.RenameIndex(
                name: "IX_Friends_User2Id",
                table: "Friends",
                newName: "IX_Friends_Friend_2Id");

            migrationBuilder.RenameIndex(
                name: "IX_Friends_User1Id",
                table: "Friends",
                newName: "IX_Friends_Friend_1Id");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Friends",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Friends",
                table: "Friends",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_User_Friend_1Id",
                table: "Friends",
                column: "Friend_1Id",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_User_Friend_2Id",
                table: "Friends",
                column: "Friend_2Id",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friends_User_Friend_1Id",
                table: "Friends");

            migrationBuilder.DropForeignKey(
                name: "FK_Friends_User_Friend_2Id",
                table: "Friends");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Friends",
                table: "Friends");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Friends");

            migrationBuilder.RenameColumn(
                name: "Friend_2Id",
                table: "Friends",
                newName: "User2Id");

            migrationBuilder.RenameColumn(
                name: "Friend_1Id",
                table: "Friends",
                newName: "User1Id");

            migrationBuilder.RenameIndex(
                name: "IX_Friends_Friend_2Id",
                table: "Friends",
                newName: "IX_Friends_User2Id");

            migrationBuilder.RenameIndex(
                name: "IX_Friends_Friend_1Id",
                table: "Friends",
                newName: "IX_Friends_User1Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_User_User1Id",
                table: "Friends",
                column: "User1Id",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_User_User2Id",
                table: "Friends",
                column: "User2Id",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
