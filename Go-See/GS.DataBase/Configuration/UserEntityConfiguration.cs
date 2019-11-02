using GS.DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GS.DataBase.Configuration
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id);

            builder
                .Property(x => x.Login)
                .HasMaxLength(128);

            builder
                .Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(128);

            builder
                .Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(128);

            builder
                .Property(x => x.PasswordHash)
                .IsRequired();

            builder
                .Property(x => x.Email)
                .HasMaxLength(256);

            builder
                .Property(x => x.Phone)
                .HasMaxLength(25);

            builder
                .HasMany(x => x.Reviews)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.Cascade);

            builder
               .HasMany(x => x.Trips)
               .WithOne(x => x.User)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
