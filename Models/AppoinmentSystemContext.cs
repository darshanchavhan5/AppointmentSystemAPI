using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

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

        public virtual DbSet<AppoinmentDetail> AppoinmentDetails { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<PatientMaster> PatientMasters { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=AppoinmentSystem;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AppoinmentDetail>(entity =>
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
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.DocId);

                entity.ToTable("Doctor");

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

            modelBuilder.Entity<PatientMaster>(entity =>
            {
                entity.HasKey(e => e.PatientId);

                entity.ToTable("PatientMaster");

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
                entity.ToTable("UserType");

                entity.Property(e => e.UserTypeId).HasColumnName("UserTypeID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'-')");

                entity.Property(e => e.UserType1)
                    .HasMaxLength(20)
                    .HasColumnName("UserType")
                    .HasDefaultValueSql("(N'-')");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
