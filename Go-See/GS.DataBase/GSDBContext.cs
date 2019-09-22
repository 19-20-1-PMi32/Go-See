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

        DbSet<City> Cities { get; set; }

        DbSet<Place> Places { get; set; }

        DbSet<Review> Reviews { get; set; }

        DbSet<Trip> Trips { get; set; }

        DbSet<TripNode> TripNodes { get; set; }

        DbSet<User> Users { get; set; }
    }
}
