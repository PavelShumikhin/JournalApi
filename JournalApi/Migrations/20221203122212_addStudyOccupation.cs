using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JournalApi.Migrations
{
    /// <inheritdoc />
    public partial class addStudyOccupation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudyOccupation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeOccupation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudyGroupId = table.Column<int>(type: "int", nullable: false),
                    StudySubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyOccupation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudyOccupation_StudyGroup_StudyGroupId",
                        column: x => x.StudyGroupId,
                        principalTable: "StudyGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudyOccupation_StudySubject_StudySubjectId",
                        column: x => x.StudySubjectId,
                        principalTable: "StudySubject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudyOccupation_StudyGroupId",
                table: "StudyOccupation",
                column: "StudyGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyOccupation_StudySubjectId",
                table: "StudyOccupation",
                column: "StudySubjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudyOccupation");
        }
    }
}
