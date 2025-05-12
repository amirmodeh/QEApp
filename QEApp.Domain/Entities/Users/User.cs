using Microsoft.AspNetCore.Identity;
using QEApp.Domain.Entities.Courses;
using QEApp.Domain.Entities.Notifications;
using QEApp.Domain.Entities.Questions;
using System.ComponentModel.DataAnnotations;


namespace QEApp.Domain.Entities.Users
{
    // کاربر سامانه: دانش‌آموز، استاد، مدیر
    public class User : IdentityUser
    {
        [Required, MaxLength(15)]
        public string MobileNumber { get; set; } = null!;
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(100), EmailAddress]
        public override string? Email { get; set; }
        [Required, MaxLength(20)]
        public string Role { get; set; } = "Student"; // پیشنهاد: تبدیل به enum
        [MaxLength(20)]
        public string? AccessLevel { get; set; }
        [MaxLength(6)]
        public string? OtpCode { get; set; }
        public DateTime? OtpExpiresAt { get; set; }
        public int TotalScore { get; set; } = 0;
        [Required]
        public bool IsDeleted { get; set; } = false;

        // Navigation Properties
        public ICollection<Course> EnrolledCourses { get; set; } = new List<Course>();
        public ICollection<Course> TaughtCourses { get; set; } = new List<Course>();
        public ICollection<Progress> Progresses { get; set; } = new List<Progress>();
        public ICollection<Question> QuestionsAsked { get; set; } = new List<Question>();
        public ICollection<Question> QuestionsAnswered { get; set; } = new List<Question>();
        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
    }
}
