using GS.DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GS.DataBase.Configuration
{
    public class PlaceEntityConfiguration : IEntityTypeConfiguration<Place>
    {
        public void Configure(EntityTypeBuilder<Place> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id);

            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder
                .Property(x => x.Description)
                .HasMaxLength(1024);

            builder
                .HasOne(x => x.City)
                .WithMany(x => x.Places)
                .HasForeignKey(x => x.CityId);
        }
    }
}
