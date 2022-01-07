using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hp_api.Migrations
{
    public partial class characters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ancestries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ancestries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patronus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Animal = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patronus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WandCores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WandCores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WandWoods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WandWoods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WoodId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WandCoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Length = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wands_WandCores_WandCoreId",
                        column: x => x.WandCoreId,
                        principalTable: "WandCores",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Wands_WandWoods_WoodId",
                        column: x => x.WoodId,
                        principalTable: "WandWoods",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlternativeNames = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    House = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsWizard = table.Column<bool>(type: "bit", nullable: false),
                    AncestryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    eyeColour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hairColour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsHogwartsStudent = table.Column<bool>(type: "bit", nullable: false),
                    IsHogwartsStaff = table.Column<bool>(type: "bit", nullable: false),
                    Actor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlternativeActors = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAlive = table.Column<bool>(type: "bit", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpeciesId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Ancestries_AncestryId",
                        column: x => x.AncestryId,
                        principalTable: "Ancestries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Characters_Patronus_Id",
                        column: x => x.Id,
                        principalTable: "Patronus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Characters_Wands_Id",
                        column: x => x.Id,
                        principalTable: "Wands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_AncestryId",
                table: "Characters",
                column: "AncestryId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_SpeciesId",
                table: "Characters",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Wands_WandCoreId",
                table: "Wands",
                column: "WandCoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Wands_WoodId",
                table: "Wands",
                column: "WoodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Ancestries");

            migrationBuilder.DropTable(
                name: "Patronus");

            migrationBuilder.DropTable(
                name: "Species");

            migrationBuilder.DropTable(
                name: "Wands");

            migrationBuilder.DropTable(
                name: "WandCores");

            migrationBuilder.DropTable(
                name: "WandWoods");
        }
    }
}
