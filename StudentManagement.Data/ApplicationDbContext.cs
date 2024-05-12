using Microsoft.EntityFrameworkCore;
using StudentManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamResult> ExamResults { get; set; }
        public DbSet<QnAs> QnAs { get; set; }
        public DbSet<Student> Students { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ExamResult>(entity =>
            {
                entity.HasOne(d => d.Exam)
                .WithMany(p => p.ExamResults)
                .HasForeignKey(x => x.ExamId)
                .HasConstraintName("FK_ExamResults_Exams");

                entity.HasOne(d => d.QnAs)
                .WithMany(p => p.ExamResults)
                .HasForeignKey(x => x.QnAsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ExamResults_QnAs");
                
                entity.HasOne(d => d.Student)
                .WithMany(p => p.ExamResults)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ExamResults_Users");
            });



            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, Name = "Admin", Password = "admin", Role = 1, UserName = "admin" }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
