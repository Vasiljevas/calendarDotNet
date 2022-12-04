using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalendarApi.Migrations
{
    /// <inheritdoc />
    public partial class blembauseriai : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invitations_Users_InviteeId1",
                table: "Invitations");

            migrationBuilder.DropIndex(
                name: "IX_Invitations_InviteeId1",
                table: "Invitations");

            migrationBuilder.DropColumn(
                name: "InviteeId1",
                table: "Invitations");

            migrationBuilder.AlterColumn<Guid>(
                name: "InviteeId",
                table: "Invitations",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invitations_Users_InviteeId",
                table: "Invitations");

            migrationBuilder.DropIndex(
                name: "IX_Invitations_InviteeId",
                table: "Invitations");

            migrationBuilder.AlterColumn<int>(
                name: "InviteeId",
                table: "Invitations",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddColumn<Guid>(
                name: "InviteeId1",
                table: "Invitations",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Invitations_InviteeId1",
                table: "Invitations",
                column: "InviteeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Invitations_Users_InviteeId1",
                table: "Invitations",
                column: "InviteeId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
