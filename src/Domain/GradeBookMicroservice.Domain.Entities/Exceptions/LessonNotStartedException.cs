namespace GradeBookMicroservice.Domain.Entities.Exceptions;

public class LessonNotStartedException(Lesson lesson) : InvalidOperationException($"Lesson {lesson.Id} not started yet")
{
    public Lesson Lesson => lesson;

}
