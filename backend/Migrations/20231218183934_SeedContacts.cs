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
                columns: new[] { "Id", "Name", "Email", "Phone", "Avatar", "Twitter", "Notes" },
                values: new object[] { 1, "Bob", "bob@test.com", "123-456-7890", "/avatars/headshot_4.png", "BobBarker", "This is a note for Bob." });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Name", "Email", "Phone", "Avatar", "Twitter", "Notes" },
                values: new object[] { 2, "Jane", "jane@test.com", "123-456-7890", "/avatars/headshot_2.png", "JaneDoe", "This is a note for Jane." });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Name", "Email", "Phone", "Avatar", "Twitter", "Notes" },
                values: new object[] { 3, "Mike", "mike@test.com", "123-456-7890", "/avatars/headshot_5.png", "MikeSmith", "This is a note for Mike." });
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
