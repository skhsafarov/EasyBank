#nullable disable

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyBank.Models
{
    [Table("Employees")]
    public class Employee
    {
        public Employee()
        {
            Code = 111111;
            Attempts = 10;
            Expires = DateTime.UtcNow;
        }
        public Employee(string firstName, string lastName, string position, string phone, string address, string role = "Employee") : this()
        {
            FirstName = firstName;
            LastName = lastName;
            Position = position;
            Role = role;
            Phone = phone;
            Address = address;
        }

        [Key]                             public int Id { get; set; }
        [Required]                        public string FirstName { get; set; }
        [Required]                        public string LastName { get; set; }
        [Required]                        public string Position { get; set; }
        [Required, StringLength(50)]      public string Role { get; set; }
        [Required, StringLength(16)]      public string Phone { get; set; }
        [Required]                        public string Address { get; set; }
        [Required, Range(100000, 999999)] public int Code { get; set; }
        [Required, Range(0, 10)]          public int Attempts { get; set; }
        [Required]                        public DateTime Expires { get; set; }
    }
}
