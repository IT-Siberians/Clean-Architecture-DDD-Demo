using GradeBookMicroservice.Application.Models.Base;
using GradeBookMicroservice.Application.Models.Grade;
using GradeBookMicroservice.Application.Models.Lesson;

namespace GradeBookMicroservice.Application.Models.Teacher;

public class TeacherModel : PersonModel
{
    public required IEnumerable<LessonModel> TeachedLessons {get; init;}
    public required IEnumerable<LessonModel> SchedulledLessons {get; init;}
    public required IEnumerable<GradeModel> AssignedGrades {get; init;}
    
}
