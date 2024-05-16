using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CuentasApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnsToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AccountName", "AccountNumber", "Balance" },
                values: new object[] { "Credit Card Account", "06070185", 305.42m });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AccountName", "AccountNumber", "Balance" },
                values: new object[] { "Checking Account", "65279254", 407.98m });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AccountName", "AccountNumber", "Balance", "UserId" },
                values: new object[] { "Credit Card Account", "77190138", 883.33m, 1 });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AccountName", "AccountNumber", "Balance" },
                values: new object[] { "Personal Loan Account", "27590395", 882.34m });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AccountName", "AccountNumber", "Balance" },
                values: new object[] { "Money Market Account", "11913637", 768.33m });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AccountName", "AccountNumber", "Balance" },
                values: new object[] { "Money Market Account", "61483875", 124.72m });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AccountName", "AccountNumber", "Balance" },
                values: new object[] { "Personal Loan Account", "89812305", 833.95m });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AccountName", "AccountNumber", "Balance", "UserId" },
                values: new object[] { "Home Loan Account", "48890247", 359.23m, 5 });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AccountName", "AccountNumber", "Balance", "UserId" },
                values: new object[] { "Investment Account", "24626670", 112.15m, 6 });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AccountName", "AccountNumber", "Balance", "UserId" },
                values: new object[] { "Auto Loan Account", "04020096", 5.80m, 6 });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AccountName", "AccountNumber", "Balance", "UserId" },
                values: new object[] { "Home Loan Account", "48777961", 782.14m, 7 });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AccountName", "AccountNumber", "Balance", "UserId" },
                values: new object[] { "Savings Account", "97273917", 663.58m, 7 });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "AccountName", "AccountNumber", "Balance", "UserId" },
                values: new object[] { "Investment Account", "12530471", 966.53m, 7 });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "AccountName", "AccountNumber", "Balance", "UserId" },
                values: new object[] { "Savings Account", "01049242", 499.18m, 8 });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "AccountName", "AccountNumber", "Balance", "UserId" },
                values: new object[] { "Home Loan Account", "24166175", 151.02m, 8 });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "AccountNumber", "Balance", "UserId" },
                values: new object[] { "23502669", 884.43m, 9 });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "AccountNumber", "Balance", "UserId" },
                values: new object[] { "68377044", 814.19m, 9 });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "AccountName", "AccountNumber", "Balance", "UserId" },
                values: new object[] { "Checking Account", "01673478", 876.40m, 9 });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "AccountName", "AccountNumber", "Balance", "UserId" },
                values: new object[] { "Money Market Account", "92899345", 886.91m, 10 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Cedula", "Email", "LastName", "Name", "PhoneNumber" },
                values: new object[] { "281276-1490", "Elaine_Hirthe23@hotmail.com", "Bauch", "Dallin", "592.789.6670 x508" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Cedula", "Email", "LastName", "Name", "PhoneNumber" },
                values: new object[] { "190198-0892", "Beverly.Bogisich@hotmail.com", "Ernser", "Quincy", "(558) 736-4563 x428" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Cedula", "Email", "LastName", "Name", "PhoneNumber" },
                values: new object[] { "180499-1103", "Guadalupe1@hotmail.com", "Kris", "Ila", "416-204-3930 x125" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Cedula", "Email", "LastName", "Name", "PhoneNumber" },
                values: new object[] { "250491-0493", "Lance.Streich@gmail.com", "Connelly", "Flo", "(223) 416-0302" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Cedula", "Email", "LastName", "Name", "PhoneNumber" },
                values: new object[] { "270370-4002", "Melissa_Rippin@yahoo.com", "Windler", "Mckenzie", "(854) 942-2686 x497" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Cedula", "Email", "LastName", "Name", "PhoneNumber" },
                values: new object[] { "270359-3790", "Beverly_Hansen@hotmail.com", "Miller", "Lucio", "1-932-897-5988" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Cedula", "Email", "LastName", "Name", "PhoneNumber" },
                values: new object[] { "230467-0021", "Gabriel.Bode@yahoo.com", "Becker", "Dawn", "1-846-887-7283 x319" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Cedula", "Email", "LastName", "Name", "PhoneNumber" },
                values: new object[] { "190495-1680", "Maxine_DuBuque93@gmail.com", "Keebler", "Krista", "444.252.0146" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Cedula", "Email", "LastName", "Name", "PhoneNumber" },
                values: new object[] { "011171-3545", "Noel.Kilback@gmail.com", "Mante", "Myrtie", "465.400.0027" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Cedula", "Email", "LastName", "Name", "PhoneNumber" },
                values: new object[] { "150961-2974", "Jody21@gmail.com", "Kulas", "Julian", "228.452.1473" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AccountName", "AccountNumber", "Balance" },
                values: new object[] { "Personal Loan Account", "26996633", 638.29m });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AccountName", "AccountNumber", "Balance" },
                values: new object[] { "Credit Card Account", "58744279", 561.44m });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AccountName", "AccountNumber", "Balance", "UserId" },
                values: new object[] { "Personal Loan Account", "19398505", 659.70m, 2 });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AccountName", "AccountNumber", "Balance" },
                values: new object[] { "Investment Account", "31770994", 543.88m });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AccountName", "AccountNumber", "Balance" },
                values: new object[] { "Investment Account", "49560623", 973.80m });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AccountName", "AccountNumber", "Balance" },
                values: new object[] { "Personal Loan Account", "63597767", 292.64m });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AccountName", "AccountNumber", "Balance" },
                values: new object[] { "Checking Account", "60466370", 103.91m });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AccountName", "AccountNumber", "Balance", "UserId" },
                values: new object[] { "Auto Loan Account", "08082306", 94.72m, 4 });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AccountName", "AccountNumber", "Balance", "UserId" },
                values: new object[] { "Checking Account", "61795975", 912.53m, 4 });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AccountName", "AccountNumber", "Balance", "UserId" },
                values: new object[] { "Checking Account", "39933094", 712.01m, 5 });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AccountName", "AccountNumber", "Balance", "UserId" },
                values: new object[] { "Auto Loan Account", "76589896", 939.63m, 5 });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AccountName", "AccountNumber", "Balance", "UserId" },
                values: new object[] { "Auto Loan Account", "47310032", 704.50m, 6 });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "AccountName", "AccountNumber", "Balance", "UserId" },
                values: new object[] { "Personal Loan Account", "53555610", 140.60m, 6 });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "AccountName", "AccountNumber", "Balance", "UserId" },
                values: new object[] { "Auto Loan Account", "83103756", 583.11m, 7 });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "AccountName", "AccountNumber", "Balance", "UserId" },
                values: new object[] { "Money Market Account", "10473149", 438.89m, 7 });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "AccountNumber", "Balance", "UserId" },
                values: new object[] { "42681382", 481.24m, 7 });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "AccountNumber", "Balance", "UserId" },
                values: new object[] { "73825063", 830.79m, 8 });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "AccountName", "AccountNumber", "Balance", "UserId" },
                values: new object[] { "Savings Account", "60967028", 360.71m, 8 });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "AccountName", "AccountNumber", "Balance", "UserId" },
                values: new object[] { "Savings Account", "61431633", 380.15m, 8 });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountName", "AccountNumber", "Balance", "UserId" },
                values: new object[,]
                {
                    { 20, "Investment Account", "60245534", 924.09m, 9 },
                    { 21, "Investment Account", "81052956", 212.24m, 10 },
                    { 22, "Investment Account", "21930280", 109.62m, 10 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Cedula", "LastName", "Name" },
                values: new object[] { "150301-6016", "Barton", "Jenifer" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Cedula", "LastName", "Name" },
                values: new object[] { "261202-8446", "Bayer", "Yessenia" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Cedula", "LastName", "Name" },
                values: new object[] { "160161-1275", "Watsica", "Ayden" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Cedula", "LastName", "Name" },
                values: new object[] { "070488-4923", "Renner", "Jovanny" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Cedula", "LastName", "Name" },
                values: new object[] { "240778-1301", "Terry", "Philip" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Cedula", "LastName", "Name" },
                values: new object[] { "170756-1544", "VonRueden", "Talon" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Cedula", "LastName", "Name" },
                values: new object[] { "190755-4526", "Toy", "Filomena" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Cedula", "LastName", "Name" },
                values: new object[] { "191079-3078", "Hettinger", "Darrion" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Cedula", "LastName", "Name" },
                values: new object[] { "050260-1814", "Schumm", "Jay" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Cedula", "LastName", "Name" },
                values: new object[] { "160357-4687", "Ratke", "Sage" });
        }
    }
}
