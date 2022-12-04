using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalendarApi.Migrations
{
    /// <inheritdoc />
    public partial class Users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Calendars_CalendarId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_EventUser_Event_EventsId",
                table: "EventUser");

            migrationBuilder.DropForeignKey(
                name: "FK_EventUser_User_AttendeesId",
                table: "EventUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Invitation_User_InviteeId",
                table: "Invitation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invitation",
                table: "Invitation");

            migrationBuilder.DropIndex(
                name: "IX_Invitation_InviteeId",
                table: "Invitation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Event",
                table: "Event");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Invitation",
                newName: "Invitations");

            migrationBuilder.RenameTable(
                name: "Event",
                newName: "Events");

            migrationBuilder.RenameColumn(
                name: "UserRole",
                table: "Users",
                newName: "Role");

            migrationBuilder.RenameIndex(
                name: "IX_Event_CalendarId",
                table: "Events",
                newName: "IX_Events_CalendarId");

            migrationBuilder.AlterColumn<Guid>(
                name: "AttendeesId",
                table: "EventUser",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Users",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<Guid>(
                name: "InviteeId1",
                table: "Invitations",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invitations",
                table: "Invitations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Events",
                table: "Events",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Invitations_InviteeId1",
                table: "Invitations",
                column: "InviteeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Calendars_CalendarId",
                table: "Events",
                column: "CalendarId",
                principalTable: "Calendars",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventUser_Events_EventsId",
                table: "EventUser",
                column: "EventsId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventUser_Users_AttendeesId",
                table: "EventUser",
                column: "AttendeesId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invitations_Users_InviteeId1",
                table: "Invitations",
                column: "InviteeId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Calendars_CalendarId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_EventUser_Events_EventsId",
                table: "EventUser");

            migrationBuilder.DropForeignKey(
                name: "FK_EventUser_Users_AttendeesId",
                table: "EventUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Invitations_Users_InviteeId1",
                table: "Invitations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invitations",
                table: "Invitations");

            migrationBuilder.DropIndex(
                name: "IX_Invitations_InviteeId1",
                table: "Invitations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Events",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "InviteeId1",
                table: "Invitations");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Invitations",
                newName: "Invitation");

            migrationBuilder.RenameTable(
                name: "Events",
                newName: "Event");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "User",
                newName: "UserRole");

            migrationBuilder.RenameIndex(
                name: "IX_Events_CalendarId",
                table: "Event",
                newName: "IX_Event_CalendarId");

            migrationBuilder.AlterColumn<int>(
                name: "AttendeesId",
                table: "EventUser",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "User",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invitation",
                table: "Invitation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Event",
                table: "Event",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Invitation_InviteeId",
                table: "Invitation",
                column: "InviteeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Calendars_CalendarId",
                table: "Event",
                column: "CalendarId",
                principalTable: "Calendars",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventUser_Event_EventsId",
                table: "EventUser",
                column: "EventsId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventUser_User_AttendeesId",
                table: "EventUser",
                column: "AttendeesId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invitation_User_InviteeId",
                table: "Invitation",
                column: "InviteeId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
