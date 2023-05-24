using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Notes.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddDataSeederTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Name", "RoleId", "UserCreated", "UserUpdated" },
                values: new object[,]
                {
                    { 1, null, null, "God", null, null, null },
                    { 2, null, null, "User", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "InformationSystems",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Name", "UserCreated", "UserUpdated" },
                values: new object[] { 1, null, null, "The main information system", null, null });

            migrationBuilder.InsertData(
                table: "Priorities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "The highest" },
                    { 2, "High" },
                    { 3, "Medium" },
                    { 4, "Low" }
                });

            migrationBuilder.InsertData(
                table: "TaskStatuses",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Name", "UserCreated", "UserUpdated" },
                values: new object[,]
                {
                    { 1, null, null, "Awaiting execution", null, null },
                    { 2, null, null, "At work", null, null },
                    { 3, null, null, "Awaiting verification", null, null },
                    { 4, null, null, "Done", null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "InformationSystems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Priorities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Priorities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Priorities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Priorities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TaskStatuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TaskStatuses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TaskStatuses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TaskStatuses",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
