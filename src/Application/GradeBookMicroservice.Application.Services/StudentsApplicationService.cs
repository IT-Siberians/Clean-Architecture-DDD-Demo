using AutoMapper;
using GradeBookMicroservice.Application.Models.Student;
using GradeBookMicroservice.Application.Services.Abstractions;
using GradeBookMicroservice.Domain.Entities;
using GradeBookMicroservice.Domain.Repositories.Abstractions;
using GradeBookMicroservice.Domain.ValueObjects;

namespace GradeBookMicroservice.Application.Services;

public class StudentsApplicationService(IRepository<Student, Guid> studentRepository, IGroupsRepository groupRepository, IMapper mapper) : IStudentsApplicationService
{
    
    public async Task<StudentModel?> AddStudentAsync(CreateStudentModel studentInfo)
    {
        var group = await groupRepository.GetByIdAsync(studentInfo.GroupId);
        if(group == null)
            return null;
        var student = new Student(new PersonName(studentInfo.Name), group);
        student= await studentRepository.AddAsync(student);
        if(student==null)
            return null;
        return mapper.Map<StudentModel>(student);
    }

    public async Task DeleteStudent(Guid id)
    {
        var student = await studentRepository.GetByIdAsync(id);
        if(student==null)
            return;
        await studentRepository.DeleteAsync(student);
    }

    public async Task<IEnumerable<StudentModel>> GetAllStudentsAsync() 
            => (await studentRepository.GetAllAsync()).Select(mapper.Map<StudentModel>);


    public async Task<StudentModel?> GetStudentByIdAsync(Guid id)
    {
        var student = await studentRepository.GetByIdAsync(id);
        if(student==null)
            return null;
        return mapper.Map<StudentModel>(student);
    }

    public async Task UpdateStudent(StudentModel student)
    {
        if(await studentRepository.GetByIdAsync(student.Id)==null)
            return;
        var entity = mapper.Map<Student>(student);
        await studentRepository.UpdateAsync(entity);

    }
}
