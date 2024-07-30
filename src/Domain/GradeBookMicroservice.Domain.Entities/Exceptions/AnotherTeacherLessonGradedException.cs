namespace GradeBookMicroservice.Domain.Entities.Exceptions;

public class AnotherTeacherLessonGradedException(Lesson lesson, Teacher teacher) : InvalidOperationException($"Teacher {teacher.Name} has not teached lesson {lesson.Id}")
{
    public Lesson Lesson => lesson;
    public Teacher Teacher => teacher;

}
