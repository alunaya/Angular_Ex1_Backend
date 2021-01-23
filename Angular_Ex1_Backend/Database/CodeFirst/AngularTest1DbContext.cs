using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular_Ex1_Backend.Database.CodeFirst
{
    public class AngularTest1DbContext: DbContext
    {
        public DbSet<ServicesBill> ServicesBill { get; set; }
        public DbSet<ReservationCoverage> ReservationCoverages { get; set; }
        public DbSet<Months> Months { get; set; }
        public AngularTest1DbContext(DbContextOptions<AngularTest1DbContext> dbContextOptions): 
            base(dbContextOptions)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

    }
}
