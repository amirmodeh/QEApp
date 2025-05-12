using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QEApp.Domain.Entities.Users;

namespace QEApp.Domain.Entities.News
{
    // اخبار و اطلاعیه‌ها
    public class News
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        [MaxLength(5000)]
        public string Content { get; set; }

        [Required]
        public DateTime PublishedAt { get; set; }

        public string? AuthorId { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey("AuthorId")]
        public User? Author { get; set; }
    }
}
