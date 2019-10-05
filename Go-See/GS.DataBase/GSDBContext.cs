using GS.DataBase.Configuration;
using GS.DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GS.DataBase
{
    public class GSDbContext : DbContext
    {

        public GSDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CityEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PlaceEntityConfiguration());
            modelBuilder.ApplyConfiguration(new TripEntityConfiguration());
            modelBuilder.ApplyConfiguration(new TripNodeEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        }

        public DbSet<City> Cities { get; set; }

        public DbSet<Place> Places { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Trip> Trips { get; set; }

        public DbSet<TripNode> TripNodes { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
