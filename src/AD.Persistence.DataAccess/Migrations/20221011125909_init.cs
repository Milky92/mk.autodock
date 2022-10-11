using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AD.Persistence.DataAccess.Migrations
{
    public partial class init : Migration
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
                    Name = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
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
