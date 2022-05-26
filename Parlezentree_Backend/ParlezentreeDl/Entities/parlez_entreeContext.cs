using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ParlezentreeDl.Entities
{
    public partial class parlez_entreeContext : DbContext
    {
        public parlez_entreeContext()
        {
        }

        public parlez_entreeContext(DbContextOptions<parlez_entreeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }  

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=tcp:htrevature4598.database.windows.net,1433;Initial Catalog=parlez_entree;User ID=harsh4598;Password=Nutanchetan007@;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.EmailId, "UQ__Users__7ED91ACEEDB0278D")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.ContactNo).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.EmailId).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.Property(e => e.UserPassword).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
