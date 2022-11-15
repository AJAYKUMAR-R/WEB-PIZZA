using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PizzaApp.RegisterModels
{
    public partial class PizzaAppContext : DbContext
    {
        public PizzaAppContext()
        {
        }

        public PizzaAppContext(DbContextOptions<PizzaAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PizzaInformation> PizzaInformations { get; set; } = null!;
        public virtual DbSet<RegisterTable> RegisterTables { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=PizzaApp;Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PizzaInformation>(entity =>
            {
                entity.HasKey(e => e.Pizzaid)
                    .HasName("PK__PizzaInf__4D4B948772672191");

                entity.ToTable("PizzaInformation");

                entity.HasIndex(e => e.Pizzaname, "UQ__PizzaInf__B1BB19D9599F883E")
                    .IsUnique();

                entity.Property(e => e.Pizzaid).HasColumnName("pizzaid");

                entity.Property(e => e.Pizzadescription)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("pizzadescription");

                entity.Property(e => e.Pizzaimg)
                    .IsUnicode(false)
                    .HasColumnName("pizzaimg");

                entity.Property(e => e.Pizzaname)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("pizzaname");

                entity.Property(e => e.Pizzaprice).HasColumnName("pizzaprice");
            });

            modelBuilder.Entity<RegisterTable>(entity =>
            {
                entity.HasKey(e => e.CustId)
                    .HasName("PK__Register__049E3AA98BC28DE5");

                entity.ToTable("RegisterTable");

                entity.Property(e => e.CustAddres).IsUnicode(false);

                entity.Property(e => e.CustName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Custmobile)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
