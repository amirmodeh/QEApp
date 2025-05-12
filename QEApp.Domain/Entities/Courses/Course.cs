using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using QEApp.Domain.Entities.Users;
using QEApp.Domain.Entities.Questions;

namespace QEApp.Domain.Entities.Courses
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string? Description { get; set; }

        [Required]
        [MaxLength(50)]
        public string Category { get; set; }

        public bool IsPublic { get; set; }
        public bool IsDownloadable { get; set; }

        public string? InstructorId { get; set; }
        [ForeignKey("InstructorId")]
        public User? Instructor { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<Section> Sections { get; set; } = new List<Section>();
        public ICollection<User> Students { get; set; } = new List<User>();
        public ICollection<Question> Questions { get; set; } = new List<Question>();
    }

}
