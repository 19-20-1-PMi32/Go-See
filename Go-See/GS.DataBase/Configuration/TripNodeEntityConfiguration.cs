using GS.DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GS.DataBase.Configuration
{
    public class TripNodeEntityConfiguration : IEntityTypeConfiguration<TripNode>
    {
        public void Configure(EntityTypeBuilder<TripNode> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.TripId)
                .IsRequired();

            builder
                .Property(x => x.PlaceId)
                .IsRequired();

            builder
                .Property(x => x.SequenceNumber)
                .IsRequired();
        }
    }
}
