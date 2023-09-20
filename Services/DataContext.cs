using EasyBank.Models;
using Microsoft.EntityFrameworkCore;

namespace EasyBank.Services
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration? configuration;
        public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration) : base(options)
        {
            this.configuration=configuration;
            // Database.EnsureDeleted();
            // Database.EnsureCreated();
        }
        public DbSet<Card> Cards { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Transaction> Transactions { get; set; } = null!;
        public DbSet<EmployeeAction> EmployeeActions { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(configuration?.GetConnectionString("DataContext") ?? throw new InvalidOperationException("Connection string 'DataContext' not found."));
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //GenerateData(modelBuilder);
        }


        #region Generate Data
        private readonly string[] positions =
        {
            "Intern", "Junior", "Middle", "Senior", "Lead",
            "Architect", "Director", "Project Manager", "Product Manager"
        };
        private readonly string[] roles = { "Administrator", "Director", "Employee" };
        private readonly string[] names =
        {
            "Alisher","Dilshod","Munisa","Ravshan","Nigora","Olimjon",
            "Feruza","Azizbek","Zarina","Javohir","Nasiba","Akmal",
            "Nargiza","Shukhrat","Gulnoza","Sardor","Umida","Islom",
            "Zilola","Ulugbek","Gulshan","Shahzod","Dilnoza","Sanjar",
            "Shirin","Ismoil","Lola","Farrukh","Zuhra"
        };
        private readonly string[] surnames =
        {
            "Ismailov","Tashpulatov","Saidov","Karimov","Yusupov","Mirzayev",
            "Rahmonov","Abdullaev","Nazarov","Kurbanov","Rustamov","Sobirov",
            "Ergashev","Zokirov","Usmanov","Davlatov","Kamilov","Sultonov",
            "To'rayev","Muminov","Sharipov","Umarov","Xolmirzayev","Salimov",
            "Olimov","Turaev","Sodiqov","Xushnud","G'afurov","Ochilov",
        };
        private readonly string[] addresses =
        {
            "Toshkent shahri, Yunusobod tumani, Alisher Navoi ko'chasi, 12-uy",
            "Namangan viloyati, Chortoq tumani, Bobur ko'chasi, 34-uy",
            "Andijon viloyati, Qorasuv tumani, Navoi ko'chasi, 56-uy",
            "Samarkand viloyati, Urgut tumani, Mirzo Ulug'bek ko'chasi, 78-uy",
            "Farg'ona viloyati, Rishton shahri, Islom Karimov ko'chasi, 45-uy",
            "Buxoro viloyati, Qorako'l tumani, Sharof Rashidov ko'chasi, 23-uy",
            "Navoiy viloyati, Navoiy shahri, Abdulla Qodiriy ko'chasi, 7-uy",
            "Sirdaryo viloyati, Guliston shahri, Amir Temur ko'chasi, 56-uy",
            "Qashqadaryo viloyati, Karshi shahri, To'raqo'ziy ko'chasi, 90-uy",
            "Surxondaryo viloyati, Termiz shahri, Navoiy ko'chasi, 11-uy",
            "Xorazm viloyati, Urganch shahri, Oybek ko'chasi, 3-uy",
            "Jizzax viloyati, Jizzax shahri, Temiryo'l tumani, Sheroziy ko'chasi, 19-uy",
            "Toshkent viloyati, Chirchiq shahri, Xalq ko'chasi, 67-uy",
            "Namangan viloyati, Namangan shahri, Buyuk Ipak Yuli ko'chasi, 45-uy",
            "Andijon viloyati, Andijon shahri, Navoi ko'chasi, 8-uy",
            "Samarkand viloyati, Samarkand shahri, Registon ko'chasi, 101-uy",
            "Farg'ona viloyati, Farg'ona shahri, Yakkasaroy tumani, Iroq ko'chasi, 30-uy",
            "Buxoro viloyati, G'ijduvon tumani, Navoiy ko'chasi, 12-uy",
            "Navoiy viloyati, Karmana tumani, Olmazor ko'chasi, 5-uy",
            "Sirdaryo viloyati, Yangiyer shahri, Navoiy ko'chasi, 56-uy",
            "Qashqadaryo viloyati, Qarshi shahri, Ibrohimov ko'chasi, 22-uy",
            "Surxondaryo viloyati, Denov shahri, Dustlik ko'chasi, 17-uy",
            "Xorazm viloyati, Xiva shahri, Al-Xorezm ko'chasi, 9-uy",
            "Jizzax viloyati, Zafar shahri, Alisher Navoi ko'chasi, 33-uy",
            "Toshkent viloyati, Buka shahri, G'ofur G'ulom ko'chasi, 4-uy",
            "Namangan viloyati, Uchqo'rg'on tumani, Sharof Rashidov ko'chasi, 67-uy",
            "Andijon viloyati, Oltiariq tumani, Buyuk Ipak Yuli ko'chasi, 11-uy",
            "Samarkand viloyati, Qarshi shahri, Amir Temur ko'chasi, 8-uy",
            "Farg'ona viloyati, Marg'ilon shahri, Gulistan ko'chasi, 22-uy",
            "Buxoro viloyati, Qorako'l tumani, Temur Malik ko'chasi, 14-uy"
        };

        protected void GenerateData(ModelBuilder modelBuilder)
        {
            // Создаём объект Рандом для генерации случайных значений
            Random random = new Random();
            // Для Таблицы Customer
            for (int i = 1; i <= 10; i++)
            {
                modelBuilder.Entity<Customer>().HasData(
                    new Customer
                    {
                        Id = i,
                        FirstName = names[random.Next(0, names.Length)],
                        LastName = surnames[random.Next(0, surnames.Length)],
                        Address = addresses[random.Next(0, addresses.Length)],
                        Phone = $"998{random.Next(100000000, 1000000000)}",
                    }
                );
            }
            // Для Таблицы Card
            for (int i = 1; i <= 20; i++)
            {
                modelBuilder.Entity<Card>().HasData(
                    new Card
                    {
                        Id = i,
                        Number = i.ToString().PadLeft(16, '0'),
                        Holder = $"{names[random.Next(0, names.Length)]} {surnames[random.Next(0, surnames.Length)]}",
                        Pin = random.Next(1000, 10000),
                        Balance = random.Next(100, 10000) * 1000,
                        IsBlocked = false,
                        CustomerId = random.Next(1, 11),
                    }
                );
            }
            // Для Таблицы Transaction
            for (int i = 1; i <= 30; i++)
            {
                modelBuilder.Entity<Transaction>().HasData(
                    new Transaction
                    {
                        Id = i,
                        TransactionType = random.Next(0, 2) == 0 ? "Пополнение" : "Списание",
                        TransactionDate = DateTime.UtcNow
                            .AddDays(-1 * random.Next(1, 365))
                            .AddHours(-1 * random.Next(1, 24))
                            .AddMinutes(-1 * random.Next(1, 60))
                            .AddSeconds(-1 * random.Next(1, 60)),
                        TransactionAmount = random.Next(1000, 9999),
                        TransactionDescription = $"Description{i}",
                        CardId = random.Next(1, 21),
                    }
                );
            }
            // Для Таблицы Employee
            for (int i = 1; i <= 5; i++)
            {
                modelBuilder.Entity<Employee>().HasData(
                    new Employee
                    {
                        Id = i,
                        FirstName = names[random.Next(0, names.Length)],
                        LastName = surnames[random.Next(0, surnames.Length)],
                        Address = addresses[random.Next(0, addresses.Length)],
                        Phone = $"998{random.Next(100000000, 1000000000)}",
                        Position = positions[random.Next(0, positions.Length)],
                        Role = roles[random.Next(0, roles.Length)],
                        Attempts = 10,
                        Expires = DateTime.UtcNow,
                    }
                );
            }
        }
        #endregion
    }
}