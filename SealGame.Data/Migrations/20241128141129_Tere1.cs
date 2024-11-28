using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SealGame.Data.Migrations
{
    /// <inheritdoc />
    public partial class Tere1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seals_Players_PlayerId",
                table: "Seals");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Seals_PlayerId",
                table: "Seals");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "Seals");

            migrationBuilder.CreateTable(
                name: "FileToDatabaseDto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    SealId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileToDatabaseDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileToDatabaseDto_Seals_SealId",
                        column: x => x.SealId,
                        principalTable: "Seals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "SealSpecies",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "imelik");

            migrationBuilder.UpdateData(
                table: "SealSpecies",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "rõngik");

            migrationBuilder.UpdateData(
                table: "SealSpecies",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "tavaline");

            migrationBuilder.CreateIndex(
                name: "IX_FileToDatabaseDto_SealId",
                table: "FileToDatabaseDto",
                column: "SealId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileToDatabaseDto");

            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "Seals",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Currency = table.Column<int>(type: "int", nullable: false),
                    DailyTasksCompleted = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cost = table.Column<int>(type: "int", nullable: false),
                    EffectAmount = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "SealSpecies",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "A Weddell seal is a large, carnivorous species found in the Southern Ocean.");

            migrationBuilder.UpdateData(
                table: "SealSpecies",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "A ringed seal is a small, common species found in Arctic and sub-Arctic regions.");

            migrationBuilder.UpdateData(
                table: "SealSpecies",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "The harbor seal is commonly found along coastlines in the Northern Hemisphere.");

            migrationBuilder.CreateIndex(
                name: "IX_Seals_PlayerId",
                table: "Seals",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_PlayerId",
                table: "Items",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seals_Players_PlayerId",
                table: "Seals",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id");
        }
    }
}
