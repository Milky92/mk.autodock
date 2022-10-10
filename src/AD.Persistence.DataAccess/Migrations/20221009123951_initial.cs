using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AD.Persistence.DataAccess.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "db_public");

            migrationBuilder.CreateTable(
                name: "BusinessTasks",
                schema: "db_public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DateTimeCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTimeUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessTasks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Attachments",
                schema: "db_public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessTaskId = table.Column<int>(type: "int", nullable: false),
                    DateTimeCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTimeUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attachments_BusinessTasks_BusinessTaskId",
                        column: x => x.BusinessTaskId,
                        principalSchema: "db_public",
                        principalTable: "BusinessTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "db_public",
                table: "BusinessTasks",
                columns: new[] { "Id", "DateTimeCreation", "DateTimeUpdate", "Name", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8300), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-1", 0 },
                    { 2, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8325), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-2", 0 },
                    { 3, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8327), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-3", 0 },
                    { 4, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8329), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-4", 0 },
                    { 5, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8330), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-5", 0 },
                    { 6, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8333), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-6", 0 },
                    { 7, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8335), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-7", 0 },
                    { 8, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8336), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-8", 0 },
                    { 9, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8337), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-9", 0 },
                    { 10, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8340), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-10", 0 },
                    { 11, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8342), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-11", 0 },
                    { 12, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8343), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-12", 0 },
                    { 13, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8344), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-13", 0 },
                    { 14, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8346), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-14", 0 },
                    { 15, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8347), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-15", 0 },
                    { 16, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8348), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-16", 0 },
                    { 17, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8350), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-17", 0 },
                    { 18, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8352), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-18", 0 },
                    { 19, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8353), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-19", 0 },
                    { 20, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8355), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-20", 0 },
                    { 21, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8356), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-21", 0 },
                    { 22, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8357), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-22", 0 },
                    { 23, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8358), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-23", 0 },
                    { 24, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8360), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-24", 0 },
                    { 25, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8361), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-25", 0 },
                    { 26, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8362), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-26", 0 },
                    { 27, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8363), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-27", 0 },
                    { 28, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8365), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-28", 0 },
                    { 29, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8366), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-29", 0 },
                    { 30, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8367), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-30", 0 },
                    { 31, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8369), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-31", 0 },
                    { 32, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8370), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-32", 0 },
                    { 33, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8371), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-33", 0 },
                    { 34, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8373), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-34", 0 },
                    { 35, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8375), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-35", 0 },
                    { 36, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8376), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-36", 0 },
                    { 37, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8377), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-37", 0 },
                    { 38, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8378), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-38", 0 },
                    { 39, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8379), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-39", 0 },
                    { 40, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8381), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-40", 0 },
                    { 41, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8382), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-41", 0 },
                    { 42, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8383), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-42", 0 }
                });

            migrationBuilder.InsertData(
                schema: "db_public",
                table: "BusinessTasks",
                columns: new[] { "Id", "DateTimeCreation", "DateTimeUpdate", "Name", "Status" },
                values: new object[,]
                {
                    { 43, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8384), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-43", 0 },
                    { 44, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8385), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-44", 0 },
                    { 45, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8387), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-45", 0 },
                    { 46, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8388), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-46", 0 },
                    { 47, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8389), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-47", 0 },
                    { 48, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8391), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-48", 0 },
                    { 49, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8392), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-49", 0 },
                    { 50, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8393), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-50", 0 },
                    { 51, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8394), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-51", 0 },
                    { 52, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8396), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-52", 0 },
                    { 53, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8397), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-53", 0 },
                    { 54, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8398), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-54", 0 },
                    { 55, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8399), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-55", 0 },
                    { 56, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8400), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-56", 0 },
                    { 57, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8402), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-57", 0 },
                    { 58, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8403), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-58", 0 },
                    { 59, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8404), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-59", 0 },
                    { 60, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8405), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-60", 0 },
                    { 61, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8406), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-61", 0 },
                    { 62, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8408), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-62", 0 },
                    { 63, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8409), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-63", 0 },
                    { 64, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8454), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-64", 0 },
                    { 65, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8456), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-65", 0 },
                    { 66, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8458), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-66", 0 },
                    { 67, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8460), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-67", 0 },
                    { 68, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8461), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-68", 0 },
                    { 69, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8462), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-69", 0 },
                    { 70, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8463), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-70", 0 },
                    { 71, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8464), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-71", 0 },
                    { 72, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8466), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-72", 0 },
                    { 73, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8467), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-73", 0 },
                    { 74, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8468), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-74", 0 },
                    { 75, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8469), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-75", 0 },
                    { 76, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8471), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-76", 0 },
                    { 77, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8472), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-77", 0 },
                    { 78, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8473), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-78", 0 },
                    { 79, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8474), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-79", 0 },
                    { 80, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8475), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-80", 0 },
                    { 81, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8477), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-81", 0 },
                    { 82, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8478), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-82", 0 },
                    { 83, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8480), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-83", 0 },
                    { 84, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8481), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-84", 0 }
                });

            migrationBuilder.InsertData(
                schema: "db_public",
                table: "BusinessTasks",
                columns: new[] { "Id", "DateTimeCreation", "DateTimeUpdate", "Name", "Status" },
                values: new object[,]
                {
                    { 85, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8482), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-85", 0 },
                    { 86, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8483), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-86", 0 },
                    { 87, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8484), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-87", 0 },
                    { 88, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8486), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-88", 0 },
                    { 89, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8487), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-89", 0 },
                    { 90, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8488), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-90", 0 },
                    { 91, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8489), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-91", 0 },
                    { 92, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8491), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-92", 0 },
                    { 93, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8492), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-93", 0 },
                    { 94, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8493), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-94", 0 },
                    { 95, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8494), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-95", 0 },
                    { 96, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8496), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-96", 0 },
                    { 97, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8497), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-97", 0 },
                    { 98, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8498), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-98", 0 },
                    { 99, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8499), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-99", 0 },
                    { 100, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8501), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-100", 0 },
                    { 101, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8502), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-101", 0 },
                    { 102, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8504), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-102", 0 },
                    { 103, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8505), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-103", 0 },
                    { 104, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8506), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-104", 0 },
                    { 105, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8507), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-105", 0 },
                    { 106, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8509), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-106", 0 },
                    { 107, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8510), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-107", 0 },
                    { 108, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8511), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-108", 0 },
                    { 109, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8512), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-109", 0 },
                    { 110, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8513), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-110", 0 },
                    { 111, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8515), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-111", 0 },
                    { 112, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8516), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-112", 0 },
                    { 113, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8517), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-113", 0 },
                    { 114, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8519), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-114", 0 },
                    { 115, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8520), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-115", 0 },
                    { 116, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8521), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-116", 0 },
                    { 117, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8523), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-117", 0 },
                    { 118, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8524), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-118", 0 },
                    { 119, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8525), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-119", 0 },
                    { 120, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-120", 0 },
                    { 121, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8528), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-121", 0 },
                    { 122, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8529), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-122", 0 },
                    { 123, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8530), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-123", 0 },
                    { 124, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8532), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-124", 0 },
                    { 125, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8533), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-125", 0 },
                    { 126, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8534), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-126", 0 }
                });

            migrationBuilder.InsertData(
                schema: "db_public",
                table: "BusinessTasks",
                columns: new[] { "Id", "DateTimeCreation", "DateTimeUpdate", "Name", "Status" },
                values: new object[,]
                {
                    { 127, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8535), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-127", 0 },
                    { 128, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8537), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-128", 0 },
                    { 129, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8538), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-129", 0 },
                    { 130, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8577), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-130", 0 },
                    { 131, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8579), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-131", 0 },
                    { 132, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8580), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-132", 0 },
                    { 133, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8581), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-133", 0 },
                    { 134, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8583), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-134", 0 },
                    { 135, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8584), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-135", 0 },
                    { 136, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8585), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-136", 0 },
                    { 137, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8587), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-137", 0 },
                    { 138, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8588), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-138", 0 },
                    { 139, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8589), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-139", 0 },
                    { 140, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8590), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-140", 0 },
                    { 141, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8592), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-141", 0 },
                    { 142, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8593), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-142", 0 },
                    { 143, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8594), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-143", 0 },
                    { 144, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8595), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-144", 0 },
                    { 145, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8597), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-145", 0 },
                    { 146, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8598), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-146", 0 },
                    { 147, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8599), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-147", 0 },
                    { 148, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8601), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-148", 0 },
                    { 149, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8602), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-149", 0 },
                    { 150, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8603), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-150", 0 },
                    { 151, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8604), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-151", 0 },
                    { 152, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8606), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-152", 0 },
                    { 153, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8607), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-153", 0 },
                    { 154, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8608), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-154", 0 },
                    { 155, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8610), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-155", 0 },
                    { 156, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8611), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-156", 0 },
                    { 157, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8612), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-157", 0 },
                    { 158, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8613), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-158", 0 },
                    { 159, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8615), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-159", 0 },
                    { 160, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8616), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-160", 0 },
                    { 161, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8617), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-161", 0 },
                    { 162, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8618), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-162", 0 },
                    { 163, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8620), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-163", 0 },
                    { 164, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8621), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-164", 0 },
                    { 165, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8622), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-165", 0 },
                    { 166, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8623), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-166", 0 },
                    { 167, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8625), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-167", 0 },
                    { 168, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8626), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-168", 0 }
                });

            migrationBuilder.InsertData(
                schema: "db_public",
                table: "BusinessTasks",
                columns: new[] { "Id", "DateTimeCreation", "DateTimeUpdate", "Name", "Status" },
                values: new object[,]
                {
                    { 169, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8627), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-169", 0 },
                    { 170, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8628), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-170", 0 },
                    { 171, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8630), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-171", 0 },
                    { 172, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8631), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-172", 0 },
                    { 173, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8632), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-173", 0 },
                    { 174, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8633), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-174", 0 },
                    { 175, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8635), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-175", 0 },
                    { 176, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8636), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-176", 0 },
                    { 177, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8637), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-177", 0 },
                    { 178, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8638), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-178", 0 },
                    { 179, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8640), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-179", 0 },
                    { 180, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8641), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-180", 0 },
                    { 181, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8642), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-181", 0 },
                    { 182, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8643), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-182", 0 },
                    { 183, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8645), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-183", 0 },
                    { 184, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8646), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-184", 0 },
                    { 185, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8647), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-185", 0 },
                    { 186, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8649), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-186", 0 },
                    { 187, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8650), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-187", 0 },
                    { 188, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8651), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-188", 0 },
                    { 189, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8652), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-189", 0 },
                    { 190, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8653), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-190", 0 },
                    { 191, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8691), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-191", 0 },
                    { 192, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8693), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-192", 0 },
                    { 193, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8694), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-193", 0 },
                    { 194, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8696), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-194", 0 },
                    { 195, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8697), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-195", 0 },
                    { 196, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8698), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-196", 0 },
                    { 197, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8699), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-197", 0 },
                    { 198, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8701), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-198", 0 },
                    { 199, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8702), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-199", 0 },
                    { 200, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8703), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-200", 0 },
                    { 201, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8704), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-201", 0 },
                    { 202, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8706), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-202", 0 },
                    { 203, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8707), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-203", 0 },
                    { 204, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8708), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-204", 0 },
                    { 205, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8709), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-205", 0 },
                    { 206, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8711), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-206", 0 },
                    { 207, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8712), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-207", 0 },
                    { 208, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8713), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-208", 0 },
                    { 209, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8714), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-209", 0 },
                    { 210, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8716), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-210", 0 }
                });

            migrationBuilder.InsertData(
                schema: "db_public",
                table: "BusinessTasks",
                columns: new[] { "Id", "DateTimeCreation", "DateTimeUpdate", "Name", "Status" },
                values: new object[,]
                {
                    { 211, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8717), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-211", 0 },
                    { 212, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8718), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-212", 0 },
                    { 213, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8720), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-213", 0 },
                    { 214, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8721), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-214", 0 },
                    { 215, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8722), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-215", 0 },
                    { 216, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8724), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-216", 0 },
                    { 217, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8725), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-217", 0 },
                    { 218, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8726), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-218", 0 },
                    { 219, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8727), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-219", 0 },
                    { 220, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8729), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-220", 0 },
                    { 221, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8730), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-221", 0 },
                    { 222, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8731), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-222", 0 },
                    { 223, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8732), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-223", 0 },
                    { 224, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8734), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-224", 0 },
                    { 225, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8735), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-225", 0 },
                    { 226, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8736), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-226", 0 },
                    { 227, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8737), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-227", 0 },
                    { 228, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8739), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-228", 0 },
                    { 229, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8740), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-229", 0 },
                    { 230, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8741), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-230", 0 },
                    { 231, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8742), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-231", 0 },
                    { 232, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8744), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-232", 0 },
                    { 233, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8745), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-233", 0 },
                    { 234, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8746), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-234", 0 },
                    { 235, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8748), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-235", 0 },
                    { 236, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8749), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-236", 0 },
                    { 237, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8750), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-237", 0 },
                    { 238, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8751), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-238", 0 },
                    { 239, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8753), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-239", 0 },
                    { 240, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8754), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-240", 0 },
                    { 241, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8755), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-241", 0 },
                    { 242, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8757), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-242", 0 },
                    { 243, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8758), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-243", 0 },
                    { 244, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8759), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-244", 0 },
                    { 245, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8760), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-245", 0 },
                    { 246, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8761), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-246", 0 },
                    { 247, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8763), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-247", 0 },
                    { 248, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8764), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-248", 0 },
                    { 249, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8765), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-249", 0 },
                    { 250, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8766), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-250", 0 },
                    { 251, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8768), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-251", 0 },
                    { 252, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8769), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-252", 0 }
                });

            migrationBuilder.InsertData(
                schema: "db_public",
                table: "BusinessTasks",
                columns: new[] { "Id", "DateTimeCreation", "DateTimeUpdate", "Name", "Status" },
                values: new object[] { 253, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8770), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-253", 0 });

            migrationBuilder.InsertData(
                schema: "db_public",
                table: "BusinessTasks",
                columns: new[] { "Id", "DateTimeCreation", "DateTimeUpdate", "Name", "Status" },
                values: new object[] { 254, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8772), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-254", 0 });

            migrationBuilder.InsertData(
                schema: "db_public",
                table: "BusinessTasks",
                columns: new[] { "Id", "DateTimeCreation", "DateTimeUpdate", "Name", "Status" },
                values: new object[] { 255, new DateTime(2022, 10, 9, 12, 39, 51, 347, DateTimeKind.Utc).AddTicks(8773), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "task-255", 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_BusinessTaskId",
                schema: "db_public",
                table: "Attachments",
                column: "BusinessTaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attachments",
                schema: "db_public");

            migrationBuilder.DropTable(
                name: "BusinessTasks",
                schema: "db_public");
        }
    }
}
