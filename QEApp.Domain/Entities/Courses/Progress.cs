using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QEApp.Domain.Entities.Users;

namespace QEApp.Domain.Entities.Courses
{
    // پیشرفت دانشجو
    public class Progress
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string StudentId { get; set; }

        [Required]
        public int ContentId { get; set; }

        public bool IsViewed { get; set; }
        public bool IsTaskCompleted { get; set; }
        public int Score { get; set; } = 0;

        [Required]
        public DateTime LastUpdated { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey("StudentId")]
        public User Student { get; set; }

        [ForeignKey("ContentId")]
        public Content Content { get; set; }
    }
}
