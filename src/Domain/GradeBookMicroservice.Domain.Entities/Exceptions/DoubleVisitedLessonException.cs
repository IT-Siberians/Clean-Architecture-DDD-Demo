namespace GradeBookMicroservice.Domain.Entities.Exceptions;

public class DoubleVisitedLessonException(Lesson lesson, Student student) : InvalidOperationException($"Lesson {lesson.Id} has been visited by student ${student.Name} yet")
{
    public Lesson Lesson => lesson;
    public Student Student => student;

}
