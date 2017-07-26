using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DatekCCAN.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseID = table.Column<int>(nullable: false),
                    Credits = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseID);
                });

            migrationBuilder.CreateTable(
                name: "Datek",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AO = table.Column<string>(nullable: true),
                    Alamat = table.Column<string>(nullable: true),
                    AreaCode = table.Column<string>(nullable: true),
                    Dat = table.Column<string>(nullable: true),
                    Gpon = table.Column<string>(nullable: true),
                    Komen = table.Column<string>(nullable: true),
                    KomenItenos = table.Column<string>(nullable: true),
                    Metro = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Pic = table.Column<string>(nullable: true),
                    SID = table.Column<string>(nullable: true),
                    SN = table.Column<string>(nullable: true),
                    ServiceOrder = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    TQ = table.Column<string>(nullable: true),
                    TaggingODP = table.Column<string>(nullable: true),
                    TaggingPelanggan = table.Column<string>(nullable: true),
                    TeknisiPTmin1 = table.Column<string>(nullable: true),
                    TeknisiSurvei = table.Column<string>(nullable: true),
                    TglClosed = table.Column<DateTime>(nullable: false),
                    TglHasilSurvei = table.Column<DateTime>(nullable: false),
                    TglJTSelesai = table.Column<DateTime>(nullable: false),
                    TglOrderItenos = table.Column<DateTime>(nullable: false),
                    TglPerintahJT = table.Column<DateTime>(nullable: false),
                    TglPerintahPT1 = table.Column<DateTime>(nullable: false),
                    TglPerintahSurvei = table.Column<DateTime>(nullable: false),
                    TglSelesaiPTmin1 = table.Column<DateTime>(nullable: false),
                    Vlan = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Datek", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Enrollment",
                columns: table => new
                {
                    EnrollmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseID = table.Column<int>(nullable: false),
                    DatekID = table.Column<int>(nullable: true),
                    Grade = table.Column<int>(nullable: true),
                    StudentID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollment", x => x.EnrollmentID);
                    table.ForeignKey(
                        name: "FK_Enrollment_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollment_Datek_DatekID",
                        column: x => x.DatekID,
                        principalTable: "Datek",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_CourseID",
                table: "Enrollment",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_DatekID",
                table: "Enrollment",
                column: "DatekID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollment");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Datek");
        }
    }
}
