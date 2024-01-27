using Microsoft.EntityFrameworkCore.Migrations;

namespace SNGPL.Migrations
{
    public partial class ModifyingConnectionFormToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConnectionForms_ApplicationNumbers_ApplicationNumberId",
                table: "ConnectionForms");

            migrationBuilder.DropTable(
                name: "ApplicationNumbers");

            migrationBuilder.DropIndex(
                name: "IX_ConnectionForms_ApplicationNumberId",
                table: "ConnectionForms");

            migrationBuilder.DropColumn(
                name: "ApplicationNumberId",
                table: "ConnectionForms");

            migrationBuilder.AddColumn<int>(
                name: "Token",
                table: "ConnectionForms",
                type: "int",
                maxLength: 6,
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Token",
                table: "ConnectionForms");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationNumberId",
                table: "ConnectionForms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ApplicationNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrackingNumber = table.Column<int>(type: "int", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationNumbers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConnectionForms_ApplicationNumberId",
                table: "ConnectionForms",
                column: "ApplicationNumberId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ConnectionForms_ApplicationNumbers_ApplicationNumberId",
                table: "ConnectionForms",
                column: "ApplicationNumberId",
                principalTable: "ApplicationNumbers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
