using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Core_Database.Models
{
    [Table("TicketStatuses")]
    public class TicketStatus
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public bool IsClosed { get; set; }
    }
}