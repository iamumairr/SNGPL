using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SNGPL.Migrations
{
    public partial class AddingConnectionFormApplicationNumberToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_connectionForms",
                table: "connectionForms");

            migrationBuilder.RenameTable(
                name: "connectionForms",
                newName: "ConnectionForms");

            migrationBuilder.RenameColumn(
                name: "Form_Name",
                table: "ConnectionForms",
                newName: "TelePhone");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "ConnectionForms",
                newName: "TownAddress");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationNumberId",
                table: "ConnectionForms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CNIC",
                table: "ConnectionForms",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CellNumber",
                table: "ConnectionForms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "ConnectionForms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ConnectionTypeId",
                table: "ConnectionForms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Customer_Name",
                table: "ConnectionForms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateSubmitted",
                table: "ConnectionForms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ElectricityBillImage",
                table: "ConnectionForms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "ConnectionForms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FamilyName",
                table: "ConnectionForms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NearestConsumerNo",
                table: "ConnectionForms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NearestGasBillImage",
                table: "ConnectionForms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NearestPlace",
                table: "ConnectionForms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OwnerCNIC",
                table: "ConnectionForms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerName",
                table: "ConnectionForms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequiredFor",
                table: "ConnectionForms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "ConnectionForms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConnectionForms",
                table: "ConnectionForms",
                column: "Id");

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

            migrationBuilder.CreateIndex(
                name: "IX_ConnectionForms_ConnectionTypeId",
                table: "ConnectionForms",
                column: "ConnectionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConnectionForms_ApplicationNumbers_ApplicationNumberId",
                table: "ConnectionForms",
                column: "ApplicationNumberId",
                principalTable: "ApplicationNumbers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConnectionForms_ConnectionTypes_ConnectionTypeId",
                table: "ConnectionForms",
                column: "ConnectionTypeId",
                principalTable: "ConnectionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConnectionForms_ApplicationNumbers_ApplicationNumberId",
                table: "ConnectionForms");

            migrationBuilder.DropForeignKey(
                name: "FK_ConnectionForms_ConnectionTypes_ConnectionTypeId",
                table: "ConnectionForms");

            migrationBuilder.DropTable(
                name: "ApplicationNumbers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConnectionForms",
                table: "ConnectionForms");

            migrationBuilder.DropIndex(
                name: "IX_ConnectionForms_ApplicationNumberId",
                table: "ConnectionForms");

            migrationBuilder.DropIndex(
                name: "IX_ConnectionForms_ConnectionTypeId",
                table: "ConnectionForms");

            migrationBuilder.DropColumn(
                name: "ApplicationNumberId",
                table: "ConnectionForms");

            migrationBuilder.DropColumn(
                name: "CNIC",
                table: "ConnectionForms");

            migrationBuilder.DropColumn(
                name: "CellNumber",
                table: "ConnectionForms");

            migrationBuilder.DropColumn(
                name: "City",
                table: "ConnectionForms");

            migrationBuilder.DropColumn(
                name: "ConnectionTypeId",
                table: "ConnectionForms");

            migrationBuilder.DropColumn(
                name: "Customer_Name",
                table: "ConnectionForms");

            migrationBuilder.DropColumn(
                name: "DateSubmitted",
                table: "ConnectionForms");

            migrationBuilder.DropColumn(
                name: "ElectricityBillImage",
                table: "ConnectionForms");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "ConnectionForms");

            migrationBuilder.DropColumn(
                name: "FamilyName",
                table: "ConnectionForms");

            migrationBuilder.DropColumn(
                name: "NearestConsumerNo",
                table: "ConnectionForms");

            migrationBuilder.DropColumn(
                name: "NearestGasBillImage",
                table: "ConnectionForms");

            migrationBuilder.DropColumn(
                name: "NearestPlace",
                table: "ConnectionForms");

            migrationBuilder.DropColumn(
                name: "OwnerCNIC",
                table: "ConnectionForms");

            migrationBuilder.DropColumn(
                name: "OwnerName",
                table: "ConnectionForms");

            migrationBuilder.DropColumn(
                name: "RequiredFor",
                table: "ConnectionForms");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ConnectionForms");

            migrationBuilder.RenameTable(
                name: "ConnectionForms",
                newName: "connectionForms");

            migrationBuilder.RenameColumn(
                name: "TownAddress",
                table: "connectionForms",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "TelePhone",
                table: "connectionForms",
                newName: "Form_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_connectionForms",
                table: "connectionForms",
                column: "Id");
        }
    }
}
