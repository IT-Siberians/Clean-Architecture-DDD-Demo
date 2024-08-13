using GradeBookMicroservice.Domain.Entities;
using GradeBookMicroservice.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GradeBookMicroservice.Infrastructure.EntityFramework.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Name)
                .HasConversion(name => name.Name, name => new PersonName(name))
                .IsRequired()
                .HasMaxLength(50);
        builder.HasOne(x => x.Group).WithMany(x => x.Students);
        builder.Navigation(x => x.Group).AutoInclude();
        builder.HasMany("_lessons").WithMany();
        builder.Ignore(x => x.AttendedLessons);
        builder.Ignore(x => x.RecievedGrades);

    }
}
