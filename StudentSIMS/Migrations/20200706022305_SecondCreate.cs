using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentSIMS.Migrations
{
    public partial class SecondCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "Students",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "firstName",
                table: "Students",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "emailAddress",
                table: "Students",
                newName: "EmailAddress");

            migrationBuilder.RenameColumn(
                name: "studentId",
                table: "Students",
                newName: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Students",
                newName: "lastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Students",
                newName: "firstName");

            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                table: "Students",
                newName: "emailAddress");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Students",
                newName: "studentId");
        }
    }
}
