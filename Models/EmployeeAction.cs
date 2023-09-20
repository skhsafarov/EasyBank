using EasyBank.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EasyBank.Models
{
    public class EmployeeAction
    {
        public EmployeeAction()
        {
            Time = DateTime.UtcNow;
        }
        public EmployeeAction(string controller, string endpoint, string status, int employeeId) : this()
        {
            Controller=controller;
            Endpoint=endpoint;
            Status=status;
            EmployeeId=employeeId;
        }

        [Key]                                    public int Id { get; set; }
        [Required]                               public string Controller { get; set; }
        [Required]                               public string Endpoint { get; set; }
        [Required]                               public string Status { get; set; }
        [Required]                               public DateTime Time { get; set; }
        [Required, ForeignKey(nameof(Employee))] public int EmployeeId { get; set; }
        [JsonIgnore]                             public Employee Employee { get; set; }
    }
}
