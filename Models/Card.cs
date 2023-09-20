#nullable disable

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EasyBank.Models
{
    [Table("Cards")]
    public class Card
    {
        public Card()
        {
            Balance = 0;
            IsBlocked = false;
        }

        [Key]                                    public int Id { get; set; }
        [Required]                               public string Number { get; set; }
        [Required]                               public string Holder { get; set; }
        [Required, Range(1000, 9999)]            public int Pin { get; set; }
        [Required]                               public decimal Balance { get; set; }
        [Required]                               public bool IsBlocked { get; set; }
        [Required, ForeignKey(nameof(Customer))] public int CustomerId { get; set; }
        [JsonIgnore]                             public Customer Customer { get; set; }
        [JsonIgnore]                             public List<Transaction> Transactions { get; set; }
    }
}
