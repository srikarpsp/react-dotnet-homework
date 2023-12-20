using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vscode_remote_try_dotnet.Migrations
{
    /// <inheritdoc />
    public partial class SeedContacts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Bob" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Jane" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Mike" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3 });
        }
    }
}
