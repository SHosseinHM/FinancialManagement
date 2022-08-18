using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.Entities
{
    public partial class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Diposite> Diposites { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Withdrow> Withdrows { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=FinancialManagmentDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Diposite>(entity =>
            {
                entity.HasKey(e => e.DipositId);

                entity.Property(e => e.DipositId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Diposites)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Diposites_Users");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(12);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(80);
            });

            modelBuilder.Entity<Withdrow>(entity =>
            {
                entity.Property(e => e.WithdrowId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Withdrows)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Withdrows_Users");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
