using Microsoft.EntityFrameworkCore;
using RaceTrack.Models;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace RaceTrack
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<VehiclesOnTrack> VehiclesOnTrack { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle[]
                {
                new Vehicle { Id=1, Name="Truck"},
                new Vehicle { Id=2, Name="Car"},            
                });
        }        
    }
   
}
