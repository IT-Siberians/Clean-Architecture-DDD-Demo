using GradeBookMicroservice.Application.Models;
using GradeBookMicroservice.Application.Models.Create;

namespace GradeBookMicroservice.Application.Services.Base;

public interface IGradesApplicationService
{
    Task<IEnumerable<GradeModel>> GetAllGradesAsync();
    Task<GradeModel?> GetGradeByIdAsync(Guid id);
    Task<GradeModel?> CreateGradeAsync(CreateGradeModel gradeInfo);
    Task UpdateGradeAsync(GradeModel grade);
    Task DeleteGradeAsync(Guid id);

}
