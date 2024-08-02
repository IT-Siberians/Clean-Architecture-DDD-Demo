using GradeBookMicroservice.Domain.Entities;
using GradeBookMicroservice.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GradeBookMicroservice.Infrastructure.EntityFramework.Configurations;

public class GroupConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Name)
                .HasConversion(name => name.Name, name => new GroupName(name))
                .IsRequired()
                .HasMaxLength(10);
        builder.HasIndex(x => x.Name).IsUnique();
        builder.Property(x => x.Description).IsRequired();
    }
}
