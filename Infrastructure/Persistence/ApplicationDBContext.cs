using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class ApplicationDBContext : DbContext, IApplicationDBContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                // Configure the table name if needed
                entity.ToTable("User");

                // Configure the primary key
                entity.HasKey(e => e.Id);

                // Configure properties
                entity.Property(e => e.IC)
                    .IsRequired()
                    .HasMaxLength(50); 

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PIN)
                    .HasMaxLength(6);

                entity.Property(e => e.Mobile)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.EmailDigits)
                   .HasMaxLength(6);

                entity.Property(e => e.MobileDigits)
                   .HasMaxLength(6);

                // Additional configurations can be added here
            });

            // Other model configurations
        }

        public DbSet<User> Users {  get; set; }
    }
}
