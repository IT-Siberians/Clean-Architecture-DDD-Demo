namespace GradeBookMicroservice.Domain.Entities.Exceptions;

public class LessonNotVisitedException(Lesson lesson, Student student) : InvalidOperationException($"Student {student.Name} has not visited lesson {lesson.Id}")
{
    public Lesson Lesson => lesson;
    public Student Student => student;

}
