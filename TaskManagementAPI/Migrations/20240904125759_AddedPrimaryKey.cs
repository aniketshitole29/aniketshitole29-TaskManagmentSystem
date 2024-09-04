using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedPrimaryKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "77f648df-ecb3-4b13-9fb7-4bb5804181e3", "AQAAAAIAAYagAAAAEGEf8vVZWAsG/JOt9C7ZUz169UXNZbqgN4VTnwbI/pkc+RQRcRL2b8zRkT2mo1CiMQ==", "840901cc-5b60-430a-8b4d-1f7b531885b3" });

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
    }
}
