using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedPrimaryKey1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskDocuments_Tasks_UserTaskTaskId",
                table: "TaskDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskNotes_Tasks_UserTaskTaskId",
                table: "TaskNotes");

            migrationBuilder.DropIndex(
                name: "IX_TaskNotes_UserTaskTaskId",
                table: "TaskNotes");

            migrationBuilder.DropIndex(
                name: "IX_TaskDocuments_UserTaskTaskId",
                table: "TaskDocuments");

            migrationBuilder.DropColumn(
                name: "UserTaskTaskId",
                table: "TaskNotes");

            migrationBuilder.DropColumn(
                name: "UserTaskTaskId",
                table: "TaskDocuments");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cd11",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ab35fbad-df5d-4bbf-9887-25492142aae8", "AQAAAAIAAYagAAAAEP6cJWaB4rZZmII5/JEi8mc+M3uI0zLeouF/2Fhkqg2YNMM9Cob6YBaW0MP4UenqsQ==", "5368d0b5-8b0b-47d3-be73-6cb2bf40910d" });

            migrationBuilder.CreateIndex(
                name: "IX_TaskNotes_TaskId",
                table: "TaskNotes",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskDocuments_TaskId",
                table: "TaskDocuments",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskDocuments_Tasks_TaskId",
                table: "TaskDocuments",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskNotes_Tasks_TaskId",
                table: "TaskNotes",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskDocuments_Tasks_TaskId",
                table: "TaskDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskNotes_Tasks_TaskId",
                table: "TaskNotes");

            migrationBuilder.DropIndex(
                name: "IX_TaskNotes_TaskId",
                table: "TaskNotes");

            migrationBuilder.DropIndex(
                name: "IX_TaskDocuments_TaskId",
                table: "TaskDocuments");

            migrationBuilder.AddColumn<int>(
                name: "UserTaskTaskId",
                table: "TaskNotes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserTaskTaskId",
                table: "TaskDocuments",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cd11",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "72ac1279-458e-466c-ab92-314743c1bade", "AQAAAAIAAYagAAAAEEhxlnmu8JKDgfib2DHFOAhnfUUbk22u4isIOYcdWxc01CO9tAtpygnYUNsgGI8RwA==", "a5f1df7f-e65a-401a-8782-4a164bf64d34" });

            migrationBuilder.CreateIndex(
                name: "IX_TaskNotes_UserTaskTaskId",
                table: "TaskNotes",
                column: "UserTaskTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskDocuments_UserTaskTaskId",
                table: "TaskDocuments",
                column: "UserTaskTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskDocuments_Tasks_UserTaskTaskId",
                table: "TaskDocuments",
                column: "UserTaskTaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskNotes_Tasks_UserTaskTaskId",
                table: "TaskNotes",
                column: "UserTaskTaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId");
        }
    }
}
