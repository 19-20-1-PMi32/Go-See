using GS.DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GS.DataBase.Configuration
{
    public class CityEntityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
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
                .HasMany(x => x.Places)
                .WithOne(x => x.City)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
