namespace GradeBookMicroservice.Domain.Entities.Exceptions;

public class AnotherStudentGradeException(Student student, Grade grade) : InvalidOperationException($"Grade {grade.Id} is not for studen {student.Name}")
{
    public Student Student => student;
    public Grade Grade => grade;

}
