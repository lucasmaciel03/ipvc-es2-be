using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreelanceManagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class applicationUserentitychange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_AspNetUsers_ApplicationUserId",
                table: "Tarefas");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Tarefas",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AssociatedUserId",
                table: "Tarefas",
                type: "text",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_AspNetUsers_ApplicationUserId",
                table: "Tarefas",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_AspNetUsers_ApplicationUserId",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "AssociatedUserId",
                table: "Tarefas");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Tarefas",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_AspNetUsers_ApplicationUserId",
                table: "Tarefas",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
