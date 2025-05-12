using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace QEApp.Domain.Entities.Courses
{
    // بخش‌های دوره
    public class Section
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        public int Order { get; set; }

        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public Course Course { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<Content> Contents { get; set; } = new List<Content>();
    }
}
