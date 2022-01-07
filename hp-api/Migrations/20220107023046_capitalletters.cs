using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hp_api.Migrations
{
    public partial class capitalletters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "hairColour",
                table: "Characters",
                newName: "HairColour");

            migrationBuilder.RenameColumn(
                name: "eyeColour",
                table: "Characters",
                newName: "EyeColour");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "330eff41-bdf1-4bd3-941b-e4c3f43804be",
                column: "ConcurrencyStamp",
                value: "965fd13c-2468-45bc-8cfd-0c2b7f6b9506");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HairColour",
                table: "Characters",
                newName: "hairColour");

            migrationBuilder.RenameColumn(
                name: "EyeColour",
                table: "Characters",
                newName: "eyeColour");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "330eff41-bdf1-4bd3-941b-e4c3f43804be",
                column: "ConcurrencyStamp",
                value: "ebf07a9b-365c-415f-8d21-643f951e3747");
        }
    }
}
