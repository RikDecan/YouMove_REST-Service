using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using GymDL.Models;
using Microsoft.EntityFrameworkCore;
using GymDL.Models;

namespace GymDL
{
    internal class GymDbContext : DbContext
    {
        public DbSet<Cyclingsession> Cyclingsessions { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Program> Programs { get; set; }
        public DbSet<ProgramMember> ProgramMembers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<RunningSessionDetail> RunningSessionDetails { get; set; }
        public DbSet<RunningSessionMain> RunningSessionMains { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Corrected connection string
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-8PQJLNFG\SQLEXPRESS;Database=GymTest;Integrated Security=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Example of Fluent API configuration for Member
            modelBuilder.Entity<Member>(memberBuilder =>
            {
                memberBuilder.HasKey(c => c.MemberId); // Primary key
                memberBuilder.Property(c => c.FirstName).IsRequired().HasMaxLength(250); // Example column configuration
                memberBuilder.Property(c => c.LastName).IsRequired().HasMaxLength(250);
            });

            // Configure other entities if necessary
        }
    }
}