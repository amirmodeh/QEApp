using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QEApp.Domain.Entities.Users;
using QEApp.Domain.Entities.Courses;

namespace QEApp.Domain.Entities.Questions
{
    // سوال (متنی یا چندگزینه‌ای)
    public class Question
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Content { get; set; }

        [Required]
        [MaxLength(20)]
        public string QuestionType { get; set; } // "Text", "MultipleChoice", "Survey"

        [MaxLength(1000)]
        public string? Answer { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? AnsweredAt { get; set; }

        [Required]
        public string StudentId { get; set; }

        public string? InstructorId { get; set; }

        [Required]
        public int CourseId { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey("StudentId")]
        public User Student { get; set; }

        [ForeignKey("InstructorId")]
        public User? Instructor { get; set; }

        [ForeignKey("CourseId")]
        public Course Course { get; set; }

        public ICollection<QuestionOption> Options { get; set; } = new List<QuestionOption>();
        public ICollection<UserAnswer> UserAnswers { get; set; } = new List<UserAnswer>();
    }
}
