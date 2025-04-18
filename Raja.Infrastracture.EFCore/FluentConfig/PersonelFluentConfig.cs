using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Raja.Domain.Entities;

namespace Raja.Infrastracture.EFCore.FluentConfig
{
    public class PersonelFluentConfig : IEntityTypeConfiguration<Personel>
    {
        public void Configure(EntityTypeBuilder<Personel> builder)
        {

            builder.HasKey(x=> x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(256);

            builder.Property(x => x.LastName).IsRequired().HasMaxLength(256);

            builder.HasMany(x=> x.PersonelDetail)
                .WithOne(x => x.Personel)
                .HasForeignKey(x=>x.PersonelId);
        }
    }
}
