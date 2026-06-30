using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactList.Migrations
{
    /// <inheritdoc />
    public partial class AddCategorytable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Categoryes_CategoryId",
                table: "Contacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categoryes",
                table: "Categoryes");

            migrationBuilder.RenameTable(
                name: "Categoryes",
                newName: "Category");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Category_CategoryId",
                table: "Contacts",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Category_CategoryId",
                table: "Contacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categoryes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categoryes",
                table: "Categoryes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Categoryes_CategoryId",
                table: "Contacts",
                column: "CategoryId",
                principalTable: "Categoryes",
                principalColumn: "Id");
        }
    }
}
