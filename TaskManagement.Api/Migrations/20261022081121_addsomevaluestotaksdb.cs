using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskManagement.Api.Migrations
{
    /// <inheritdoc />
    public partial class addsomevaluestotaksdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TaskItem",
                columns: new[] { "Id", "CreatedAt", "Description", "Status", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Study Web API fundamentals", "Pending", "Learn ASP.NET Core" },
                    { 2, new DateTime(2026, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Implement user registration and login", "InProgress", "Build Authentication" },
                    { 3, new DateTime(2026, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Learn migrations and relationships", "Completed", "Practice Entity Framework" },
                    { 4, new DateTime(2026, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Implement CRUD endpoints", "Pending", "Create Tasks API" },
                    { 5, new DateTime(2026, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Understand token generation and validation", "InProgress", "Learn JWT" },
                    { 6, new DateTime(2026, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test requests using Scalar", "Pending", "Test API Endpoints" },
                    { 7, new DateTime(2026, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Practice filtering and sorting", "Completed", "Study LINQ" },
                    { 8, new DateTime(2026, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Create DTOs for create and update", "Pending", "Add DTOs" },
                    { 9, new DateTime(2026, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Practice roles and access policies", "Pending", "Learn Authorization" },
                    { 10, new DateTime(2026, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Add input validation to tasks", "InProgress", "Fix Validation" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TaskItem",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
