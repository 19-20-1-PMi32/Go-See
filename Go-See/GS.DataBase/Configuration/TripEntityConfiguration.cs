﻿using GS.DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GS.DataBase.Configuration
{
    public class TripEntityConfiguration : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.Name)
                .IsRequired();

            builder
                .Property(x => x.UserId)
                .IsRequired();

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.Trips)
                .HasForeignKey(x => x.UserId);

            builder
                .HasMany(x => x.TripNodes)
                .WithOne(x => x.Trip)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
