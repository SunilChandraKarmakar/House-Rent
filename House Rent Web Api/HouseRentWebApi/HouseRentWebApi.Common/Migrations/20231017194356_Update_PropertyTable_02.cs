using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentWebApi.Common.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePropertyTable02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainEntrance",
                table: "Properties");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MainEntrance",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
