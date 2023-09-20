#nullable disable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EasyBank.Models
{
    [Table("Transactions")]
    public class Transaction
    {
        [Key]                                public int Id { get; set; }
        [Required]                           public string TransactionType { get; set; }
        [Required]                           public DateTime TransactionDate { get; set; }
        [Required]                           public decimal TransactionAmount { get; set; }
                                             public string TransactionDescription { get; set; }
        [Required, ForeignKey(nameof(Card))] public int CardId { get; set; }
        [JsonIgnore]                         public Card Card { get; set; }
    }
}
