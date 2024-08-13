using System;
using GradeBookMicroservice.Domain.Entities;
using GradeBookMicroservice.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace GradeBookMicroservice.Infrastructure.Repositories.Implementations.Ef;

public class EfStudentRepository(ApplicationDbContext context) : EfRepository<Student, Guid>(context)
{
    private readonly DbSet<Student> _students = context.Students;
    public override Task<Student?> GetByIdAsync(Guid id) => _students
                                                            .Include(s => s.Group)
                                                            .Include("_grades")
                                                            .Include("_lessons")
                                                            .FirstOrDefaultAsync(s => s.Id == id);

}
