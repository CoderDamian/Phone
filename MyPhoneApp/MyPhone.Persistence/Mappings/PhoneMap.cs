using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyPhone.Domain.Entities;

namespace MyPhone.Persistence.Mappings
{
    internal class PhoneMap : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.ToTable("PHONE", "CIA");

            builder.Property(p => p.ID)
                .HasColumnName("PHONEID");

            builder.Property(p => p.Tipo)
                .HasColumnName("TIPO");

            builder.Property(p => p.Numero)
                .HasColumnName("NUMERO");

            builder.Property(p => p.PersonFK)
                .HasColumnName("PERSONFK");
        }
    }
}
