using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AmeliorateAegis.Data.Migrations
{
    public partial class AddedTeacherRelatedEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Centres",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Centres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Periods",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DoB = table.Column<DateTime>(nullable: false),
                    Qualification = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parents",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DoB = table.Column<DateTime>(nullable: false),
                    CentreId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parents_Centres_CentreId",
                        column: x => x.CentreId,
                        principalTable: "Centres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Programs",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CentreId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Programs_Centres_CentreId",
                        column: x => x.CentreId,
                        principalTable: "Centres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LessonPlans",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    Day = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    TeacherId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessonPlans_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pupils",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DoB = table.Column<DateTime>(nullable: false),
                    ParentId = table.Column<long>(nullable: false),
                    CentreId = table.Column<long>(nullable: false),
                    TeacherId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pupils", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pupils_Centres_CentreId",
                        column: x => x.CentreId,
                        principalTable: "Centres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pupils_Parents_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Parents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Pupils_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pro_Centres",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    ProgramId = table.Column<long>(nullable: false),
                    CentreId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pro_Centres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pro_Centres_Centres_CentreId",
                        column: x => x.CentreId,
                        principalTable: "Centres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pro_Centres_Programs_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "Programs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pro_Enrollments",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    PupilId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pro_Enrollments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pro_Enrollments_Pupils_PupilId",
                        column: x => x.PupilId,
                        principalTable: "Pupils",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProgressReports",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PupilId = table.Column<long>(nullable: false),
                    PeriodId = table.Column<long>(nullable: false),
                    ProgramId = table.Column<long>(nullable: false),
                    TeacherId = table.Column<long>(nullable: false),
                    Mark = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgressReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgressReports_Periods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Periods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgressReports_Programs_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "Programs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgressReports_Pupils_PupilId",
                        column: x => x.PupilId,
                        principalTable: "Pupils",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgressReports_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PupilAttendance",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    PupilId = table.Column<long>(nullable: false),
                    TeacherId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PupilAttendance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PupilAttendance_Pupils_PupilId",
                        column: x => x.PupilId,
                        principalTable: "Pupils",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PupilAttendance_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Centres",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "CreationTime", "Name" },
                values: new object[,]
                {
                    { 1L, "123 John Newton SW", "Newton Park", new DateTime(2021, 10, 10, 16, 1, 24, 146, DateTimeKind.Local).AddTicks(4736), "Kabega" },
                    { 2L, "237 John Newton SW", "New Brighton", new DateTime(2021, 10, 10, 16, 1, 24, 148, DateTimeKind.Local).AddTicks(8187), "Sol Futi" },
                    { 3L, "123 John Newton SW", "Newton Park", new DateTime(2021, 10, 10, 16, 1, 24, 148, DateTimeKind.Local).AddTicks(8262), "Daku" }
                });

            migrationBuilder.InsertData(
                table: "Periods",
                columns: new[] { "Id", "CreationTime", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2021, 10, 10, 16, 1, 24, 150, DateTimeKind.Local).AddTicks(6741), "Term 1" },
                    { 2L, new DateTime(2021, 10, 10, 16, 1, 24, 150, DateTimeKind.Local).AddTicks(8011), "Term 2" },
                    { 3L, new DateTime(2021, 10, 10, 16, 1, 24, 150, DateTimeKind.Local).AddTicks(8043), "Term 3" },
                    { 4L, new DateTime(2021, 10, 10, 16, 1, 24, 150, DateTimeKind.Local).AddTicks(8046), "Term 4" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "CreationTime", "DoB", "FirstName", "LastName", "Qualification" },
                values: new object[] { 1L, new DateTime(2021, 10, 10, 16, 1, 24, 150, DateTimeKind.Local).AddTicks(9037), new DateTime(1976, 10, 10, 16, 1, 24, 151, DateTimeKind.Local).AddTicks(661), "Margaret", "Van Hum", "Bachelor Of Education In Child Development" });

            migrationBuilder.InsertData(
                table: "Parents",
                columns: new[] { "Id", "CentreId", "CreationTime", "DoB", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2021, 10, 10, 16, 1, 24, 150, DateTimeKind.Local).AddTicks(2713), new DateTime(1994, 10, 10, 16, 1, 24, 150, DateTimeKind.Local).AddTicks(4538), "Jane", "Pope" },
                    { 5L, 1L, new DateTime(2021, 10, 10, 16, 1, 24, 150, DateTimeKind.Local).AddTicks(5663), new DateTime(1992, 10, 10, 16, 1, 24, 150, DateTimeKind.Local).AddTicks(5666), "Joshua", "Doe" },
                    { 9L, 1L, new DateTime(2021, 10, 10, 16, 1, 24, 150, DateTimeKind.Local).AddTicks(5678), new DateTime(1991, 10, 10, 16, 1, 24, 150, DateTimeKind.Local).AddTicks(5680), "Jongokhaya", "Khwili" },
                    { 2L, 2L, new DateTime(2021, 10, 10, 16, 1, 24, 150, DateTimeKind.Local).AddTicks(5551), new DateTime(1988, 10, 10, 16, 1, 24, 150, DateTimeKind.Local).AddTicks(5608), "Thembeka", "Qweba" },
                    { 4L, 2L, new DateTime(2021, 10, 10, 16, 1, 24, 150, DateTimeKind.Local).AddTicks(5659), new DateTime(1967, 10, 10, 16, 1, 24, 150, DateTimeKind.Local).AddTicks(5660), "Jon", "Doe" },
                    { 7L, 2L, new DateTime(2021, 10, 10, 16, 1, 24, 150, DateTimeKind.Local).AddTicks(5671), new DateTime(1996, 10, 10, 16, 1, 24, 150, DateTimeKind.Local).AddTicks(5673), "Amanda", "Qweba" },
                    { 3L, 3L, new DateTime(2021, 10, 10, 16, 1, 24, 150, DateTimeKind.Local).AddTicks(5653), new DateTime(1976, 10, 10, 16, 1, 24, 150, DateTimeKind.Local).AddTicks(5656), "Jane", "Doe" },
                    { 6L, 3L, new DateTime(2021, 10, 10, 16, 1, 24, 150, DateTimeKind.Local).AddTicks(5668), new DateTime(1972, 10, 10, 16, 1, 24, 150, DateTimeKind.Local).AddTicks(5669), "Thandi", "Newton" },
                    { 8L, 3L, new DateTime(2021, 10, 10, 16, 1, 24, 150, DateTimeKind.Local).AddTicks(5674), new DateTime(2000, 10, 10, 16, 1, 24, 150, DateTimeKind.Local).AddTicks(5676), "Amyoli", "Soze" },
                    { 10L, 3L, new DateTime(2021, 10, 10, 16, 1, 24, 150, DateTimeKind.Local).AddTicks(5682), new DateTime(1989, 10, 10, 16, 1, 24, 150, DateTimeKind.Local).AddTicks(5684), "Thandeka", "Khehle" }
                });

            migrationBuilder.InsertData(
                table: "Programs",
                columns: new[] { "Id", "CentreId", "CreationTime", "Description", "Name" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2021, 10, 10, 16, 1, 24, 151, DateTimeKind.Local).AddTicks(6854), null, "Literacy Development" },
                    { 3L, 1L, new DateTime(2021, 10, 10, 16, 1, 24, 151, DateTimeKind.Local).AddTicks(8560), null, "Song And Music" },
                    { 4L, 1L, new DateTime(2021, 10, 10, 16, 1, 24, 151, DateTimeKind.Local).AddTicks(8562), null, "Art And Music" },
                    { 2L, 2L, new DateTime(2021, 10, 10, 16, 1, 24, 151, DateTimeKind.Local).AddTicks(8517), null, "Math And Science" },
                    { 5L, 3L, new DateTime(2021, 10, 10, 16, 1, 24, 151, DateTimeKind.Local).AddTicks(8564), null, "Language And Speech" }
                });

            migrationBuilder.InsertData(
                table: "Pupils",
                columns: new[] { "Id", "CentreId", "CreationTime", "DoB", "FirstName", "LastName", "ParentId", "TeacherId" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2021, 10, 10, 16, 1, 24, 151, DateTimeKind.Local).AddTicks(2404), new DateTime(2016, 10, 10, 16, 1, 24, 151, DateTimeKind.Local).AddTicks(3921), "Peter", "Pope", 1L, 1L },
                    { 5L, 1L, new DateTime(2021, 10, 10, 16, 1, 24, 151, DateTimeKind.Local).AddTicks(5664), new DateTime(2015, 10, 10, 16, 1, 24, 151, DateTimeKind.Local).AddTicks(5666), "JJ", "Doe", 5L, 1L },
                    { 9L, 1L, new DateTime(2021, 10, 10, 16, 1, 24, 151, DateTimeKind.Local).AddTicks(5684), new DateTime(2017, 10, 10, 16, 1, 24, 151, DateTimeKind.Local).AddTicks(5685), "Khaya", "Khwili", 9L, 1L },
                    { 2L, 2L, new DateTime(2021, 10, 10, 16, 1, 24, 151, DateTimeKind.Local).AddTicks(5550), new DateTime(2017, 10, 10, 16, 1, 24, 151, DateTimeKind.Local).AddTicks(5607), "Amahle", "Qweba", 2L, 1L },
                    { 4L, 2L, new DateTime(2021, 10, 10, 16, 1, 24, 151, DateTimeKind.Local).AddTicks(5659), new DateTime(2017, 10, 10, 16, 1, 24, 151, DateTimeKind.Local).AddTicks(5661), "Jerry", "Doe", 4L, 1L },
                    { 7L, 2L, new DateTime(2021, 10, 10, 16, 1, 24, 151, DateTimeKind.Local).AddTicks(5675), new DateTime(2016, 10, 10, 16, 1, 24, 151, DateTimeKind.Local).AddTicks(5677), "Sinazo", "Qweba", 7L, 1L },
                    { 3L, 3L, new DateTime(2021, 10, 10, 16, 1, 24, 151, DateTimeKind.Local).AddTicks(5654), new DateTime(2016, 10, 10, 16, 1, 24, 151, DateTimeKind.Local).AddTicks(5656), "Junior", "Doe", 3L, 1L },
                    { 6L, 3L, new DateTime(2021, 10, 10, 16, 1, 24, 151, DateTimeKind.Local).AddTicks(5668), new DateTime(2017, 10, 10, 16, 1, 24, 151, DateTimeKind.Local).AddTicks(5673), "Mihle", "Newton", 6L, 1L },
                    { 8L, 3L, new DateTime(2021, 10, 10, 16, 1, 24, 151, DateTimeKind.Local).AddTicks(5680), new DateTime(2015, 10, 10, 16, 1, 24, 151, DateTimeKind.Local).AddTicks(5681), "Buhle", "Soze", 8L, 1L },
                    { 10L, 3L, new DateTime(2021, 10, 10, 16, 1, 24, 151, DateTimeKind.Local).AddTicks(5687), new DateTime(2016, 10, 10, 16, 1, 24, 151, DateTimeKind.Local).AddTicks(5689), "Kubeka", "Khehle", 10L, 1L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LessonPlans_TeacherId",
                table: "LessonPlans",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Parents_CentreId",
                table: "Parents",
                column: "CentreId");

            migrationBuilder.CreateIndex(
                name: "IX_Pro_Centres_CentreId",
                table: "Pro_Centres",
                column: "CentreId");

            migrationBuilder.CreateIndex(
                name: "IX_Pro_Centres_ProgramId",
                table: "Pro_Centres",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Pro_Enrollments_PupilId",
                table: "Pro_Enrollments",
                column: "PupilId");

            migrationBuilder.CreateIndex(
                name: "IX_Programs_CentreId",
                table: "Programs",
                column: "CentreId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgressReports_PeriodId",
                table: "ProgressReports",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgressReports_ProgramId",
                table: "ProgressReports",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgressReports_PupilId",
                table: "ProgressReports",
                column: "PupilId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgressReports_TeacherId",
                table: "ProgressReports",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_PupilAttendance_PupilId",
                table: "PupilAttendance",
                column: "PupilId");

            migrationBuilder.CreateIndex(
                name: "IX_PupilAttendance_TeacherId",
                table: "PupilAttendance",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Pupils_CentreId",
                table: "Pupils",
                column: "CentreId");

            migrationBuilder.CreateIndex(
                name: "IX_Pupils_ParentId",
                table: "Pupils",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Pupils_TeacherId",
                table: "Pupils",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LessonPlans");

            migrationBuilder.DropTable(
                name: "Pro_Centres");

            migrationBuilder.DropTable(
                name: "Pro_Enrollments");

            migrationBuilder.DropTable(
                name: "ProgressReports");

            migrationBuilder.DropTable(
                name: "PupilAttendance");

            migrationBuilder.DropTable(
                name: "Periods");

            migrationBuilder.DropTable(
                name: "Programs");

            migrationBuilder.DropTable(
                name: "Pupils");

            migrationBuilder.DropTable(
                name: "Parents");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Centres");
        }
    }
}
