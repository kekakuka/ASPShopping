using Microsoft.EntityFrameworkCore.Migrations;

namespace asp_assignment.Migrations
{
    public partial class supplierEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                table: "Supplier",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                table: "Supplier",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
