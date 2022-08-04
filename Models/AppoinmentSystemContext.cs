using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AppointmentSystem.Models
{
    public partial class AppoinmentSystemContext : DbContext
    {
        public AppoinmentSystemContext()
        {
        }

        public AppoinmentSystemContext(DbContextOptions<AppoinmentSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AppoinmentDetails> AppoinmentDetails { get; set; }
        public virtual DbSet<Doctor> Doctor { get; set; }
        public virtual DbSet<Logs> Logs { get; set; }
        public virtual DbSet<PatientMaster> PatientMaster { get; set; }
        public virtual DbSet<UserType> UserType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=AppoinmentSystem;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppoinmentDetails>(entity =>
            {
                entity.HasKey(e => e.AppoinmentId);

                entity.Property(e => e.AppoinmnetDate).HasColumnType("datetime");

                entity.Property(e => e.DoctorId).HasDefaultValueSql("((0))");

                entity.Property(e => e.DoctorName).HasMaxLength(50);

                entity.Property(e => e.EmailId)
                    .HasMaxLength(70)
                    .HasDefaultValueSql("(N'-')");

                entity.Property(e => e.MobileNumber)
                    .HasMaxLength(12)
                    .HasDefaultValueSql("(N'-')");

                entity.Property(e => e.PatientId).HasDefaultValueSql("((0))");

                entity.Property(e => e.PatientName)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'-')");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.DocId);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.DocName)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'-')");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(70)
                    .HasDefaultValueSql("(N'-')");

                entity.Property(e => e.MobileNumber)
                    .HasMaxLength(12)
                    .HasDefaultValueSql("(N'-')");

                entity.Property(e => e.Password)
                    .HasMaxLength(8)
                    .HasDefaultValueSql("(N'-')");

                entity.Property(e => e.Specialization)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'-')");
            });

            modelBuilder.Entity<Logs>(entity =>
            {
                entity.HasKey(e => e.Logid)
                    .HasName("PK__logs__7838F2657C00C07B");

                entity.ToTable("logs");

                entity.Property(e => e.Logid).HasColumnName("logid");

                entity.Property(e => e.Actionname)
                    .HasColumnName("actionname")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Controllername)
                    .HasColumnName("controllername")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Logtype)
                    .HasColumnName("logtype")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Message).HasColumnName("message");

                entity.Property(e => e.CreatedOn)
                .HasColumnName("createdon")
                .IsUnicode(false); 
            });

            modelBuilder.Entity<PatientMaster>(entity =>
            {
                entity.HasKey(e => e.PatientId);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'-')");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(70)
                    .HasDefaultValueSql("(N'-')");

                entity.Property(e => e.MobileNumber)
                    .HasMaxLength(12)
                    .HasDefaultValueSql("(N'-')");

                entity.Property(e => e.Password)
                    .HasMaxLength(8)
                    .HasDefaultValueSql("(N'-')");

                entity.Property(e => e.PatientName)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'-')");

                entity.Property(e => e.UserType).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.Property(e => e.UserTypeId).HasColumnName("UserTypeID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'-')");

                entity.Property(e => e.UserType1)
                    .HasColumnName("UserType")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("(N'-')");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
