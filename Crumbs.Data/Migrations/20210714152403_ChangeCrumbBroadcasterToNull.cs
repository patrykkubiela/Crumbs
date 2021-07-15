using Microsoft.EntityFrameworkCore.Migrations;

namespace Crumbs.Data.Migrations
{
    public partial class ChangeCrumbBroadcasterToNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crumbs_Crumbs_BroadcasterId",
                table: "Crumbs");

            migrationBuilder.AlterColumn<long>(
                name: "BroadcasterId",
                table: "Crumbs",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Crumbs_Crumbs_BroadcasterId",
                table: "Crumbs",
                column: "BroadcasterId",
                principalTable: "Crumbs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crumbs_Crumbs_BroadcasterId",
                table: "Crumbs");

            migrationBuilder.AlterColumn<long>(
                name: "BroadcasterId",
                table: "Crumbs",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Crumbs_Crumbs_BroadcasterId",
                table: "Crumbs",
                column: "BroadcasterId",
                principalTable: "Crumbs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
