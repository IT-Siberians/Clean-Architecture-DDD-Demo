using GradeBookMicroservice.Application.Models.Student;

namespace GradeBookMicroservice.Application.Services.Abstractions;

public interface IVisitingApplicationService
{
    Task<bool> VisitLessonAsync(VisitLessonModel visitInformation);

}
