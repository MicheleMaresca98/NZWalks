using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataForDifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0d2cb1db-b382-44ae-84c3-39709c98b1a2"), "Easy" },
                    { new Guid("11dd282a-ff68-42ef-95c1-fa20f495fcdf"), "Hard" },
                    { new Guid("1a85e1eb-4df9-4b24-93ed-9f43fefcb4ab"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("1a8c15d1-d98c-48cf-8288-cc539e6338e6"), "WGN", "Wellington", null },
                    { new Guid("245b6678-149c-4cf0-9165-66a9dba0ec98"), "NSN", "Nelson", null },
                    { new Guid("34c37640-ecef-46ff-9ab5-ef18c1dd2775"), "NTL", "Northland", null },
                    { new Guid("4d9c68bc-3bf5-4bf7-8c90-d0d1bb6698f2"), "AKL", "Auckland", "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750" },
                    { new Guid("58afc93b-1a82-4465-893b-0298302f7adb"), "BOP", "Bay of Plenty", null },
                    { new Guid("ce56b4b2-fbb4-43b8-ab90-65408beac04f"), "STL", "Southland", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("0d2cb1db-b382-44ae-84c3-39709c98b1a2"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("11dd282a-ff68-42ef-95c1-fa20f495fcdf"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("1a85e1eb-4df9-4b24-93ed-9f43fefcb4ab"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("1a8c15d1-d98c-48cf-8288-cc539e6338e6"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("245b6678-149c-4cf0-9165-66a9dba0ec98"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("34c37640-ecef-46ff-9ab5-ef18c1dd2775"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("4d9c68bc-3bf5-4bf7-8c90-d0d1bb6698f2"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("58afc93b-1a82-4465-893b-0298302f7adb"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("ce56b4b2-fbb4-43b8-ab90-65408beac04f"));
        }
    }
}
