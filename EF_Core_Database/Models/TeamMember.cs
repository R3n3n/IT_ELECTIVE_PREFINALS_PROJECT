using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Core_Database.Models
{
    [Table("TeamMembers")]
    [PrimaryKey(nameof(TeamId), nameof(EmployeeId))]
    public class TeamMember
    {
        [Required]
        public int TeamId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public string JoinedAt { get; set; } = string.Empty;

        [ForeignKey(nameof(TeamId))]
        public Team Team { get; set; } = null!;

        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; } = null!;
    }
}