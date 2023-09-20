#nullable disable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EasyBank.Models
{
    [Table("Customers")]
    public class Customer
    {
        [Key]                        public int Id { get; set; }
        [Required]                   public string FirstName { get; set; }
        [Required]                   public string LastName { get; set; }
        [Required, StringLength(16)] public string Phone { get; set; }
        [Required]                   public string Address { get; set; }
        [JsonIgnore]                 public List<Card> Cards { get; set; }
    }
}
