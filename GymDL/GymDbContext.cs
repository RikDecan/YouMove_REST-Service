using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using GymDL.Models;
using Microsoft.EntityFrameworkCore;
using YouMove_RikDecan.Models;

namespace GymDL
{
    internal class GymDbContext : DbContext
    {

        public DbSet<Cyclingsession> Cyclingsessions { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Program>  Programs{ get; set; }
        public DbSet<ProgramMember>  ProgramMembers{ get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<RunningSessionDetail> RunningSessionDetails { get; set; }
        public DbSet<RunningSessionMain> RunningSessionMains { get; set; }
        public DbSet<TimeSlot> TimeSlot { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Server=LAPTOP-8PQJLNFG\\SQLEXPRESS;Database=[GymTest]; Initial Catalog=Races;Integrated Security=True;TrustServerCertificate=Truee");
    }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Member>(memberBuilder =>
            {
                memberBuilder.HasKey(c => c.MemberId);




            });
        }
    }
}
