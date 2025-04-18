using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Raja.Domain.Entities;

namespace Raja.Infrastracture.EFCore.FluentConfig
{
    public class PersonelDetailFluentConfig : IEntityTypeConfiguration<PersonelDetail>
    {
        public void Configure(EntityTypeBuilder<PersonelDetail> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.MobileNumber).IsRequired().HasMaxLength(11);

            builder.HasOne(x => x.Personel)
                .WithMany(x => x.PersonelDetail)
                .HasForeignKey(x => x.PersonelId);
        }
    }
}
