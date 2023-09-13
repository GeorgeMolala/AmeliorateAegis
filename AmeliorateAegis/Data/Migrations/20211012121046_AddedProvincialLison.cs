using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AmeliorateAegis.Data.Migrations
{
    public partial class AddedProvincialLison : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Financials",
                columns: table => new
                {
                    FinancialId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    amount = table.Column<string>(nullable: true),
                    regionCost = table.Column<string>(nullable: true),
                    Day = table.Column<string>(nullable: true),
                    centerName = table.Column<string>(nullable: true),
                    Prov = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: false),
                    Region = table.Column<string>(nullable: false),
                    totalAmount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Financials", x => x.FinancialId);
                });

            migrationBuilder.CreateTable(
                name: "Meetings",
                columns: table => new
                {
                    MeetingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    Reason = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetings", x => x.MeetingID);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    DOB = table.Column<string>(nullable: false),
                    FullNames = table.Column<string>(nullable: true),
                    Occupation = table.Column<string>(nullable: false),
                    PhoneNo = table.Column<string>(nullable: false),
                    PhysicalAddress = table.Column<string>(nullable: false),
                    ProfilePicture = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regionals",
                columns: table => new
                {
                    RegionalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regionals", x => x.RegionalId);
                });


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Financials");

            migrationBuilder.DropTable(
                name: "Meetings");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Regionals");
        }
    }
}
