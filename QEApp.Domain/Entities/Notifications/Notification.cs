using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QEApp.Domain.Entities.Users;

namespace QEApp.Domain.Entities.Notifications
{
    // اعلان
    public class Notification
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Message { get; set; }

        [Required]
        [MaxLength(20)]
        public string NotificationType { get; set; } // "Email", "SMS", "InApp"

        public bool IsRead { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
