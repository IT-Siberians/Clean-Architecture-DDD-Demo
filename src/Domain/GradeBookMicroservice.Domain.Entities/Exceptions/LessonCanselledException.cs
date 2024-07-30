namespace GradeBookMicroservice.Domain.Entities.Exceptions;

public class LessonCanselledException(Lesson lesson) : InvalidOperationException($"Lesson {lesson.Id} has been canselled yet")
{
    public Lesson Lesson => lesson;

}
