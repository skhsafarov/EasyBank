﻿// <auto-generated />
using System;
using EasyBank.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EasyBank.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230912125926_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EasyBank.Models.Card", b =>
                {
                    b.Property<int>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("_id"));

                    b.Property<decimal>("Balance")
                        .HasColumnType("numeric");

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<string>("Holder")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsBlocked")
                        .HasColumnType("boolean");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Pin")
                        .HasColumnType("integer");

                    b.HasKey("_id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Cards");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Balance = 9466000m,
                            CustomerId = 5,
                            Holder = "Ravshan Mirzayev",
                            IsBlocked = false,
                            Number = "0000000000000001",
                            Pin = 4957
                        },
                        new
                        {
                            Id = 2,
                            Balance = 723000m,
                            CustomerId = 8,
                            Holder = "Lola Karimov",
                            IsBlocked = false,
                            Number = "0000000000000002",
                            Pin = 8568
                        },
                        new
                        {
                            Id = 3,
                            Balance = 6943000m,
                            CustomerId = 8,
                            Holder = "Gulnoza Ochilov",
                            IsBlocked = false,
                            Number = "0000000000000003",
                            Pin = 7663
                        },
                        new
                        {
                            Id = 4,
                            Balance = 9795000m,
                            CustomerId = 1,
                            Holder = "Umida Nazarov",
                            IsBlocked = false,
                            Number = "0000000000000004",
                            Pin = 4840
                        },
                        new
                        {
                            Id = 5,
                            Balance = 3086000m,
                            CustomerId = 6,
                            Holder = "Ismoil Yusupov",
                            IsBlocked = false,
                            Number = "0000000000000005",
                            Pin = 7135
                        },
                        new
                        {
                            Id = 6,
                            Balance = 7969000m,
                            CustomerId = 10,
                            Holder = "Zilola Ismailov",
                            IsBlocked = false,
                            Number = "0000000000000006",
                            Pin = 6858
                        },
                        new
                        {
                            Id = 7,
                            Balance = 6166000m,
                            CustomerId = 7,
                            Holder = "Feruza Usmanov",
                            IsBlocked = false,
                            Number = "0000000000000007",
                            Pin = 7471
                        },
                        new
                        {
                            Id = 8,
                            Balance = 6605000m,
                            CustomerId = 2,
                            Holder = "Sanjar Yusupov",
                            IsBlocked = false,
                            Number = "0000000000000008",
                            Pin = 9610
                        },
                        new
                        {
                            Id = 9,
                            Balance = 7737000m,
                            CustomerId = 8,
                            Holder = "Feruza Kamilov",
                            IsBlocked = false,
                            Number = "0000000000000009",
                            Pin = 4357
                        },
                        new
                        {
                            Id = 10,
                            Balance = 687000m,
                            CustomerId = 9,
                            Holder = "Azizbek Ergashev",
                            IsBlocked = false,
                            Number = "0000000000000010",
                            Pin = 9370
                        },
                        new
                        {
                            Id = 11,
                            Balance = 7302000m,
                            CustomerId = 10,
                            Holder = "Dilshod Ochilov",
                            IsBlocked = false,
                            Number = "0000000000000011",
                            Pin = 7705
                        },
                        new
                        {
                            Id = 12,
                            Balance = 732000m,
                            CustomerId = 2,
                            Holder = "Alisher Sodiqov",
                            IsBlocked = false,
                            Number = "0000000000000012",
                            Pin = 8892
                        },
                        new
                        {
                            Id = 13,
                            Balance = 6090000m,
                            CustomerId = 2,
                            Holder = "Shahzod Salimov",
                            IsBlocked = false,
                            Number = "0000000000000013",
                            Pin = 5230
                        },
                        new
                        {
                            Id = 14,
                            Balance = 7754000m,
                            CustomerId = 5,
                            Holder = "Olimjon Sultonov",
                            IsBlocked = false,
                            Number = "0000000000000014",
                            Pin = 9487
                        },
                        new
                        {
                            Id = 15,
                            Balance = 1378000m,
                            CustomerId = 4,
                            Holder = "Dilshod Karimov",
                            IsBlocked = false,
                            Number = "0000000000000015",
                            Pin = 3704
                        },
                        new
                        {
                            Id = 16,
                            Balance = 2680000m,
                            CustomerId = 4,
                            Holder = "Gulnoza Salimov",
                            IsBlocked = false,
                            Number = "0000000000000016",
                            Pin = 2206
                        },
                        new
                        {
                            Id = 17,
                            Balance = 3763000m,
                            CustomerId = 7,
                            Holder = "Zilola Ochilov",
                            IsBlocked = false,
                            Number = "0000000000000017",
                            Pin = 2426
                        },
                        new
                        {
                            Id = 18,
                            Balance = 8389000m,
                            CustomerId = 9,
                            Holder = "Ravshan Turaev",
                            IsBlocked = false,
                            Number = "0000000000000018",
                            Pin = 4708
                        },
                        new
                        {
                            Id = 19,
                            Balance = 3749000m,
                            CustomerId = 3,
                            Holder = "Azizbek To'rayev",
                            IsBlocked = false,
                            Number = "0000000000000019",
                            Pin = 7717
                        },
                        new
                        {
                            Id = 20,
                            Balance = 5074000m,
                            CustomerId = 3,
                            Holder = "Sardor Sharipov",
                            IsBlocked = false,
                            Number = "0000000000000020",
                            Pin = 9993
                        });
                });

            modelBuilder.Entity("EasyBank.Models.Customer", b =>
                {
                    b.Property<int>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("_id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("character varying(16)");

                    b.HasKey("_id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Qashqadaryo viloyati, Qarshi shahri, Ibrohimov ko'chasi, 22-uy",
                            FirstName = "Zuhra",
                            LastName = "Turaev",
                            Phone = "998640721019"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Samarkand viloyati, Qarshi shahri, Amir Temur ko'chasi, 8-uy",
                            FirstName = "Zilola",
                            LastName = "Sharipov",
                            Phone = "998689509460"
                        },
                        new
                        {
                            Id = 3,
                            Address = "Namangan viloyati, Chortoq tumani, Bobur ko'chasi, 34-uy",
                            FirstName = "Azizbek",
                            LastName = "Mirzayev",
                            Phone = "998533323682"
                        },
                        new
                        {
                            Id = 4,
                            Address = "Andijon viloyati, Oltiariq tumani, Buyuk Ipak Yuli ko'chasi, 11-uy",
                            FirstName = "Sardor",
                            LastName = "Abdullaev",
                            Phone = "998992337848"
                        },
                        new
                        {
                            Id = 5,
                            Address = "Samarkand viloyati, Qarshi shahri, Amir Temur ko'chasi, 8-uy",
                            FirstName = "Shukhrat",
                            LastName = "Davlatov",
                            Phone = "998909885482"
                        },
                        new
                        {
                            Id = 6,
                            Address = "Toshkent shahri, Yunusobod tumani, Alisher Navoi ko'chasi, 12-uy",
                            FirstName = "Nargiza",
                            LastName = "Nazarov",
                            Phone = "998594564262"
                        },
                        new
                        {
                            Id = 7,
                            Address = "Xorazm viloyati, Xiva shahri, Al-Xorezm ko'chasi, 9-uy",
                            FirstName = "Ravshan",
                            LastName = "Ochilov",
                            Phone = "998990220338"
                        },
                        new
                        {
                            Id = 8,
                            Address = "Sirdaryo viloyati, Guliston shahri, Amir Temur ko'chasi, 56-uy",
                            FirstName = "Lola",
                            LastName = "Usmanov",
                            Phone = "998437232006"
                        },
                        new
                        {
                            Id = 9,
                            Address = "Andijon viloyati, Oltiariq tumani, Buyuk Ipak Yuli ko'chasi, 11-uy",
                            FirstName = "Shahzod",
                            LastName = "Turaev",
                            Phone = "998842109685"
                        },
                        new
                        {
                            Id = 10,
                            Address = "Buxoro viloyati, Qorako'l tumani, Sharof Rashidov ko'chasi, 23-uy",
                            FirstName = "Ulugbek",
                            LastName = "Rustamov",
                            Phone = "998942431138"
                        });
                });

            modelBuilder.Entity("EasyBank.Models.Employee", b =>
                {
                    b.Property<int>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("_id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Attempts")
                        .HasColumnType("integer");

                    b.Property<int>("Code")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("character varying(16)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("_id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Jizzax viloyati, Zafar shahri, Alisher Navoi ko'chasi, 33-uy",
                            Attempts = 10,
                            Code = 111111,
                            Expires = new DateTime(2023, 9, 12, 12, 59, 20, 466, DateTimeKind.Utc).AddTicks(7725),
                            FirstName = "Sardor",
                            LastName = "Sodiqov",
                            Phone = "998239037170",
                            Position = "Senior",
                            Role = "Administrator"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Qashqadaryo viloyati, Qarshi shahri, Ibrohimov ko'chasi, 22-uy",
                            Attempts = 10,
                            Code = 111111,
                            Expires = new DateTime(2023, 9, 12, 12, 59, 20, 466, DateTimeKind.Utc).AddTicks(7737),
                            FirstName = "Shirin",
                            LastName = "Tashpulatov",
                            Phone = "998583025594",
                            Position = "Senior",
                            Role = "Director"
                        },
                        new
                        {
                            Id = 3,
                            Address = "Qashqadaryo viloyati, Karshi shahri, To'raqo'ziy ko'chasi, 90-uy",
                            Attempts = 10,
                            Code = 111111,
                            Expires = new DateTime(2023, 9, 12, 12, 59, 20, 466, DateTimeKind.Utc).AddTicks(7745),
                            FirstName = "Shahzod",
                            LastName = "Saidov",
                            Phone = "998201478223",
                            Position = "Lead",
                            Role = "Employee"
                        },
                        new
                        {
                            Id = 4,
                            Address = "Namangan viloyati, Uchqo'rg'on tumani, Sharof Rashidov ko'chasi, 67-uy",
                            Attempts = 10,
                            Code = 111111,
                            Expires = new DateTime(2023, 9, 12, 12, 59, 20, 466, DateTimeKind.Utc).AddTicks(7754),
                            FirstName = "Feruza",
                            LastName = "Ergashev",
                            Phone = "998599318911",
                            Position = "Junior",
                            Role = "Director"
                        },
                        new
                        {
                            Id = 5,
                            Address = "Navoiy viloyati, Karmana tumani, Olmazor ko'chasi, 5-uy",
                            Attempts = 10,
                            Code = 111111,
                            Expires = new DateTime(2023, 9, 12, 12, 59, 20, 466, DateTimeKind.Utc).AddTicks(7763),
                            FirstName = "Gulnoza",
                            LastName = "Zokirov",
                            Phone = "998953319153",
                            Position = "Senior",
                            Role = "Employee"
                        });
                });

            modelBuilder.Entity("EasyBank.Models.EmployeeAction", b =>
                {
                    b.Property<int>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("_id"));

                    b.Property<string>("_controller")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<string>("Endpoint")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("_status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Time")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("_id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeActions");
                });

            modelBuilder.Entity("EasyBank.Models.Transaction", b =>
                {
                    b.Property<int>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("_id"));

                    b.Property<int>("CardId")
                        .HasColumnType("integer");

                    b.Property<decimal>("TransactionAmount")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("TransactionDescription")
                        .HasColumnType("text");

                    b.Property<string>("TransactionType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("_id");

                    b.HasIndex("CardId");

                    b.ToTable("Transactions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CardId = 9,
                            TransactionAmount = 4087m,
                            TransactionDate = new DateTime(2022, 10, 13, 8, 44, 1, 466, DateTimeKind.Utc).AddTicks(7103),
                            TransactionDescription = "Description1",
                            TransactionType = "Пополнение"
                        },
                        new
                        {
                            Id = 2,
                            CardId = 1,
                            TransactionAmount = 9113m,
                            TransactionDate = new DateTime(2022, 9, 17, 15, 46, 53, 466, DateTimeKind.Utc).AddTicks(7128),
                            TransactionDescription = "Description2",
                            TransactionType = "Пополнение"
                        },
                        new
                        {
                            Id = 3,
                            CardId = 14,
                            TransactionAmount = 2597m,
                            TransactionDate = new DateTime(2023, 6, 2, 14, 4, 59, 466, DateTimeKind.Utc).AddTicks(7137),
                            TransactionDescription = "Description3",
                            TransactionType = "Пополнение"
                        },
                        new
                        {
                            Id = 4,
                            CardId = 6,
                            TransactionAmount = 3025m,
                            TransactionDate = new DateTime(2023, 5, 2, 10, 57, 13, 466, DateTimeKind.Utc).AddTicks(7147),
                            TransactionDescription = "Description4",
                            TransactionType = "Списание"
                        },
                        new
                        {
                            Id = 5,
                            CardId = 4,
                            TransactionAmount = 7976m,
                            TransactionDate = new DateTime(2022, 10, 7, 20, 49, 57, 466, DateTimeKind.Utc).AddTicks(7156),
                            TransactionDescription = "Description5",
                            TransactionType = "Списание"
                        },
                        new
                        {
                            Id = 6,
                            CardId = 9,
                            TransactionAmount = 5069m,
                            TransactionDate = new DateTime(2023, 6, 15, 1, 39, 53, 466, DateTimeKind.Utc).AddTicks(7166),
                            TransactionDescription = "Description6",
                            TransactionType = "Списание"
                        },
                        new
                        {
                            Id = 7,
                            CardId = 4,
                            TransactionAmount = 6032m,
                            TransactionDate = new DateTime(2023, 6, 17, 3, 53, 46, 466, DateTimeKind.Utc).AddTicks(7175),
                            TransactionDescription = "Description7",
                            TransactionType = "Списание"
                        },
                        new
                        {
                            Id = 8,
                            CardId = 18,
                            TransactionAmount = 3970m,
                            TransactionDate = new DateTime(2023, 7, 10, 21, 10, 8, 466, DateTimeKind.Utc).AddTicks(7184),
                            TransactionDescription = "Description8",
                            TransactionType = "Списание"
                        },
                        new
                        {
                            Id = 9,
                            CardId = 16,
                            TransactionAmount = 8230m,
                            TransactionDate = new DateTime(2023, 1, 15, 21, 46, 52, 466, DateTimeKind.Utc).AddTicks(7193),
                            TransactionDescription = "Description9",
                            TransactionType = "Списание"
                        },
                        new
                        {
                            Id = 10,
                            CardId = 17,
                            TransactionAmount = 7719m,
                            TransactionDate = new DateTime(2023, 6, 7, 11, 29, 17, 466, DateTimeKind.Utc).AddTicks(7203),
                            TransactionDescription = "Description10",
                            TransactionType = "Пополнение"
                        },
                        new
                        {
                            Id = 11,
                            CardId = 13,
                            TransactionAmount = 2685m,
                            TransactionDate = new DateTime(2022, 11, 13, 14, 27, 15, 466, DateTimeKind.Utc).AddTicks(7212),
                            TransactionDescription = "Description11",
                            TransactionType = "Пополнение"
                        },
                        new
                        {
                            Id = 12,
                            CardId = 10,
                            TransactionAmount = 3177m,
                            TransactionDate = new DateTime(2023, 5, 16, 18, 46, 36, 466, DateTimeKind.Utc).AddTicks(7221),
                            TransactionDescription = "Description12",
                            TransactionType = "Списание"
                        },
                        new
                        {
                            Id = 13,
                            CardId = 2,
                            TransactionAmount = 7248m,
                            TransactionDate = new DateTime(2022, 11, 8, 21, 45, 9, 466, DateTimeKind.Utc).AddTicks(7230),
                            TransactionDescription = "Description13",
                            TransactionType = "Списание"
                        },
                        new
                        {
                            Id = 14,
                            CardId = 14,
                            TransactionAmount = 3525m,
                            TransactionDate = new DateTime(2023, 3, 26, 7, 54, 40, 466, DateTimeKind.Utc).AddTicks(7239),
                            TransactionDescription = "Description14",
                            TransactionType = "Пополнение"
                        },
                        new
                        {
                            Id = 15,
                            CardId = 7,
                            TransactionAmount = 9148m,
                            TransactionDate = new DateTime(2022, 12, 15, 0, 11, 9, 466, DateTimeKind.Utc).AddTicks(7248),
                            TransactionDescription = "Description15",
                            TransactionType = "Пополнение"
                        },
                        new
                        {
                            Id = 16,
                            CardId = 17,
                            TransactionAmount = 5018m,
                            TransactionDate = new DateTime(2023, 8, 29, 18, 9, 16, 466, DateTimeKind.Utc).AddTicks(7257),
                            TransactionDescription = "Description16",
                            TransactionType = "Пополнение"
                        },
                        new
                        {
                            Id = 17,
                            CardId = 14,
                            TransactionAmount = 4542m,
                            TransactionDate = new DateTime(2023, 9, 6, 23, 8, 49, 466, DateTimeKind.Utc).AddTicks(7266),
                            TransactionDescription = "Description17",
                            TransactionType = "Списание"
                        },
                        new
                        {
                            Id = 18,
                            CardId = 7,
                            TransactionAmount = 3501m,
                            TransactionDate = new DateTime(2023, 1, 25, 21, 48, 46, 466, DateTimeKind.Utc).AddTicks(7402),
                            TransactionDescription = "Description18",
                            TransactionType = "Пополнение"
                        },
                        new
                        {
                            Id = 19,
                            CardId = 15,
                            TransactionAmount = 3760m,
                            TransactionDate = new DateTime(2023, 1, 14, 7, 14, 53, 466, DateTimeKind.Utc).AddTicks(7411),
                            TransactionDescription = "Description19",
                            TransactionType = "Списание"
                        },
                        new
                        {
                            Id = 20,
                            CardId = 4,
                            TransactionAmount = 3586m,
                            TransactionDate = new DateTime(2023, 3, 14, 3, 5, 26, 466, DateTimeKind.Utc).AddTicks(7452),
                            TransactionDescription = "Description20",
                            TransactionType = "Пополнение"
                        },
                        new
                        {
                            Id = 21,
                            CardId = 20,
                            TransactionAmount = 9075m,
                            TransactionDate = new DateTime(2023, 1, 26, 10, 23, 33, 466, DateTimeKind.Utc).AddTicks(7462),
                            TransactionDescription = "Description21",
                            TransactionType = "Списание"
                        },
                        new
                        {
                            Id = 22,
                            CardId = 18,
                            TransactionAmount = 1986m,
                            TransactionDate = new DateTime(2022, 11, 1, 21, 28, 7, 466, DateTimeKind.Utc).AddTicks(7471),
                            TransactionDescription = "Description22",
                            TransactionType = "Пополнение"
                        },
                        new
                        {
                            Id = 23,
                            CardId = 15,
                            TransactionAmount = 9534m,
                            TransactionDate = new DateTime(2023, 7, 20, 19, 44, 40, 466, DateTimeKind.Utc).AddTicks(7479),
                            TransactionDescription = "Description23",
                            TransactionType = "Пополнение"
                        },
                        new
                        {
                            Id = 24,
                            CardId = 19,
                            TransactionAmount = 1029m,
                            TransactionDate = new DateTime(2023, 8, 5, 4, 42, 31, 466, DateTimeKind.Utc).AddTicks(7635),
                            TransactionDescription = "Description24",
                            TransactionType = "Списание"
                        },
                        new
                        {
                            Id = 25,
                            CardId = 5,
                            TransactionAmount = 9937m,
                            TransactionDate = new DateTime(2023, 4, 18, 16, 4, 1, 466, DateTimeKind.Utc).AddTicks(7645),
                            TransactionDescription = "Description25",
                            TransactionType = "Списание"
                        },
                        new
                        {
                            Id = 26,
                            CardId = 6,
                            TransactionAmount = 9831m,
                            TransactionDate = new DateTime(2023, 4, 4, 5, 13, 55, 466, DateTimeKind.Utc).AddTicks(7654),
                            TransactionDescription = "Description26",
                            TransactionType = "Списание"
                        },
                        new
                        {
                            Id = 27,
                            CardId = 20,
                            TransactionAmount = 7894m,
                            TransactionDate = new DateTime(2023, 3, 26, 19, 9, 56, 466, DateTimeKind.Utc).AddTicks(7680),
                            TransactionDescription = "Description27",
                            TransactionType = "Списание"
                        },
                        new
                        {
                            Id = 28,
                            CardId = 4,
                            TransactionAmount = 6818m,
                            TransactionDate = new DateTime(2023, 3, 12, 16, 34, 19, 466, DateTimeKind.Utc).AddTicks(7689),
                            TransactionDescription = "Description28",
                            TransactionType = "Списание"
                        },
                        new
                        {
                            Id = 29,
                            CardId = 8,
                            TransactionAmount = 1439m,
                            TransactionDate = new DateTime(2023, 2, 9, 7, 18, 27, 466, DateTimeKind.Utc).AddTicks(7698),
                            TransactionDescription = "Description29",
                            TransactionType = "Пополнение"
                        },
                        new
                        {
                            Id = 30,
                            CardId = 12,
                            TransactionAmount = 2881m,
                            TransactionDate = new DateTime(2023, 9, 4, 18, 35, 40, 466, DateTimeKind.Utc).AddTicks(7708),
                            TransactionDescription = "Description30",
                            TransactionType = "Списание"
                        });
                });

            modelBuilder.Entity("EasyBank.Models.Card", b =>
                {
                    b.HasOne("EasyBank.Models.Customer", "Customer")
                        .WithMany("Cards")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("EasyBank.Models.EmployeeAction", b =>
                {
                    b.HasOne("EasyBank.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("EasyBank.Models.Transaction", b =>
                {
                    b.HasOne("EasyBank.Models.Card", "Card")
                        .WithMany("Transactions")
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Card");
                });

            modelBuilder.Entity("EasyBank.Models.Card", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("EasyBank.Models.Customer", b =>
                {
                    b.Navigation("Cards");
                });
#pragma warning restore 612, 618
        }
    }
}
