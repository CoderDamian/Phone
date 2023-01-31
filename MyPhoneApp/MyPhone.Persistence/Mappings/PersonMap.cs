using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyPhone.Domain.Entities;

namespace MyPhone.Persistence.Mappings
{
    internal class PersonMap : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("PERSON", "CIA");

            builder.Property(p => p.ID)
                .HasColumnName("PERSONID");

            builder.Property(p => p.Name)
                .HasColumnName("NAME");

            builder.Property(p => p.DateOfBirth)
                .HasColumnName("DATEOFBIRTH");
        }
    }
}
