using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QEApp.Domain.Entities.Questions
{
    // گزینه‌های سوال چندگزینه‌ای
    public class QuestionOption
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Text { get; set; }

        public bool IsCorrect { get; set; }

        public int QuestionId { get; set; }
        public bool IsDeleted { get; set; }
        [ForeignKey("QuestionId")]
        public Question Question { get; set; }
    }
}
