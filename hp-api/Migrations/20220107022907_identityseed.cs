using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hp_api.Migrations
{
    public partial class identityseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "330eff41-bdf1-4bd3-941b-e4c3f43804be", "ebf07a9b-365c-415f-8d21-643f951e3747", "Admin", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "330eff41-bdf1-4bd3-941b-e4c3f43804be");
        }
    }
}
