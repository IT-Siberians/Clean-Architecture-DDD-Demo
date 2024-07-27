using GradeBookMicroservice.Application.Models.Grade;
using GradeBookMicroservice.Application.Models.Lesson;

namespace GradeBookMicroservice.Application.Models.Teacher;

public class TeacherModel : PersonModel
{
    public IEnumerable<LessonModel> Lessons {get; init;} = [];
    public IEnumerable<GradeModel> Grades {get; init;} = [];
    
}
