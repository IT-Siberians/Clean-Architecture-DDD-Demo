namespace GradeBookMicroservice.Domain.Entities.Exceptions;

public class DoubleTeachedLessonException(Lesson lesson, Teacher teacher) : InvalidOperationException($"Teacher {teacher.Name} has been teached lesson {lesson.Id} yet")
{
    public Lesson Lesson => lesson;
    public Teacher Teacher => teacher;

}
