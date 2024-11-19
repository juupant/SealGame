using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SealGame.Data.Migrations
{
    /// <inheritdoc />
    public partial class asda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SealSpecies",
                columns: new[] { "Id", "Description", "MaxCleanliness", "MaxEnrichment", "MaxHappiness", "MaxHunger", "Name" },
                values: new object[,]
                {
                    { 1, "A Weddell seal is a large, carnivorous species found in the Southern Ocean.", 100, 80, 100, 50, "Weddell Seal" },
                    { 2, "A ringed seal is a small, common species found in Arctic and sub-Arctic regions.", 95, 85, 90, 60, "Ringed Seal" },
                    { 3, "The harbor seal is commonly found along coastlines in the Northern Hemisphere.", 100, 90, 95, 55, "Harbor Seal" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SealSpecies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SealSpecies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SealSpecies",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
