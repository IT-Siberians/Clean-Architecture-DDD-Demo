using GradeBookMicroservice.Application.Models.Grade;

namespace GradeBookMicroservice.Application.Services.Abstractions;

public interface IGradesApplicationService
{
    Task<IEnumerable<GradeModel>> GetAllGradesAsync();
    Task<GradeModel?> GetGradeByIdAsync(Guid id);
    Task<GradeModel?> CreateGradeAsync(CreateGradeModel gradeInfo);
    Task UpdateGradeAsync(GradeModel grade);
    Task DeleteGradeAsync(Guid id);

}
