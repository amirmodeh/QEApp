using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QEApp.Domain.Entities.Users;

namespace QEApp.Domain.Entities.Questions
{
    // پاسخ کاربران به سوالات چندگزینه‌ای
    public class UserAnswer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string StudentId { get; set; }

        [Required]
        public int QuestionId { get; set; }

        public int? OptionId { get; set; }

        [MaxLength(1000)]
        public string? TextAnswer { get; set; }

        [Required]
        public DateTime AnsweredAt { get; set; }
        public bool IsDeleted { get; set; }
        [ForeignKey("StudentId")]
        public User Student { get; set; }

        [ForeignKey("QuestionId")]
        public Question Question { get; set; }

        [ForeignKey("OptionId")]
        public QuestionOption? Option { get; set; }
    }
}
