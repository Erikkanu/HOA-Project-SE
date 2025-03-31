using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HOA.Migrations
{
    /// <inheritdoc />
    public partial class Migration10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Maintenance");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Maintenance",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");
        }
    }
}
