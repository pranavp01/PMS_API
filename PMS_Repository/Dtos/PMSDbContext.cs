using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;


// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PMS_Repository.Dtos
{
    public partial class PMSDbContext : DbContext
    {
        public PMSDbContext()
        {
        }

        public PMSDbContext(DbContextOptions<PMSDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Allergies> Allergies { get; set; }
        public virtual DbSet<EmergencyContactInfo> EmergencyContactInfo { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<PatientAppoinment> PatientAppoinment { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<VitalSigns> VitalSigns { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder => { builder.AddConsole(); })).EnableSensitiveDataLogging().UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=PMSN;Integrated Security=True;Connect Timeout=30");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Allergies>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllergyClinicalInformation)
                    .HasColumnName("allergyClinicalInformation")
                    .HasMaxLength(270)
                    .IsUnicode(false);

                entity.Property(e => e.AllergyDescription)
                    .HasColumnName("allergyDescription")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.AllergyId)
                    .HasColumnName("allergyId")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AllergyName)
                    .HasColumnName("allergyName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AllergyType)
                    .HasColumnName("allergyType")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Patientid).HasColumnName("patientid");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Allergies)
                    .HasForeignKey(d => d.Patientid)
                    .HasConstraintName("FK__Allergies__patie__0E6E26BF");
            });

            modelBuilder.Entity<EmergencyContactInfo>(entity =>
            {
                entity.ToTable("emergencyContactInfo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Contactno)
                    .HasColumnName("contactno")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Firstname)
                    .HasColumnName("firstname")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Patientid).HasColumnName("patientid");

                entity.Property(e => e.Relationship)
                    .HasColumnName("relationship")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.EmergencyContactInfo)
                    .HasForeignKey(d => d.Patientid)
                    .HasConstraintName("FK__emergency__patie__0F624AF8");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Contactno)
                    .HasColumnName("contactno")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Dateofbirth)
                    .HasColumnName("dateofbirth")
                    .HasColumnType("datetime");

                entity.Property(e => e.Firstname)
                    .HasColumnName("firstname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HomeAddress)
                    .HasColumnName("homeAddress")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Languages)
                    .HasColumnName("languages")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Race)
                    .HasColumnName("race")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Patient)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Patient_User");
            });

            modelBuilder.Entity<PatientAppoinment>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.AppoinmentDate)
                    .HasColumnName("appoinment_date")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AppoinmentTime).HasColumnName("appoinment_time");

                entity.Property(e => e.AppoinmentType)
                    .HasColumnName("appoinment_type")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Contactno)
                    .HasColumnName("contactno")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Dateofbirth)
                    .HasColumnName("dateofbirth")
                    .HasColumnType("datetime");

                entity.Property(e => e.Firstname)
                    .HasColumnName("firstname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Patientid).HasColumnName("patientid");

                entity.Property(e => e.Physicianname)
                    .HasColumnName("physicianname")
                    .HasMaxLength(25)
                    .IsUnicode(false);

               
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Rolename)
                    .IsRequired()
                    .HasColumnName("rolename")
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Contactno)
                    .HasColumnName("contactno")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasColumnName("emailId")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("firstname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsBlocked).HasColumnName("isBlocked");

                entity.Property(e => e.IsFirstLogin).HasColumnName("isFirstLogin");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("lastname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Role).HasColumnName("role");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.RoleNavigation)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.Role)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Roles");
            });

            modelBuilder.Entity<VitalSigns>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BloodPressure)
                    .HasColumnName("bloodPressure")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.BodyTemperature)
                    .HasColumnName("bodyTemperature")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Height)
                    .HasColumnName("height")
                    .HasMaxLength(5);

                entity.Property(e => e.Patientid).HasColumnName("patientid");

                entity.Property(e => e.RespirationRate)
                    .HasColumnName("respirationRate")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Weight)
                    .HasColumnName("weight")
                    .HasMaxLength(5);

             
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
