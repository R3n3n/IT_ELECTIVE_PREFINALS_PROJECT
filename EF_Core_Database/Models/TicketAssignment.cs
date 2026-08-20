using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;

namespace EF_Core_Database.Models
{
    [Table("TicketAssignments")]
    [PrimaryKey(nameof(TicketId), nameof(EmployeeId))]
    public class TicketAssignment
    {
        [Required]
        public int TicketId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public DateTime AssignedAt { get; set; }

        public DateTime? UnassignedAt { get; set; }

        public bool IsPrimary { get; set; }

        [ForeignKey(nameof(TicketId))]
        public Ticket Ticket { get; set; } = null!;

        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; } = null!;
    }
}
