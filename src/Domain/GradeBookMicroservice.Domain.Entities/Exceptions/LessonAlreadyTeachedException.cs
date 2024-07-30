namespace GradeBookMicroservice.Domain.Entities.Exceptions;

public class LessonAlreadyTeachedException(Lesson lesson) : InvalidOperationException($"Lesson {lesson.Id} has been teached")
{
    public Lesson Lesson => lesson;

}
