using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hp_api.Migrations
{
    public partial class datetime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "330eff41-bdf1-4bd3-941b-e4c3f43804be",
                column: "ConcurrencyStamp",
                value: "a7324f75-b856-4b47-afbb-5c5f30060f27");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "330eff41-bdf1-4bd3-941b-e4c3f43804be",
                column: "ConcurrencyStamp",
                value: "aff6b51f-72aa-4589-9eeb-3d7fb5c3e54e");
        }
    }
}
