using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinimalApi_Demo.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeAttendanc",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeTeam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeEmailId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeePresent = table.Column<int>(type: "int", nullable: false),
                    EmployeeAbsent = table.Column<int>(type: "int", nullable: false),
                    EmployeeTakeLeave = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeAttendanc", x => x.EmployeeId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeAttendanc");
        }
    }
}
