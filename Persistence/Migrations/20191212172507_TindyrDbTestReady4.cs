using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class TindyrDbTestReady4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Picture_AnimalId",
                table: "Picture");

            migrationBuilder.AddColumn<int>(
                name: "AnimalId1",
                table: "Picture",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FrontPictureId",
                table: "Animals",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Picture_AnimalId",
                table: "Picture",
                column: "AnimalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Picture_AnimalId1",
                table: "Picture",
                column: "AnimalId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Picture_Animals_AnimalId1",
                table: "Picture",
                column: "AnimalId1",
                principalTable: "Animals",
                principalColumn: "AnimalId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Picture_Animals_AnimalId1",
                table: "Picture");

            migrationBuilder.DropIndex(
                name: "IX_Picture_AnimalId",
                table: "Picture");

            migrationBuilder.DropIndex(
                name: "IX_Picture_AnimalId1",
                table: "Picture");

            migrationBuilder.DropColumn(
                name: "AnimalId1",
                table: "Picture");

            migrationBuilder.DropColumn(
                name: "FrontPictureId",
                table: "Animals");

            migrationBuilder.CreateIndex(
                name: "IX_Picture_AnimalId",
                table: "Picture",
                column: "AnimalId");
        }
    }
}
