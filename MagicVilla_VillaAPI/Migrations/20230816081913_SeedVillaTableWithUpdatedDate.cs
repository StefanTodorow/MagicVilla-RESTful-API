using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedVillaTableWithUpdatedDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedDated",
                table: "Villas",
                newName: "UpdatedDate");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 8, 16, 11, 19, 13, 94, DateTimeKind.Local).AddTicks(6975), new DateTime(2023, 8, 16, 11, 19, 13, 94, DateTimeKind.Local).AddTicks(7034) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 8, 16, 11, 19, 13, 94, DateTimeKind.Local).AddTicks(7039), new DateTime(2023, 8, 16, 11, 19, 13, 94, DateTimeKind.Local).AddTicks(7042) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 8, 16, 11, 19, 13, 94, DateTimeKind.Local).AddTicks(7046), new DateTime(2023, 8, 16, 11, 19, 13, 94, DateTimeKind.Local).AddTicks(7049) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Villas",
                newName: "UpdatedDated");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDated" },
                values: new object[] { new DateTime(2023, 8, 16, 11, 13, 5, 101, DateTimeKind.Local).AddTicks(4864), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDated" },
                values: new object[] { new DateTime(2023, 8, 16, 11, 13, 5, 101, DateTimeKind.Local).AddTicks(4930), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDated" },
                values: new object[] { new DateTime(2023, 8, 16, 11, 13, 5, 101, DateTimeKind.Local).AddTicks(4934), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
