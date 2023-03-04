using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreateQuiz.Migrations
{
    /// <inheritdoc />
    public partial class mg2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quizzes",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Question1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer1A = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer1B = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer1C = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer1D = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RightAnswer1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer2A = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer2B = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer2C = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer2D = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RightAnswer2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer3A = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer3B = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer3C = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer3D = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RightAnswer3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer4A = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer4B = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer4C = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer4D = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RightAnswer4 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizzes", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quizzes");
        }
    }
}
