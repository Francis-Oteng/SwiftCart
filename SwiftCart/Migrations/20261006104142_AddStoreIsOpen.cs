using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SwiftCart.Migrations
{
    /// <inheritdoc />
    public partial class AddStoreIsOpen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOpen",
                table: "Stores",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<decimal>(
                name: "CurrentLongitude",
                table: "Riders",
                type: "decimal(10,7)",
                precision: 18,
                scale: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "TEXT",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "CurrentLatitude",
                table: "Riders",
                type: "decimal(10,7)",
                precision: 18,
                scale: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "TEXT",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.AddColumn<bool>(
                name: "IsOnline",
                table: "Riders",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Riders",
                type: "TEXT",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RejectedDate",
                table: "Riders",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RejectionReason",
                table: "Riders",
                type: "TEXT",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Riders",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "DeliveryTrackings",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOpen",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "IsOnline",
                table: "Riders");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Riders");

            migrationBuilder.DropColumn(
                name: "RejectedDate",
                table: "Riders");

            migrationBuilder.DropColumn(
                name: "RejectionReason",
                table: "Riders");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Riders");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "DeliveryTrackings");

            migrationBuilder.AlterColumn<decimal>(
                name: "CurrentLongitude",
                table: "Riders",
                type: "TEXT",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,7)",
                oldPrecision: 18,
                oldScale: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "CurrentLatitude",
                table: "Riders",
                type: "TEXT",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,7)",
                oldPrecision: 18,
                oldScale: 2,
                oldNullable: true);
        }
    }
}
