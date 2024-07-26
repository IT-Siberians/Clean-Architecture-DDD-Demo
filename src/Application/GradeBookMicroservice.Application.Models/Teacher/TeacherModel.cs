namespace GradeBookMicroservice.Application.Models;

public class TeacherModel : PersonModel
{
    public IEnumerable<LessonModel> Lessons {get; init;} = [];
    public IEnumerable<GradeModel> Grades {get; init;} = [];
    
}
