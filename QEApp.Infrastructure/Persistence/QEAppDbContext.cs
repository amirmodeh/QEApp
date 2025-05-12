using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QEApp.Domain.Entities.Courses;
using QEApp.Domain.Entities.News;
using QEApp.Domain.Entities.Notifications;
using QEApp.Domain.Entities.Questions;
using QEApp.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QEApp.Infrastructure.Persistence
{ 
 public class QEAppDbContext : IdentityDbContext<User>
{
    public QEAppDbContext(DbContextOptions<QEAppDbContext> options)
        : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Section> Sections { get; set; }
    public DbSet<Content> Contents { get; set; }
    public DbSet<Progress> Progresses { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<QuestionOption> QuestionOptions { get; set; }
    public DbSet<UserAnswer> UserAnswers { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<News> News { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // User
        modelBuilder.Entity<User>()
            .HasIndex(u => u.MobileNumber)
            .IsUnique();
        modelBuilder.Entity<User>()
            .Property(u => u.Role)
            .HasDefaultValue("Student");

        // Course
        modelBuilder.Entity<Course>()
            .HasIndex(c => c.Title);
        modelBuilder.Entity<Course>()
            .HasOne(c => c.Instructor)
            .WithMany(u => u.TaughtCourses)
            .HasForeignKey(c => c.InstructorId)
            .OnDelete(DeleteBehavior.SetNull);

        // Course-Student (چندبه‌چند)
        modelBuilder.Entity<Course>()
            .HasMany(c => c.Students)
            .WithMany(u => u.EnrolledCourses)
            .UsingEntity(j => j.ToTable("CourseStudents"));

        // Section
        modelBuilder.Entity<Section>()
            .HasOne(s => s.Course)
            .WithMany(c => c.Sections)
            .HasForeignKey(s => s.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

        // Content
        modelBuilder.Entity<Content>()
            .HasOne(c => c.Section)
            .WithMany(s => s.Contents)
            .HasForeignKey(c => c.SectionId)
            .OnDelete(DeleteBehavior.Cascade);

        // Progress
        modelBuilder.Entity<Progress>()
            .HasOne(p => p.Student)
            .WithMany(u => u.Progresses)
            .HasForeignKey(p => p.StudentId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Progress>()
            .HasOne(p => p.Content)
            .WithMany(c => c.Progresses)
            .HasForeignKey(p => p.ContentId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Progress>()
            .HasIndex(p => new { p.StudentId, p.ContentId })
            .IsUnique();

        // Question
        modelBuilder.Entity<Question>()
            .HasOne(q => q.Student)
            .WithMany(u => u.QuestionsAsked)
            .HasForeignKey(q => q.StudentId)
            .OnDelete(DeleteBehavior.NoAction); // از قبل اصلاح شده
        modelBuilder.Entity<Question>()
            .HasOne(q => q.Instructor)
            .WithMany(u => u.QuestionsAnswered)
            .HasForeignKey(q => q.InstructorId)
            .OnDelete(DeleteBehavior.SetNull);
        modelBuilder.Entity<Question>()
            .HasOne(q => q.Course)
            .WithMany(c => c.Questions)
            .HasForeignKey(q => q.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

        // QuestionOption
        modelBuilder.Entity<QuestionOption>()
            .HasOne(qo => qo.Question)
            .WithMany(q => q.Options)
            .HasForeignKey(qo => qo.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);

        // UserAnswer
        modelBuilder.Entity<UserAnswer>()
            .HasOne(ua => ua.Student)
            .WithMany()
            .HasForeignKey(ua => ua.StudentId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<UserAnswer>()
            .HasOne(ua => ua.Question)
            .WithMany(q => q.UserAnswers)
            .HasForeignKey(ua => ua.QuestionId)
            .OnDelete(DeleteBehavior.NoAction); // تغییر به NoAction برای رفع خطا
        modelBuilder.Entity<UserAnswer>()
            .HasOne(ua => ua.Option)
            .WithMany()
            .HasForeignKey(ua => ua.OptionId)
            .OnDelete(DeleteBehavior.SetNull);

        // Notification
        modelBuilder.Entity<Notification>()
            .HasOne(n => n.User)
            .WithMany(n => n.Notifications)
            .HasForeignKey(n => n.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Notification>()
            .Property(n => n.IsRead)
            .HasDefaultValue(false);

        // News
        modelBuilder.Entity<News>()
            .HasOne(n => n.Author)
            .WithMany()
            .HasForeignKey(n => n.AuthorId)
            .OnDelete(DeleteBehavior.SetNull);


        base.OnModelCreating(modelBuilder);
    }
}
}