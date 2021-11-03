using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace QuizletClone.Models
{
    public partial class DBQuizSharpContext : DbContext
    {
        public DBQuizSharpContext()
        {
        }

        public DBQuizSharpContext(DbContextOptions<DBQuizSharpContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Quiz> Quizzes { get; set; }
        public virtual DbSet<SetStudy> SetStudies { get; set; }
        public virtual DbSet<SetStudyQuiz> SetStudyQuizzes { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:DBQuizSharp");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Quiz>(entity =>
            {
                entity.ToTable("Quiz");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Definition)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("definition");

                entity.Property(e => e.Term)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("term");
            });

            modelBuilder.Entity<SetStudy>(entity =>
            {
                entity.ToTable("Set_Study");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SetStudies)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Set_Study_User");
            });

            modelBuilder.Entity<SetStudyQuiz>(entity =>
            {
                entity.HasKey(e => new { e.QuizId, e.SetStudyId });

                entity.ToTable("Set_Study_Quiz");

                entity.Property(e => e.QuizId).HasColumnName("quiz_id");

                entity.Property(e => e.SetStudyId).HasColumnName("set_study_id");

                entity.HasOne(d => d.Quiz)
                    .WithMany(p => p.SetStudyQuizzes)
                    .HasForeignKey(d => d.QuizId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Set_Study_Quiz_Quiz");

                entity.HasOne(d => d.SetStudy)
                    .WithMany(p => p.SetStudyQuizzes)
                    .HasForeignKey(d => d.SetStudyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Set_Study_Quiz_Set_Study");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasIndex(e => e.Username, "Unique_User")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "Unique_email")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AvatarUrl)
                    .IsRequired()
                    .HasColumnName("avatar_url");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("dob");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
