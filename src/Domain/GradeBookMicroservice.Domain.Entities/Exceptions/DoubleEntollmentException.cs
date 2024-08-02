namespace GradeBookMicroservice.Domain.Entities.Exceptions;

internal class DoubleEnrollmentException(Student student, Group group): InvalidOperationException($"{student.Name} has been enrolled yo group {group.Name} yet")
{
    public Student Student => student;
    public Group Group => group;
}