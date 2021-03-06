﻿using GS.DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GS.DataBase.Configuration
{
    public class ReviewEntityConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id);

            builder
                .Property(x => x.UserId)
                .IsRequired();

            builder
                .Property(x => x.PlaceId)
                .IsRequired();

            builder
                .HasOne(x => x.Place)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x => x.PlaceId);

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x => x.UserId);

            builder
                .Property(x => x.Text)
                .HasMaxLength(512);

        }
    }
}
