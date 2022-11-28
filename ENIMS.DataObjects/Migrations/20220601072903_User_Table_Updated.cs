using Microsoft.EntityFrameworkCore.Migrations;

namespace 
    ENIMS.DataObjects.Migrations
{
    public partial class User_Table_Updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_ClientUser_ClientId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_MasterData_Person_PersonId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_ClientId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_PersonId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "AccountType",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "User");

            migrationBuilder.AddColumn<long>(
                name: "ClientUserId",
                table: "User",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_ClientUserId",
                table: "User",
                column: "ClientUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_ClientUser_ClientUserId",
                table: "User",
                column: "ClientUserId",
                principalTable: "ClientUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_ClientUser_ClientUserId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_ClientUserId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ClientUserId",
                table: "User");

            migrationBuilder.AddColumn<int>(
                name: "AccountType",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "ClientId",
                table: "User",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PersonId",
                table: "User",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SupplierId",
                table: "User",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_ClientId",
                table: "User",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_User_PersonId",
                table: "User",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_ClientUser_ClientId",
                table: "User",
                column: "ClientId",
                principalTable: "ClientUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_MasterData_Person_PersonId",
                table: "User",
                column: "PersonId",
                principalTable: "MasterData_Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
