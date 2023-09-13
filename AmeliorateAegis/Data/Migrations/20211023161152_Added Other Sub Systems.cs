using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AmeliorateAegis.Data.Migrations
{
    public partial class AddedOtherSubSystems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LessonPlans_Teachers_TeacherId",
                table: "LessonPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgressReports_Teachers_TeacherId",
                table: "ProgressReports");

            migrationBuilder.DropForeignKey(
                name: "FK_PupilAttendance_Teachers_TeacherId",
                table: "PupilAttendance");

            migrationBuilder.DropForeignKey(
                name: "FK_Pupils_Parents_ParentId",
                table: "Pupils");

            migrationBuilder.DropForeignKey(
                name: "FK_Pupils_Teachers_TeacherId",
                table: "Pupils");

            migrationBuilder.DropTable(
                name: "Parents");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DeleteData(
                table: "Pupils",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Pupils",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Pupils",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Pupils",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Pupils",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Pupils",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Pupils",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Pupils",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Pupils",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Pupils",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.AlterColumn<string>(
                name: "TeacherId",
                table: "Pupils",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ParentId",
                table: "Pupils",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<string>(
                name: "AddressLine1",
                table: "Pupils",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressLine2",
                table: "Pupils",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Pupils",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "Pupils",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Suburb",
                table: "Pupils",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TeacherId",
                table: "PupilAttendance",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "TeacherId",
                table: "ProgressReports",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "ProgrammeId",
                table: "Pro_Enrollments",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<string>(
                name: "TeacherId",
                table: "LessonPlans",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "LessonPlans",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Centres",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Centres",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "Centres",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Suburb",
                table: "Centres",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DoB",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Teacher_DoB",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Qualification",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ScheduleVisits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitDescr = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Time = table.Column<string>(nullable: true),
                    Duration = table.Column<string>(nullable: true),
                    ReasonForVisit = table.Column<string>(nullable: true),
                    RegionalId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleVisits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleVisits_AspNetUsers_RegionalId",
                        column: x => x.RegionalId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pro_Enrollments_ProgrammeId",
                table: "Pro_Enrollments",
                column: "ProgrammeId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleVisits_RegionalId",
                table: "ScheduleVisits",
                column: "RegionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_LessonPlans_AspNetUsers_TeacherId",
                table: "LessonPlans",
                column: "TeacherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pro_Enrollments_Programs_ProgrammeId",
                table: "Pro_Enrollments",
                column: "ProgrammeId",
                principalTable: "Programs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgressReports_AspNetUsers_TeacherId",
                table: "ProgressReports",
                column: "TeacherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PupilAttendance_AspNetUsers_TeacherId",
                table: "PupilAttendance",
                column: "TeacherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pupils_AspNetUsers_ParentId",
                table: "Pupils",
                column: "ParentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pupils_AspNetUsers_TeacherId",
                table: "Pupils",
                column: "TeacherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LessonPlans_AspNetUsers_TeacherId",
                table: "LessonPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_Pro_Enrollments_Programs_ProgrammeId",
                table: "Pro_Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgressReports_AspNetUsers_TeacherId",
                table: "ProgressReports");

            migrationBuilder.DropForeignKey(
                name: "FK_PupilAttendance_AspNetUsers_TeacherId",
                table: "PupilAttendance");

            migrationBuilder.DropForeignKey(
                name: "FK_Pupils_AspNetUsers_ParentId",
                table: "Pupils");

            migrationBuilder.DropForeignKey(
                name: "FK_Pupils_AspNetUsers_TeacherId",
                table: "Pupils");

            migrationBuilder.DropTable(
                name: "ScheduleVisits");

            migrationBuilder.DropIndex(
                name: "IX_Pro_Enrollments_ProgrammeId",
                table: "Pro_Enrollments");

            migrationBuilder.DropColumn(
                name: "AddressLine1",
                table: "Pupils");

            migrationBuilder.DropColumn(
                name: "AddressLine2",
                table: "Pupils");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Pupils");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "Pupils");

            migrationBuilder.DropColumn(
                name: "Suburb",
                table: "Pupils");

            migrationBuilder.DropColumn(
                name: "ProgrammeId",
                table: "Pro_Enrollments");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Centres");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Centres");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "Centres");

            migrationBuilder.DropColumn(
                name: "Suburb",
                table: "Centres");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DoB",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Teacher_DoB",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Qualification",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<long>(
                name: "TeacherId",
                table: "Pupils",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ParentId",
                table: "Pupils",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "TeacherId",
                table: "PupilAttendance",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "TeacherId",
                table: "ProgressReports",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "TeacherId",
                table: "LessonPlans",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "LessonPlans",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateTable(
                name: "Parents",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CentreId = table.Column<long>(type: "bigint", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DoB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DoB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qualification = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });
           
            migrationBuilder.CreateIndex(
                name: "IX_Parents_CentreId",
                table: "Parents",
                column: "CentreId");

            migrationBuilder.AddForeignKey(
                name: "FK_LessonPlans_Teachers_TeacherId",
                table: "LessonPlans",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgressReports_Teachers_TeacherId",
                table: "ProgressReports",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PupilAttendance_Teachers_TeacherId",
                table: "PupilAttendance",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pupils_Parents_ParentId",
                table: "Pupils",
                column: "ParentId",
                principalTable: "Parents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pupils_Teachers_TeacherId",
                table: "Pupils",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
