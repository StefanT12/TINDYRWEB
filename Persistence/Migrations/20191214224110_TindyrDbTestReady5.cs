using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class TindyrDbTestReady5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Picture_Animals_AnimalId",
                table: "Picture");

            migrationBuilder.DropForeignKey(
                name: "FK_Picture_Animals_AnimalId1",
                table: "Picture");

            migrationBuilder.RenameTable(
                name: "Picture",
                newName: "Pictures");

            migrationBuilder.RenameIndex(
                name: "IX_Picture_AnimalId1",
                table: "Pictures",
                newName: "IX_Pictures_AnimalId1");

            migrationBuilder.RenameIndex(
                name: "IX_Picture_AnimalId",
                table: "Pictures",
                newName: "IX_Pictures_AnimalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_Animals_AnimalId",
                table: "Pictures",
                column: "AnimalId",
                principalTable: "Animals",
                principalColumn: "AnimalId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_Animals_AnimalId1",
                table: "Pictures",
                column: "AnimalId1",
                principalTable: "Animals",
                principalColumn: "AnimalId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_Animals_AnimalId",
                table: "Pictures");

            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_Animals_AnimalId1",
                table: "Pictures");

            migrationBuilder.RenameTable(
                name: "Pictures",
                newName: "Picture");

            migrationBuilder.RenameIndex(
                name: "IX_Pictures_AnimalId1",
                table: "Picture",
                newName: "IX_Picture_AnimalId1");

            migrationBuilder.RenameIndex(
                name: "IX_Pictures_AnimalId",
                table: "Picture",
                newName: "IX_Picture_AnimalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Picture_Animals_AnimalId",
                table: "Picture",
                column: "AnimalId",
                principalTable: "Animals",
                principalColumn: "AnimalId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Picture_Animals_AnimalId1",
                table: "Picture",
                column: "AnimalId1",
                principalTable: "Animals",
                principalColumn: "AnimalId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
