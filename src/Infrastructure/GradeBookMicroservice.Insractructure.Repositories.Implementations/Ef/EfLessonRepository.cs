using GradeBookMicroservice.Domain.Entities;
using GradeBookMicroservice.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace GradeBookMicroservice.Infrastructure.Repositories.Implementations.Ef;

public class EfLessonRepository(ApplicationDbContext context) : EfRepository<Lesson, Guid>(context)
{
    private readonly DbSet<Lesson> _lessons = context.Lessons;
    public override Task<Lesson?> GetByIdAsync(Guid id) => _lessons.Include(l => l.Group)     
                                                            .Include(l => l.Teacher)                          
                                                            .FirstOrDefaultAsync(l => l.Id == id);

}
