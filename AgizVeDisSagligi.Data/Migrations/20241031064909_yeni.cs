using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgizVeDisSagligi.Data.Migrations
{
    /// <inheritdoc />
    public partial class yeni : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Situations_Goals_GoalId",
                table: "Situations");

            migrationBuilder.AddForeignKey(
                name: "FK_Situations_Goals_GoalId",
                table: "Situations",
                column: "GoalId",
                principalTable: "Goals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Situations_Goals_GoalId",
                table: "Situations");

            migrationBuilder.AddForeignKey(
                name: "FK_Situations_Goals_GoalId",
                table: "Situations",
                column: "GoalId",
                principalTable: "Goals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
