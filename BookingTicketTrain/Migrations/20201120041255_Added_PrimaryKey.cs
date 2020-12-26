using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingTicketTrain.Migrations
{
    public partial class Added_PrimaryKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "tickets",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tickets",
                table: "tickets",
                column: "Id");

            migrationBuilder.InsertData(
                table: "clients",
                columns: new[] { "AppClientId", "Email", "FullName", "Password", "Username" },
                values: new object[] { "655c4fd0-1488-444f-93d4-7ee17c600e19", null, null, null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tickets",
                table: "tickets");

            migrationBuilder.DeleteData(
                table: "clients",
                keyColumn: "AppClientId",
                keyValue: "655c4fd0-1488-444f-93d4-7ee17c600e19");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "tickets");
        }
    }
}
