using System.Collections.Immutable;
using GradeBookMicroservice.Domain.Entities.Base;
using GradeBookMicroservice.Domain.Entities.Exceptions;
using GradeBookMicroservice.Domain.ValueObjects;

namespace GradeBookMicroservice.Domain.Entities;

public class Group(Guid id, GroupName name, string description, List<Student> students) : Entity<Guid>(id)
{
    private List<Student> _students = students;
    public IReadOnlyCollection<Student> Students => _students.AsReadOnly();
    public GroupName Name {get; protected set;} = name;
    public string Description {get; protected set;} = description;
    public Group(GroupName name, string description) : this(Guid.NewGuid(), name, description, [])
    {

    }
    public void AddStudent(Student student)
    {
        if (_students.Contains(student))
            throw new DoubleEnrollmentException(student, this);
        _students.Add(student);
    }

}
