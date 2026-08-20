using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Core_Database.Models
{
    [Table("Customers")]
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CompanyName { get; set; } = string.Empty;

        [Required]
        public string ContactName { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        public string? Phone { get; set; }

        [Required]
        public string CreatedAt { get; set; } = string.Empty;

        [Required]
        public bool IsActive { get; set; }

        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}