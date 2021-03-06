using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using NswService.Domain;

namespace NswService.Domain.Models
{
    public partial class NSWContext : DbContext
    {
        public NSWContext()
        {
        }

        public NSWContext(DbContextOptions<NSWContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Registration> Registrations { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRegistration> UserRegistrations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Registration>(entity =>
            {
                entity.Property(e => e.Colour).HasMaxLength(50);

                entity.Property(e => e.ExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.GrossMass)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InsurerCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InsurerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Make)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Model)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PlateNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TareWeight).HasMaxLength(50);

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Vin)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserRegistration>(entity =>
            {
                entity.HasOne(d => d.Registration)
                    .WithMany(p => p.UserRegistrations)
                    .HasForeignKey(d => d.RegistrationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRegistrations_Registrations");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRegistrations)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRegistrations_Users");
            });

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Name 1", Address = "Address 1" },
                new User { Id = 2, Name = "Name 2", Address = "Address 2" },
                new User { Id = 3, Name = "Name 3", Address = "Address 3" }
            );

            modelBuilder.Entity<Registration>().HasData(
                new Registration { Id = 1, PlateNumber = "platenumber 1", Colour = "color 1", ExpiryDate = new DateTime(2030, 1, 1), GrossMass = "100", InsurerCode = "INS Code 1", InsurerName = "INS Name", Make = "Make 1", Model = "Model 1", TareWeight = "122", Type = "Type 1", Vin = "Vin 1" },
                new Registration { Id = 2, PlateNumber = "platenumber 2", Colour = "color 1", ExpiryDate = new DateTime(2030, 1, 1), GrossMass = "100", InsurerCode = "INS Code 1", InsurerName = "INS Name", Make = "Make 1", Model = "Model 1", TareWeight = "122", Type = "Type 1", Vin = "Vin 1" },
                new Registration { Id = 3, PlateNumber = "platenumber 3", Colour = "color 1", ExpiryDate = new DateTime(2030, 1, 1), GrossMass = "100", InsurerCode = "INS Code 1", InsurerName = "INS Name", Make = "Make 1", Model = "Model 1", TareWeight = "122", Type = "Type 1", Vin = "Vin 1" },
                new Registration { Id = 4, PlateNumber = "platenumber 4", Colour = "color 1", ExpiryDate = new DateTime(2030, 1, 1), GrossMass = "100", InsurerCode = "INS Code 1", InsurerName = "INS Name", Make = "Make 1", Model = "Model 1", TareWeight = "122", Type = "Type 1", Vin = "Vin 1" }
            );

            modelBuilder.Entity<UserRegistration>().HasData(
                new UserRegistration { Id = 1, UserId = 1, RegistrationId = 1 },
                new UserRegistration { Id = 2, UserId = 1, RegistrationId = 2 },
                new UserRegistration { Id = 3, UserId = 1, RegistrationId = 3 },
                new UserRegistration { Id = 4, UserId = 2, RegistrationId = 4 }
            );

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
