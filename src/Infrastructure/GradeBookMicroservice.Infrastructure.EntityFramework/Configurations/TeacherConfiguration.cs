using GradeBookMicroservice.Domain.Entities;
using GradeBookMicroservice.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace GradeBookMicroservice.Infrastructure.EntityFramework.Configurations;

public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Teacher> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Name)
                .HasConversion(name => name.Name, name => new PersonName(name))
                .IsRequired()
                .HasMaxLength(50);
        builder.Ignore(x=> x.SchedulledLessons);
        builder.Ignore(x => x.TeachedLessons);
        
    }
}
