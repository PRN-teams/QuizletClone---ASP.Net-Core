using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApplication1.Models
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

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Bill> Bill { get; set; }
        public virtual DbSet<Contract> Contract { get; set; }
        public virtual DbSet<LearningMode> LearningMode { get; set; }
        public virtual DbSet<LearningProgress> LearningProgress { get; set; }
        public virtual DbSet<Quiz> Quiz { get; set; }
        public virtual DbSet<SetStudy> SetStudy { get; set; }
        public virtual DbSet<SetStudyQuiz> SetStudyQuiz { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:DBQuizSharp");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.AccountId).HasColumnName("accountID");

                entity.Property(e => e.Role)
                    .HasColumnName("role")
                    .HasMaxLength(10);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(50);

                entity.Property(e => e.UId).HasColumnName("uID");

                entity.HasOne(d => d.U)
                    .WithMany(p => p.Account)
                    .HasForeignKey(d => d.UId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Account_User");
            });

            modelBuilder.Entity<Bill>(entity =>
            {
                entity.Property(e => e.BillId).HasColumnName("BillID");

                entity.Property(e => e.Currency).HasMaxLength(20);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.OrderId)
                    .HasColumnName("OrderID")
                    .HasMaxLength(100);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.UId).HasColumnName("uID");

                entity.HasOne(d => d.U)
                    .WithMany(p => p.Bill)
                    .HasForeignKey(d => d.UId)
                    .HasConstraintName("FK_Bill_User");
            });

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.ToTable("contract");

                entity.Property(e => e.ContractId).HasColumnName("ContractID");

                entity.Property(e => e.ExpiredDate)
                    .HasColumnName("expiredDate")
                    .HasColumnType("date");

                entity.Property(e => e.StartDate)
                    .HasColumnName("startDate")
                    .HasColumnType("date");

                entity.Property(e => e.Uid).HasColumnName("uid");

                entity.HasOne(d => d.U)
                    .WithMany(p => p.Contract)
                    .HasForeignKey(d => d.Uid)
                    .HasConstraintName("FK_contract_User");
            });

            modelBuilder.Entity<LearningMode>(entity =>
            {
                entity.HasKey(e => e.ModeId);

                entity.ToTable("Learning_Mode");

                entity.Property(e => e.ModeId)
                    .HasColumnName("modeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ModeName)
                    .IsRequired()
                    .HasColumnName("modeName")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<LearningProgress>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Learning_Progress");

                entity.Property(e => e.ModeId).HasColumnName("ModeID");

                entity.Property(e => e.QuizId).HasColumnName("QuizID");

                entity.Property(e => e.SetId).HasColumnName("SetID");

                entity.Property(e => e.UId).HasColumnName("uID");

                entity.HasOne(d => d.Mode)
                    .WithMany()
                    .HasForeignKey(d => d.ModeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Learning_Progress_Learning_Mode");

                entity.HasOne(d => d.U)
                    .WithMany()
                    .HasForeignKey(d => d.UId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Learning_Progress_User");

                entity.HasOne(d => d.SetStudyQuiz)
                    .WithMany()
                    .HasForeignKey(d => new { d.QuizId, d.SetId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Learning_Progress_Set_Study_Quiz");
            });

            modelBuilder.Entity<Quiz>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Definition)
                    .IsRequired()
                    .HasColumnName("definition")
                    .HasColumnType("text");

                entity.Property(e => e.Term)
                    .IsRequired()
                    .HasColumnName("term")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<SetStudy>(entity =>
            {
                entity.ToTable("Set_Study");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SetStudy)
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
                    .WithMany(p => p.SetStudyQuiz)
                    .HasForeignKey(d => d.QuizId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Set_Study_Quiz_Quiz");

                entity.HasOne(d => d.SetStudy)
                    .WithMany(p => p.SetStudyQuiz)
                    .HasForeignKey(d => d.SetStudyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Set_Study_Quiz_Set_Study");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("Unique_email")
                    .IsUnique();

                entity.HasIndex(e => e.Username)
                    .HasName("Unique_User")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AvatarUrl)
                    .IsRequired()
                    .HasColumnName("avatar_url");

                entity.Property(e => e.Dob)
                    .HasColumnName("dob")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
