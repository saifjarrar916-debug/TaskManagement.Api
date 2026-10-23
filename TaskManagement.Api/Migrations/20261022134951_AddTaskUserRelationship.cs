using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddTaskUserRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "TaskItem",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_TaskItem_UserId",
                table: "TaskItem",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItem_AspNetUsers_UserId",
                table: "TaskItem",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskItem_AspNetUsers_UserId",
                table: "TaskItem");

            migrationBuilder.DropIndex(
                name: "IX_TaskItem_UserId",
                table: "TaskItem");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TaskItem");
        }
    }
}
