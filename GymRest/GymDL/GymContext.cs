using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymDL.Models;
using Microsoft.EntityFrameworkCore;

namespace GymDL
{
    public class GymContext : DbContext
    {
        public DbSet<CyclingSessionEF> Cyclingsessions { get; set; }
        public DbSet<EquipmentEF> Equipment { get; set; }
        public DbSet<MemberEF> Members { get; set; }
        public DbSet<ProgramEF> Programs { get; set; }
        public DbSet<ReservationEF> Reservations { get; set; }
        public DbSet<RunningSessionDetailEF> RunningSessionDetails { get; set; }
        public DbSet<RunningSessionMainEF> runningSessionMains { get; set; }
        public DbSet<TimeSlotEF> timeSlots { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-8PQJLNFG\SQLEXPRESS;Initial Catalog=GymTest;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}
