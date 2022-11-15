using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LMS_App.Models
{
    public partial class LMS_DbContext : DbContext
    {
        public LMS_DbContext()
        {
        }

        public LMS_DbContext(DbContextOptions<LMS_DbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Technology> Technology { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=CTSDOTNET052;Database=LMS_Db;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.CourseId)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.CourseDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CourseLink)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CourseName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TechId)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Technology>(entity =>
            {
                entity.HasKey(e => e.TechId);

                entity.Property(e => e.TechId)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.CourseId)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.TechName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.UserCourseId).HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserRole)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.UserTechId)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
