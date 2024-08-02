using GradebookMicroservice.Common.Enumes;
using GradeBookMicroservice.WebHost.Responses.Student;
using GradeBookMicroservice.WebHost.Responses.Teacher;

namespace GradeBookMicroservice.WebHost.Responses.Grade;

public class GradeResponse
{
    public required TeacherShortResponse Teacher {get; init;}
    public required StudentShortResponse Student {get; init;}
    public required LessonShortResponse Lesson {get; init;}
    public required DateTime GradedTime {get; init;}
    public string? Comment {get; init;}
    public Mark Mark {get; init;}

}
