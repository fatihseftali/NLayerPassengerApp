using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NLayer.Repository.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    UniquePassengerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DocumentNo = table.Column<int>(type: "int", nullable: false),
                    DocumentType = table.Column<int>(type: "int", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.UniquePassengerId);
                });

            migrationBuilder.InsertData(
                table: "Passengers",
                columns: new[] { "UniquePassengerId", "DocumentNo", "DocumentType", "Gender", "IssueDate", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, 1, 1, "Kadın", new DateTime(2022, 4, 16, 16, 34, 18, 484, DateTimeKind.Local).AddTicks(1609), "Ayşe", "Kılıç" },
                    { 2, 2, 0, "Erkek", new DateTime(2022, 4, 16, 16, 34, 18, 484, DateTimeKind.Local).AddTicks(1624), "Bora", "Demir" },
                    { 3, 3, 2, "Kadın", new DateTime(2022, 4, 16, 16, 34, 18, 484, DateTimeKind.Local).AddTicks(1627), "Deniz", "Aydın" },
                    { 4, 4, 0, "Erkek", new DateTime(2022, 4, 16, 16, 34, 18, 484, DateTimeKind.Local).AddTicks(1629), "Erdem", "Kaya" },
                    { 5, 5, 0, "Kadın", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test", "Test" },
                    { 6, 6, 1, "Erkek", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test2", "Test2" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Passengers");
        }
    }
}
