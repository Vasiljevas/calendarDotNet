using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalendarApi.Migrations
{
    /// <inheritdoc />
    public partial class invatiaiff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invitations_Users_InviteeId",
                table: "Invitations");

            migrationBuilder.DropIndex(
                name: "IX_Invitations_InviteeId",
                table: "Invitations");

            migrationBuilder.RenameColumn(
                name: "Message",
                table: "Invitations",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "InviteeId",
                table: "Invitations",
                newName: "EventId");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Invitations",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "AuthorName",
                table: "Invitations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Invitations_UserId",
                table: "Invitations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invitations_Users_UserId",
                table: "Invitations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invitations_Users_UserId",
                table: "Invitations");

            migrationBuilder.DropIndex(
                name: "IX_Invitations_UserId",
                table: "Invitations");

            migrationBuilder.DropColumn(
                name: "AuthorName",
                table: "Invitations");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Invitations",
                newName: "Message");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "Invitations",
                newName: "InviteeId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Invitations",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateIndex(
                name: "IX_Invitations_InviteeId",
                table: "Invitations",
                column: "InviteeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invitations_Users_InviteeId",
                table: "Invitations",
                column: "InviteeId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
