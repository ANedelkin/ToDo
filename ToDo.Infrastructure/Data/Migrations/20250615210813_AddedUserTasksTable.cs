using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDo.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserTasksTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Tasks_TaskId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TaskId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "TaskUser",
                columns: table => new
                {
                    ParticipantsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TasksId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskUser", x => new { x.ParticipantsId, x.TasksId });
                    table.ForeignKey(
                        name: "FK_TaskUser_AspNetUsers_ParticipantsId",
                        column: x => x.ParticipantsId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskUser_Tasks_TasksId",
                        column: x => x.TasksId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskUser_TasksId",
                table: "TaskUser",
                column: "TasksId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskUser");

            migrationBuilder.AddColumn<string>(
                name: "TaskId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TaskId",
                table: "AspNetUsers",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Tasks_TaskId",
                table: "AspNetUsers",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id");
        }
    }
}
