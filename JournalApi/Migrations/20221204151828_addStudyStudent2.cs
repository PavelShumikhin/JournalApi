using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JournalApi.Migrations
{
    /// <inheritdoc />
    public partial class addStudyStudent2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_StudyStudent_StudyGroupId",
                table: "StudyStudent",
                column: "StudyGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyStudent_UserId",
                table: "StudyStudent",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudyStudent_StudyGroup_StudyGroupId",
                table: "StudyStudent",
                column: "StudyGroupId",
                principalTable: "StudyGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudyStudent_Users_UserId",
                table: "StudyStudent",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudyStudent_StudyGroup_StudyGroupId",
                table: "StudyStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_StudyStudent_Users_UserId",
                table: "StudyStudent");

            migrationBuilder.DropIndex(
                name: "IX_StudyStudent_StudyGroupId",
                table: "StudyStudent");

            migrationBuilder.DropIndex(
                name: "IX_StudyStudent_UserId",
                table: "StudyStudent");
        }
    }
}
