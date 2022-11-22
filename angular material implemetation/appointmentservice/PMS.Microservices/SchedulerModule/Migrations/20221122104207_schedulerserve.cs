using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchedulerModule.Migrations
{
    public partial class schedulerserve : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Slots",
                columns: table => new
                {
                    SlotId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SlotTiming = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SlotStart = table.Column<TimeSpan>(type: "time", nullable: false),
                    SlotEnd = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slots", x => x.SlotId);
                });

            migrationBuilder.CreateTable(
                name: "visitStatuses",
                columns: table => new
                {
                    VisitStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitStatusName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_visitStatuses", x => x.VisitStatusId);
                });

            migrationBuilder.CreateTable(
                name: "appointmentDetails",
                columns: table => new
                {
                    VisitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisitDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    doctorId = table.Column<int>(type: "int", nullable: false),
                    patientId = table.Column<int>(type: "int", nullable: false),
                    visitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppointmentStartdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AppointmentEnddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SlotId = table.Column<int>(type: "int", nullable: false),
                    createdBy = table.Column<int>(type: "int", nullable: false),
                    createdOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedBy = table.Column<int>(type: "int", nullable: false),
                    updatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    visitStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointmentDetails", x => x.VisitId);
                    table.ForeignKey(
                        name: "FK_appointmentDetails_visitStatuses_visitStatusId",
                        column: x => x.visitStatusId,
                        principalTable: "visitStatuses",
                        principalColumn: "VisitStatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Slots",
                columns: new[] { "SlotId", "SlotEnd", "SlotStart", "SlotTiming" },
                values: new object[,]
                {
                    { 1, new TimeSpan(0, 11, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0), "10AM - 11AM" },
                    { 2, new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 11, 0, 0, 0), "11 AM - 12 PM" },
                    { 3, new TimeSpan(0, 13, 0, 0, 0), new TimeSpan(0, 12, 0, 0, 0), "12 PM - 1 PM" },
                    { 4, new TimeSpan(0, 14, 0, 0, 0), new TimeSpan(0, 13, 0, 0, 0), "1 PM - 2PM" },
                    { 5, new TimeSpan(0, 15, 0, 0, 0), new TimeSpan(0, 14, 0, 0, 0), "2 PM - 3 PM" },
                    { 6, new TimeSpan(0, 16, 0, 0, 0), new TimeSpan(0, 15, 0, 0, 0), "3 PM - 4 PM" },
                    { 7, new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 16, 0, 0, 0), "4 PM - 5 PM" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointmentDetails_visitStatusId",
                table: "appointmentDetails",
                column: "visitStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "appointmentDetails");

            migrationBuilder.DropTable(
                name: "Slots");

            migrationBuilder.DropTable(
                name: "visitStatuses");
        }
    }
}
