using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class miFriendreq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FriendRequests_User_RecieverId",
                table: "FriendRequests");

            migrationBuilder.RenameColumn(
                name: "RecieverId",
                table: "FriendRequests",
                newName: "ReceiverId");

            migrationBuilder.RenameIndex(
                name: "IX_FriendRequests_RecieverId",
                table: "FriendRequests",
                newName: "IX_FriendRequests_ReceiverId");

            migrationBuilder.AddForeignKey(
                name: "FK_FriendRequests_User_ReceiverId",
                table: "FriendRequests",
                column: "ReceiverId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FriendRequests_User_ReceiverId",
                table: "FriendRequests");

            migrationBuilder.RenameColumn(
                name: "ReceiverId",
                table: "FriendRequests",
                newName: "RecieverId");

            migrationBuilder.RenameIndex(
                name: "IX_FriendRequests_ReceiverId",
                table: "FriendRequests",
                newName: "IX_FriendRequests_RecieverId");

            migrationBuilder.AddForeignKey(
                name: "FK_FriendRequests_User_RecieverId",
                table: "FriendRequests",
                column: "RecieverId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
