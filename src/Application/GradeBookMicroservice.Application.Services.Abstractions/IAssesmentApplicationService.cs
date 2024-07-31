using GradeBookMicroservice.Application.Models.Grade;
using GradeBookMicroservice.Application.Models.Teacher;

namespace GradeBookMicroservice.Application.Services.Abstractions;

public interface IAssesmentApplicationService
{
    Task<GradeModel?> GradeStudentAsync(GradeStudentModel gradeInfromation);

}
