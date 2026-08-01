using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employee_Management.API.Migrations
{
    /// <inheritdoc />
    public partial class AddPhoneNumberAndEmployeeLoginFk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employees_Email",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Logins",
                newName: "PasswordHash");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Logins",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Logins_EmployeeId",
                table: "Logins",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Logins_Employees_EmployeeId",
                table: "Logins",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logins_Employees_EmployeeId",
                table: "Logins");

            migrationBuilder.DropIndex(
                name: "IX_Logins_EmployeeId",
                table: "Logins");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Logins");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Logins",
                newName: "Password");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Employees",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Email",
                table: "Employees",
                column: "Email",
                unique: true);
        }
    }
}
