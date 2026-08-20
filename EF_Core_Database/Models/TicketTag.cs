using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;

namespace EF_Core_Database.Models
{
    [Table("TicketTags")]
    [PrimaryKey(nameof(TicketId), nameof(TagId))]
    public class TicketTag
    {
        [Required]
        public int TicketId { get; set; }

        [Required]
        public int TagId { get; set; }

        [ForeignKey(nameof(TicketId))]
        public Ticket Ticket { get; set; } = null!;

        [ForeignKey(nameof(TagId))]
        public Tag Tag { get; set; } = null!;

    }
}
