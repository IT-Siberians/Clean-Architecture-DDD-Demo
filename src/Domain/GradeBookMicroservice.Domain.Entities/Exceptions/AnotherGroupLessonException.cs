namespace GradeBookMicroservice.Domain.Entities.Exceptions;

public class AnotherGroupLessonException(Student student, Group group) : InvalidOperationException($"Student {student.Name} can not visit lesson of {group.Name} lesson")
{
    public Student Student => student;
    public Group Group => group;

}
