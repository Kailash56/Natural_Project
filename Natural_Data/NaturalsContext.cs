using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Natural_Core.Models;

#nullable disable

namespace Natural_Core
{
    public partial class NaturalsContext : DbContext
    {
        public NaturalsContext()
        {
        }

        public NaturalsContext(DbContextOptions<NaturalsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Distributor> Distributors { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<State> States { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.Entity<Area>(entity =>
            {
                entity.ToTable("areas");

                entity.HasIndex(e => e.CityId, "City_Id");

                entity.Property(e => e.Id).HasMaxLength(20);

                entity.Property(e => e.AreaName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Area_Name");

                entity.Property(e => e.CityId)
                    .HasMaxLength(20)
                    .HasColumnName("City_Id");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Areas)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("areas_ibfk_1");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("cities");

                entity.HasIndex(e => e.StateId, "State_Id");

                entity.Property(e => e.Id).HasMaxLength(20);

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("City_Name");

                entity.Property(e => e.StateId)
                    .HasMaxLength(20)
                    .HasColumnName("State_Id");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("cities_ibfk_1");
            });

            modelBuilder.Entity<Distributor>(entity =>
            {
                entity.ToTable("distributor");

                entity.HasIndex(e => e.AreaId, "AreaId");

                entity.HasIndex(e => e.CityId, "CityId");

                entity.HasIndex(e => e.StateId, "StateId");

                entity.Property(e => e.Id).HasMaxLength(100).ValueGeneratedOnAdd();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.AreaId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CityId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MobileNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.StateId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.Distributors)
                    .HasForeignKey(d => d.AreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("distributor_ibfk_1");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Distributors)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("distributor_ibfk_2");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Distributors)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("distributor_ibfk_3");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("login");

                entity.Property(e => e.Id).HasMaxLength(100);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(100);
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.ToTable("states");

                entity.Property(e => e.Id).HasMaxLength(20);

                entity.Property(e => e.StateName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("State_Name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
