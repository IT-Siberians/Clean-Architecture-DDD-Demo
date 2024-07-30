using GradeBookMicroservice.Application.Models.Grade;
using GradeBookMicroservice.Application.Models.Lesson;

namespace GradeBookMicroservice.Application.Models.Teacher;

public class TeacherModel : PersonModel
{
    public IEnumerable<LessonModel> TeachedLessons {get; init;} = [];
    public IEnumerable<LessonModel> SchedulledLessons {get; init;} = [];
    public IEnumerable<GradeModel> Grades {get; init;} = [];
    
}
