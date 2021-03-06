﻿using GS.DataBase.Configuration;
using GS.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace GS.DataBase
{
    public class GSDbContext : DbContext
    {
        public GSDbContext(DbContextOptions<GSDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CityEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PlaceEntityConfiguration());
            modelBuilder.ApplyConfiguration(new TripEntityConfiguration());
            modelBuilder.ApplyConfiguration(new TripNodeEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());

            //Uncomment when it is needed to fill db with fake data
            //modelBuilder.Entity<City>().HasData(SeedDataProvider.GetCities());
            //modelBuilder.Entity<Place>().HasData(SeedDataProvider.GetPlace());
            //modelBuilder.Entity<Review>().HasData(SeedDataProvider.GetReviews());
            //modelBuilder.Entity<Trip>().HasData(SeedDataProvider.GetTrips());
            //modelBuilder.Entity<TripNode>().HasData(SeedDataProvider.GetTripNodes());
            //modelBuilder.Entity<User>().HasData(SeedDataProvider.GetUsers());
        }

        public DbSet<City> Cities { get; set; }

        public DbSet<Place> Places { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Trip> Trips { get; set; }

        public DbSet<TripNode> TripNodes { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
