using Microsoft.EntityFrameworkCore;
using Bpassignment.Models; // Use your actual namespace

namespace Bpassignment.Data // Use your actual namespace
{
    public class BpMeasurementContext : DbContext
    {
        public BpMeasurementContext(DbContextOptions<BpMeasurementContext> options)
            : base(options)
        {
        }

        // Define the DbSets for BPMeasurement and Position
        public DbSet<BPMeasurement> BPMeasurement { get; set; }
        public DbSet<Position> Positions { get; set; }  // Add this line for Positions

        // Optional: Seed initial data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for positions
            modelBuilder.Entity<Position>().HasData(
                new Position { Id = "1", Name = "Sitting" },
                new Position { Id = "2", Name = "Standing" },
                new Position { Id = "3", Name = "Lying Down" }
            );
        }
    }
}