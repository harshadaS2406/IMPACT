using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InboxService.Migrations
{
    public partial class inboxserv_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    NoteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderId = table.Column<int>(nullable: false),
                    SenderName = table.Column<string>(nullable: true),
                    SenderDesignation = table.Column<string>(nullable: true),
                    ReceiverId = table.Column<int>(nullable: false),
                    ReceiveName = table.Column<string>(nullable: true),
                    ReceiverDesignation = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    ReplyId = table.Column<int>(nullable: true),
                    IsResponded = table.Column<bool>(nullable: false),
                    IsUrgent = table.Column<bool>(nullable: false),
                    DeleteFlag = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.NoteId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");
        }
    }
}
