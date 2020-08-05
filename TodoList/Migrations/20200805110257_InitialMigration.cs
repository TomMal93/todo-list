using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoList.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ToDoTasks",
                columns: table => new
                {
                    ToDoTaskID = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    FinishDate = table.Column<DateTime>(nullable: false),
                    IsDone = table.Column<bool>(nullable: false),
                    PriorityStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoTasks", x => x.ToDoTaskID);
                });

            migrationBuilder.InsertData(
                table: "ToDoTasks",
                columns: new[] { "ToDoTaskID", "Description", "FinishDate", "IsDone", "PriorityStatus", "Title" },
                values: new object[,]
                {
                    { new Guid("b2d0cb27-8328-4e9b-8d61-49a1853230bc"), "Makaron, mięso", new DateTime(2020, 8, 5, 18, 0, 0, 0, DateTimeKind.Unspecified), false, 2, "Zakupy" },
                    { new Guid("9e65e8a5-9f00-45a2-9983-f5fdc50b1792"), "", new DateTime(2020, 8, 6, 13, 2, 46, 347, DateTimeKind.Local).AddTicks(7068), false, 1, "Zrobić pranie" },
                    { new Guid("886332ad-7ff2-49c2-8e75-6193541caff7"), "Spaghetti", new DateTime(2020, 8, 5, 19, 0, 0, 0, DateTimeKind.Unspecified), false, 2, "Zrobić kolację" },
                    { new Guid("ee648776-6b7f-448b-be16-a3d366ab3b7b"), "", new DateTime(2020, 8, 5, 15, 0, 0, 0, DateTimeKind.Unspecified), true, 2, "Odebrać dzieci ze szkoły" },
                    { new Guid("a9ededa6-5e35-440b-b615-f0d97e6063f3"), "Czas dla rodziny", new DateTime(2020, 8, 7, 15, 0, 0, 0, DateTimeKind.Unspecified), false, 0, "Zaplanować weekend" },
                    { new Guid("6a4f78d2-6786-4749-b5d9-9423a9f871cc"), "", new DateTime(2020, 8, 6, 20, 0, 0, 0, DateTimeKind.Unspecified), false, 1, "Trening" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDoTasks");
        }
    }
}
