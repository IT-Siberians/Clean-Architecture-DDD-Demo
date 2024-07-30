namespace GradeBookMicroservice.Domain.Entities.Exceptions;

public class DoubleGradeStudentLesson(Lesson lesson, Student student) : InvalidOperationException($"Student {student.Name} has been graded for lsson {lesson.Id} yet")
{
    public Lesson Lesson => lesson;
    public Student Student => student;

}
