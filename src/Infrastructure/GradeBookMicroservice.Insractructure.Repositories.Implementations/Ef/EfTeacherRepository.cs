using System;
using GradeBookMicroservice.Domain.Entities;
using GradeBookMicroservice.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace GradeBookMicroservice.Infrastructure.Repositories.Implementations.Ef;

public class EfTeacherRepository(ApplicationDbContext context) : EfRepository<Teacher, Guid>(context)
{
    private readonly DbSet<Teacher> _teachers = context.Set<Teacher>();
    public override Task<Teacher?> GetByIdAsync(Guid id) => _teachers.Include("_grades")
                                                            .Include("_lessons")
                                                            .FirstOrDefaultAsync(t => t.Id == id);

}
