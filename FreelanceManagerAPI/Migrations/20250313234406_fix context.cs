using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreelanceManagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class fixcontext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldDefaultValue: "unknown");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "unknown",
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
