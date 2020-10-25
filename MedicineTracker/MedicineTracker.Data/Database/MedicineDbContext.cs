using MedicineTracker.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicineTracker.Data.Database
{
    public partial class MedicineDbContext : DbContext
    {
        public MedicineDbContext()
        {
            var medicines = new[]
            {
                new Medicine
                {
                    FullName ="Crocin",
                    BrandName = "ABC",
                    ExpiryDate = DateTime.Now,
                    Price = 50.2535,
                    Quantity = 35,
                    Notes = "NA"
                },
                new Medicine
                {
                    FullName ="Crocin2",
                    BrandName = "ABC2",
                    ExpiryDate = DateTime.Now,
                    Price = 50.25,
                    Quantity = 35,
                    Notes = "NA"
                },
                new Medicine
                {
                    FullName ="Crocin3",
                    BrandName = "ABC3",
                    ExpiryDate = DateTime.Now,
                    Price = 50.25,
                    Quantity = 35,
                    Notes = "NA"
                }
            };

            Medicines.AddRange(medicines);
            SaveChanges();
        }
        public virtual DbSet<Medicine> Medicines { get; set; }
        public MedicineDbContext(DbContextOptions<MedicineDbContext> options)
            : base(options)
        {
            var medicines = new[]
            {
                new Medicine
                {
                    FullName ="Crocin",
                    BrandName = "ABC",
                    ExpiryDate = DateTime.Now,
                    Price = 50.2535,
                    Quantity = 35,
                    Notes = "NA"
                },
                new Medicine
                {
                    FullName ="Crocin2",
                    BrandName = "ABC2",
                    ExpiryDate = DateTime.Now,
                    Price = 50.25,
                    Quantity = 35,
                    Notes = "NA"
                },
                new Medicine
                {
                    FullName ="Crocin3",
                    BrandName = "ABC3",
                    ExpiryDate = DateTime.Now,
                    Price = 50.25,
                    Quantity = 35,
                    Notes = "NA"
                }
            };

            Medicines.AddRange(medicines);
            SaveChanges();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medicine>(entity =>
            {
                entity.HasKey(e => e.FullName);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

