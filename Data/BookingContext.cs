using System;
//using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata;
using BookingApi.Models;

namespace BookingApi.Data
{
    public partial class BookingContext : DbContext
    {
        public BookingContext()
        {
        }

        public BookingContext(DbContextOptions<BookingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BookedResourcesPerDate> BookedResourcesPerDates { get; set; } = null!;
        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<Resource> Resources { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookedResourcesPerDate>(entity =>
            {
                entity.ToTable("BookedResourcesPerDate");

                entity.Property(e => e.Id).HasColumnType("integer");

                entity.Property(e => e.Date).HasColumnType("DateTime");

                entity.Property(e => e.Quantity).HasColumnType("integer");

                entity.Property(e => e.ResourceId).HasColumnType("integer");
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");

                entity.Property(e => e.Id).HasColumnType("integer");

                entity.Property(e => e.BookedQuantity).HasColumnType("integer");

                entity.Property(e => e.DateFrom).HasColumnType("DateTime");

                entity.Property(e => e.DateTo).HasColumnType("DateTime");

                entity.Property(e => e.ResourceId).HasColumnType("integer");
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.HasIndex(e => e.Id, "IX_Resources_Id")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasColumnType("STRING");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
