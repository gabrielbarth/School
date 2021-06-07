using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace School.Repository.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseID);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enrolment = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BornDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EnrolmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TerminationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentID);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    TeacherID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Registry = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnrolmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TerminationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.TeacherID);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourses",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    InitialDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinalDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourses", x => new { x.StudentID, x.CourseID });
                    table.ForeignKey(
                        name: "FK_StudentCourses_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourses_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    SubjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Workload = table.Column<int>(type: "int", nullable: false),
                    PrerequisiteID = table.Column<int>(type: "int", nullable: true),
                    TeacherID = table.Column<int>(type: "int", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.SubjectID);
                    table.ForeignKey(
                        name: "FK_Subjects_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subjects_Subjects_PrerequisiteID",
                        column: x => x.PrerequisiteID,
                        principalTable: "Subjects",
                        principalColumn: "SubjectID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subjects_Teachers_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "Teachers",
                        principalColumn: "TeacherID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentSubjects",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    SubjectID = table.Column<int>(type: "int", nullable: false),
                    InitialDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Grade = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSubjects", x => new { x.StudentID, x.SubjectID });
                    table.ForeignKey(
                        name: "FK_StudentSubjects_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentSubjects_Subjects_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "Subjects",
                        principalColumn: "SubjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseID", "Name" },
                values: new object[,]
                {
                    { 1, "Tecnologia da Informação" },
                    { 2, "Sistemas de Informação" },
                    { 3, "Ciência da Computação" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentID", "Active", "BornDate", "Enrolment", "EnrolmentDate", "LastName", "Name", "Phone", "TerminationDate" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2021, 6, 6, 11, 45, 48, 497, DateTimeKind.Local).AddTicks(2307), "Kent", "Marta", "33225555", null },
                    { 2, true, new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2021, 6, 6, 11, 45, 48, 497, DateTimeKind.Local).AddTicks(5580), "Isabela", "Paula", "3354288", null },
                    { 3, true, new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2021, 6, 6, 11, 45, 48, 497, DateTimeKind.Local).AddTicks(5648), "Antonia", "Laura", "55668899", null },
                    { 4, true, new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2021, 6, 6, 11, 45, 48, 497, DateTimeKind.Local).AddTicks(5654), "Maria", "Luiza", "6565659", null },
                    { 5, true, new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2021, 6, 6, 11, 45, 48, 497, DateTimeKind.Local).AddTicks(5659), "Machado", "Lucas", "565685415", null },
                    { 6, true, new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, new DateTime(2021, 6, 6, 11, 45, 48, 497, DateTimeKind.Local).AddTicks(5668), "Alvares", "Pedro", "456454545", null },
                    { 7, true, new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, new DateTime(2021, 6, 6, 11, 45, 48, 497, DateTimeKind.Local).AddTicks(5673), "José", "Paulo", "9874512", null }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "TeacherID", "Active", "EnrolmentDate", "LastName", "Name", "Phone", "Registry", "TerminationDate" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2021, 6, 6, 11, 45, 48, 491, DateTimeKind.Local).AddTicks(6253), "Oliveira", "Lauro", null, 1, null },
                    { 2, true, new DateTime(2021, 6, 6, 11, 45, 48, 493, DateTimeKind.Local).AddTicks(1623), "Soares", "Roberto", null, 2, null },
                    { 3, true, new DateTime(2021, 6, 6, 11, 45, 48, 493, DateTimeKind.Local).AddTicks(1740), "Marconi", "Ronaldo", null, 3, null },
                    { 4, true, new DateTime(2021, 6, 6, 11, 45, 48, 493, DateTimeKind.Local).AddTicks(1743), "Carvalho", "Rodrigo", null, 4, null },
                    { 5, true, new DateTime(2021, 6, 6, 11, 45, 48, 493, DateTimeKind.Local).AddTicks(1745), "Montanha", "Alexandre", null, 5, null }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "SubjectID", "CourseID", "Name", "PrerequisiteID", "TeacherID", "Workload" },
                values: new object[,]
                {
                    { 1, 1, "Matemática", null, 1, 0 },
                    { 2, 3, "Matemática", null, 1, 0 },
                    { 3, 3, "Física", null, 2, 0 },
                    { 4, 1, "Português", null, 3, 0 },
                    { 5, 1, "Inglês", null, 4, 0 },
                    { 6, 2, "Inglês", null, 4, 0 },
                    { 7, 3, "Inglês", null, 4, 0 },
                    { 8, 1, "Programação", null, 5, 0 },
                    { 9, 2, "Programação", null, 5, 0 },
                    { 10, 3, "Programação", null, 5, 0 }
                });

            migrationBuilder.InsertData(
                table: "StudentSubjects",
                columns: new[] { "StudentID", "SubjectID", "FinalDate", "Grade", "InitialDate" },
                values: new object[,]
                {
                    { 2, 1, null, null, new DateTime(2021, 6, 6, 11, 45, 48, 497, DateTimeKind.Local).AddTicks(8533) },
                    { 4, 5, null, null, new DateTime(2021, 6, 6, 11, 45, 48, 497, DateTimeKind.Local).AddTicks(8584) },
                    { 2, 5, null, null, new DateTime(2021, 6, 6, 11, 45, 48, 497, DateTimeKind.Local).AddTicks(8552) },
                    { 1, 5, null, null, new DateTime(2021, 6, 6, 11, 45, 48, 497, DateTimeKind.Local).AddTicks(8531) },
                    { 7, 4, null, null, new DateTime(2021, 6, 6, 11, 45, 48, 497, DateTimeKind.Local).AddTicks(8600) },
                    { 6, 4, null, null, new DateTime(2021, 6, 6, 11, 45, 48, 497, DateTimeKind.Local).AddTicks(8594) },
                    { 5, 4, null, null, new DateTime(2021, 6, 6, 11, 45, 48, 497, DateTimeKind.Local).AddTicks(8585) },
                    { 4, 4, null, null, new DateTime(2021, 6, 6, 11, 45, 48, 497, DateTimeKind.Local).AddTicks(8575) },
                    { 1, 4, null, null, new DateTime(2021, 6, 6, 11, 45, 48, 497, DateTimeKind.Local).AddTicks(8468) },
                    { 7, 3, null, null, new DateTime(2021, 6, 6, 11, 45, 48, 497, DateTimeKind.Local).AddTicks(8598) },
                    { 5, 5, null, null, new DateTime(2021, 6, 6, 11, 45, 48, 497, DateTimeKind.Local).AddTicks(8586) },
                    { 6, 3, null, null, new DateTime(2021, 6, 6, 11, 45, 48, 497, DateTimeKind.Local).AddTicks(8591) },
                    { 7, 2, null, null, new DateTime(2021, 6, 6, 11, 45, 48, 497, DateTimeKind.Local).AddTicks(8597) },
                    { 6, 2, null, null, new DateTime(2021, 6, 6, 11, 45, 48, 497, DateTimeKind.Local).AddTicks(8589) },
                    { 3, 2, null, null, new DateTime(2021, 6, 6, 11, 45, 48, 497, DateTimeKind.Local).AddTicks(8566) },
                    { 2, 2, null, null, new DateTime(2021, 6, 6, 11, 45, 48, 497, DateTimeKind.Local).AddTicks(8539) },
                    { 1, 2, null, null, new DateTime(2021, 6, 6, 11, 45, 48, 497, DateTimeKind.Local).AddTicks(7436) },
                    { 7, 1, null, null, new DateTime(2021, 6, 6, 11, 45, 48, 497, DateTimeKind.Local).AddTicks(8595) },
                    { 6, 1, null, null, new DateTime(2021, 6, 6, 11, 45, 48, 497, DateTimeKind.Local).AddTicks(8588) },
                    { 4, 1, null, null, new DateTime(2021, 6, 6, 11, 45, 48, 497, DateTimeKind.Local).AddTicks(8574) },
                    { 3, 1, null, null, new DateTime(2021, 6, 6, 11, 45, 48, 497, DateTimeKind.Local).AddTicks(8557) },
                    { 3, 3, null, null, new DateTime(2021, 6, 6, 11, 45, 48, 497, DateTimeKind.Local).AddTicks(8568) },
                    { 7, 5, null, null, new DateTime(2021, 6, 6, 11, 45, 48, 497, DateTimeKind.Local).AddTicks(8601) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_CourseID",
                table: "StudentCourses",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjects_SubjectID",
                table: "StudentSubjects",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_CourseID",
                table: "Subjects",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_PrerequisiteID",
                table: "Subjects",
                column: "PrerequisiteID");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_TeacherID",
                table: "Subjects",
                column: "TeacherID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentCourses");

            migrationBuilder.DropTable(
                name: "StudentSubjects");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
