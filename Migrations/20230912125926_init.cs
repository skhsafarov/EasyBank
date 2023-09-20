using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EasyBank.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Position = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<int>(type: "integer", nullable: false),
                    Attempts = table.Column<int>(type: "integer", nullable: false),
                    Expires = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<string>(type: "text", nullable: false),
                    Holder = table.Column<string>(type: "text", nullable: false),
                    Pin = table.Column<int>(type: "integer", nullable: false),
                    Balance = table.Column<decimal>(type: "numeric", nullable: false),
                    IsBlocked = table.Column<bool>(type: "boolean", nullable: false),
                    CustomerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeActions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Controller = table.Column<string>(type: "text", nullable: false),
                    Endpoint = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EmployeeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeActions_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TransactionType = table.Column<string>(type: "text", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TransactionAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    TransactionDescription = table.Column<string>(type: "text", nullable: true),
                    CardId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "_id", "Address", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, "Qashqadaryo viloyati, Qarshi shahri, Ibrohimov ko'chasi, 22-uy", "Zuhra", "Turaev", "998640721019" },
                    { 2, "Samarkand viloyati, Qarshi shahri, Amir Temur ko'chasi, 8-uy", "Zilola", "Sharipov", "998689509460" },
                    { 3, "Namangan viloyati, Chortoq tumani, Bobur ko'chasi, 34-uy", "Azizbek", "Mirzayev", "998533323682" },
                    { 4, "Andijon viloyati, Oltiariq tumani, Buyuk Ipak Yuli ko'chasi, 11-uy", "Sardor", "Abdullaev", "998992337848" },
                    { 5, "Samarkand viloyati, Qarshi shahri, Amir Temur ko'chasi, 8-uy", "Shukhrat", "Davlatov", "998909885482" },
                    { 6, "Toshkent shahri, Yunusobod tumani, Alisher Navoi ko'chasi, 12-uy", "Nargiza", "Nazarov", "998594564262" },
                    { 7, "Xorazm viloyati, Xiva shahri, Al-Xorezm ko'chasi, 9-uy", "Ravshan", "Ochilov", "998990220338" },
                    { 8, "Sirdaryo viloyati, Guliston shahri, Amir Temur ko'chasi, 56-uy", "Lola", "Usmanov", "998437232006" },
                    { 9, "Andijon viloyati, Oltiariq tumani, Buyuk Ipak Yuli ko'chasi, 11-uy", "Shahzod", "Turaev", "998842109685" },
                    { 10, "Buxoro viloyati, Qorako'l tumani, Sharof Rashidov ko'chasi, 23-uy", "Ulugbek", "Rustamov", "998942431138" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "_id", "Address", "Attempts", "Code", "Expires", "FirstName", "LastName", "Phone", "Position", "Role" },
                values: new object[,]
                {
                    { 1, "Jizzax viloyati, Zafar shahri, Alisher Navoi ko'chasi, 33-uy", 10, 111111, new DateTime(2023, 9, 12, 12, 59, 20, 466, DateTimeKind.Utc).AddTicks(7725), "Sardor", "Sodiqov", "998239037170", "Senior", "Administrator" },
                    { 2, "Qashqadaryo viloyati, Qarshi shahri, Ibrohimov ko'chasi, 22-uy", 10, 111111, new DateTime(2023, 9, 12, 12, 59, 20, 466, DateTimeKind.Utc).AddTicks(7737), "Shirin", "Tashpulatov", "998583025594", "Senior", "Director" },
                    { 3, "Qashqadaryo viloyati, Karshi shahri, To'raqo'ziy ko'chasi, 90-uy", 10, 111111, new DateTime(2023, 9, 12, 12, 59, 20, 466, DateTimeKind.Utc).AddTicks(7745), "Shahzod", "Saidov", "998201478223", "Lead", "Employee" },
                    { 4, "Namangan viloyati, Uchqo'rg'on tumani, Sharof Rashidov ko'chasi, 67-uy", 10, 111111, new DateTime(2023, 9, 12, 12, 59, 20, 466, DateTimeKind.Utc).AddTicks(7754), "Feruza", "Ergashev", "998599318911", "Junior", "Director" },
                    { 5, "Navoiy viloyati, Karmana tumani, Olmazor ko'chasi, 5-uy", 10, 111111, new DateTime(2023, 9, 12, 12, 59, 20, 466, DateTimeKind.Utc).AddTicks(7763), "Gulnoza", "Zokirov", "998953319153", "Senior", "Employee" }
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "_id", "Balance", "CustomerId", "Holder", "IsBlocked", "Number", "Pin" },
                values: new object[,]
                {
                    { 1, 9466000m, 5, "Ravshan Mirzayev", false, "0000000000000001", 4957 },
                    { 2, 723000m, 8, "Lola Karimov", false, "0000000000000002", 8568 },
                    { 3, 6943000m, 8, "Gulnoza Ochilov", false, "0000000000000003", 7663 },
                    { 4, 9795000m, 1, "Umida Nazarov", false, "0000000000000004", 4840 },
                    { 5, 3086000m, 6, "Ismoil Yusupov", false, "0000000000000005", 7135 },
                    { 6, 7969000m, 10, "Zilola Ismailov", false, "0000000000000006", 6858 },
                    { 7, 6166000m, 7, "Feruza Usmanov", false, "0000000000000007", 7471 },
                    { 8, 6605000m, 2, "Sanjar Yusupov", false, "0000000000000008", 9610 },
                    { 9, 7737000m, 8, "Feruza Kamilov", false, "0000000000000009", 4357 },
                    { 10, 687000m, 9, "Azizbek Ergashev", false, "0000000000000010", 9370 },
                    { 11, 7302000m, 10, "Dilshod Ochilov", false, "0000000000000011", 7705 },
                    { 12, 732000m, 2, "Alisher Sodiqov", false, "0000000000000012", 8892 },
                    { 13, 6090000m, 2, "Shahzod Salimov", false, "0000000000000013", 5230 },
                    { 14, 7754000m, 5, "Olimjon Sultonov", false, "0000000000000014", 9487 },
                    { 15, 1378000m, 4, "Dilshod Karimov", false, "0000000000000015", 3704 },
                    { 16, 2680000m, 4, "Gulnoza Salimov", false, "0000000000000016", 2206 },
                    { 17, 3763000m, 7, "Zilola Ochilov", false, "0000000000000017", 2426 },
                    { 18, 8389000m, 9, "Ravshan Turaev", false, "0000000000000018", 4708 },
                    { 19, 3749000m, 3, "Azizbek To'rayev", false, "0000000000000019", 7717 },
                    { 20, 5074000m, 3, "Sardor Sharipov", false, "0000000000000020", 9993 }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "_id", "CardId", "TransactionAmount", "TransactionDate", "TransactionDescription", "TransactionType" },
                values: new object[,]
                {
                    { 1, 9, 4087m, new DateTime(2022, 10, 13, 8, 44, 1, 466, DateTimeKind.Utc).AddTicks(7103), "Description1", "Пополнение" },
                    { 2, 1, 9113m, new DateTime(2022, 9, 17, 15, 46, 53, 466, DateTimeKind.Utc).AddTicks(7128), "Description2", "Пополнение" },
                    { 3, 14, 2597m, new DateTime(2023, 6, 2, 14, 4, 59, 466, DateTimeKind.Utc).AddTicks(7137), "Description3", "Пополнение" },
                    { 4, 6, 3025m, new DateTime(2023, 5, 2, 10, 57, 13, 466, DateTimeKind.Utc).AddTicks(7147), "Description4", "Списание" },
                    { 5, 4, 7976m, new DateTime(2022, 10, 7, 20, 49, 57, 466, DateTimeKind.Utc).AddTicks(7156), "Description5", "Списание" },
                    { 6, 9, 5069m, new DateTime(2023, 6, 15, 1, 39, 53, 466, DateTimeKind.Utc).AddTicks(7166), "Description6", "Списание" },
                    { 7, 4, 6032m, new DateTime(2023, 6, 17, 3, 53, 46, 466, DateTimeKind.Utc).AddTicks(7175), "Description7", "Списание" },
                    { 8, 18, 3970m, new DateTime(2023, 7, 10, 21, 10, 8, 466, DateTimeKind.Utc).AddTicks(7184), "Description8", "Списание" },
                    { 9, 16, 8230m, new DateTime(2023, 1, 15, 21, 46, 52, 466, DateTimeKind.Utc).AddTicks(7193), "Description9", "Списание" },
                    { 10, 17, 7719m, new DateTime(2023, 6, 7, 11, 29, 17, 466, DateTimeKind.Utc).AddTicks(7203), "Description10", "Пополнение" },
                    { 11, 13, 2685m, new DateTime(2022, 11, 13, 14, 27, 15, 466, DateTimeKind.Utc).AddTicks(7212), "Description11", "Пополнение" },
                    { 12, 10, 3177m, new DateTime(2023, 5, 16, 18, 46, 36, 466, DateTimeKind.Utc).AddTicks(7221), "Description12", "Списание" },
                    { 13, 2, 7248m, new DateTime(2022, 11, 8, 21, 45, 9, 466, DateTimeKind.Utc).AddTicks(7230), "Description13", "Списание" },
                    { 14, 14, 3525m, new DateTime(2023, 3, 26, 7, 54, 40, 466, DateTimeKind.Utc).AddTicks(7239), "Description14", "Пополнение" },
                    { 15, 7, 9148m, new DateTime(2022, 12, 15, 0, 11, 9, 466, DateTimeKind.Utc).AddTicks(7248), "Description15", "Пополнение" },
                    { 16, 17, 5018m, new DateTime(2023, 8, 29, 18, 9, 16, 466, DateTimeKind.Utc).AddTicks(7257), "Description16", "Пополнение" },
                    { 17, 14, 4542m, new DateTime(2023, 9, 6, 23, 8, 49, 466, DateTimeKind.Utc).AddTicks(7266), "Description17", "Списание" },
                    { 18, 7, 3501m, new DateTime(2023, 1, 25, 21, 48, 46, 466, DateTimeKind.Utc).AddTicks(7402), "Description18", "Пополнение" },
                    { 19, 15, 3760m, new DateTime(2023, 1, 14, 7, 14, 53, 466, DateTimeKind.Utc).AddTicks(7411), "Description19", "Списание" },
                    { 20, 4, 3586m, new DateTime(2023, 3, 14, 3, 5, 26, 466, DateTimeKind.Utc).AddTicks(7452), "Description20", "Пополнение" },
                    { 21, 20, 9075m, new DateTime(2023, 1, 26, 10, 23, 33, 466, DateTimeKind.Utc).AddTicks(7462), "Description21", "Списание" },
                    { 22, 18, 1986m, new DateTime(2022, 11, 1, 21, 28, 7, 466, DateTimeKind.Utc).AddTicks(7471), "Description22", "Пополнение" },
                    { 23, 15, 9534m, new DateTime(2023, 7, 20, 19, 44, 40, 466, DateTimeKind.Utc).AddTicks(7479), "Description23", "Пополнение" },
                    { 24, 19, 1029m, new DateTime(2023, 8, 5, 4, 42, 31, 466, DateTimeKind.Utc).AddTicks(7635), "Description24", "Списание" },
                    { 25, 5, 9937m, new DateTime(2023, 4, 18, 16, 4, 1, 466, DateTimeKind.Utc).AddTicks(7645), "Description25", "Списание" },
                    { 26, 6, 9831m, new DateTime(2023, 4, 4, 5, 13, 55, 466, DateTimeKind.Utc).AddTicks(7654), "Description26", "Списание" },
                    { 27, 20, 7894m, new DateTime(2023, 3, 26, 19, 9, 56, 466, DateTimeKind.Utc).AddTicks(7680), "Description27", "Списание" },
                    { 28, 4, 6818m, new DateTime(2023, 3, 12, 16, 34, 19, 466, DateTimeKind.Utc).AddTicks(7689), "Description28", "Списание" },
                    { 29, 8, 1439m, new DateTime(2023, 2, 9, 7, 18, 27, 466, DateTimeKind.Utc).AddTicks(7698), "Description29", "Пополнение" },
                    { 30, 12, 2881m, new DateTime(2023, 9, 4, 18, 35, 40, 466, DateTimeKind.Utc).AddTicks(7708), "Description30", "Списание" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_CustomerId",
                table: "Cards",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeActions_EmployeeId",
                table: "EmployeeActions",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CardId",
                table: "Transactions",
                column: "CardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeActions");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
