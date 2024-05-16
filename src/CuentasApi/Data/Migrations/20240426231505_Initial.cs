using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CuentasApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Cedula = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccountNumber = table.Column<string>(type: "TEXT", nullable: false),
                    AccountName = table.Column<string>(type: "TEXT", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Cedula", "LastName", "Name" },
                values: new object[,]
                {
                    { 1, "150301-6016", "Barton", "Jenifer" },
                    { 2, "261202-8446", "Bayer", "Yessenia" },
                    { 3, "160161-1275", "Watsica", "Ayden" },
                    { 4, "070488-4923", "Renner", "Jovanny" },
                    { 5, "240778-1301", "Terry", "Philip" },
                    { 6, "170756-1544", "VonRueden", "Talon" },
                    { 7, "190755-4526", "Toy", "Filomena" },
                    { 8, "191079-3078", "Hettinger", "Darrion" },
                    { 9, "050260-1814", "Schumm", "Jay" },
                    { 10, "160357-4687", "Ratke", "Sage" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountName", "AccountNumber", "Balance", "UserId" },
                values: new object[,]
                {
                    { 1, "Personal Loan Account", "26996633", 638.29m, 1 },
                    { 2, "Credit Card Account", "58744279", 561.44m, 1 },
                    { 3, "Personal Loan Account", "19398505", 659.70m, 2 },
                    { 4, "Investment Account", "31770994", 543.88m, 2 },
                    { 5, "Investment Account", "49560623", 973.80m, 2 },
                    { 6, "Personal Loan Account", "63597767", 292.64m, 3 },
                    { 7, "Checking Account", "60466370", 103.91m, 4 },
                    { 8, "Auto Loan Account", "08082306", 94.72m, 4 },
                    { 9, "Checking Account", "61795975", 912.53m, 4 },
                    { 10, "Checking Account", "39933094", 712.01m, 5 },
                    { 11, "Auto Loan Account", "76589896", 939.63m, 5 },
                    { 12, "Auto Loan Account", "47310032", 704.50m, 6 },
                    { 13, "Personal Loan Account", "53555610", 140.60m, 6 },
                    { 14, "Auto Loan Account", "83103756", 583.11m, 7 },
                    { 15, "Money Market Account", "10473149", 438.89m, 7 },
                    { 16, "Savings Account", "42681382", 481.24m, 7 },
                    { 17, "Money Market Account", "73825063", 830.79m, 8 },
                    { 18, "Savings Account", "60967028", 360.71m, 8 },
                    { 19, "Savings Account", "61431633", 380.15m, 8 },
                    { 20, "Investment Account", "60245534", 924.09m, 9 },
                    { 21, "Investment Account", "81052956", 212.24m, 10 },
                    { 22, "Investment Account", "21930280", 109.62m, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_UserId",
                table: "Accounts",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
