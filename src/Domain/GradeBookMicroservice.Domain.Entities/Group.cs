using System.Collections.Immutable;
using GradeBookMicroservice.Domain.Entities.Base;
using GradeBookMicroservice.Domain.Entities.Exceptions;
using GradeBookMicroservice.Domain.ValueObjects;

namespace GradeBookMicroservice.Domain.Entities;

public class Group : Entity<Guid>
{
    private readonly ICollection<Student> _students = [];
    public IReadOnlyCollection<Student> Students => [.. _students];
    public GroupName Name {get;}
    public string Description {get; }
    protected Group(Guid id, GroupName name, string description) : base(id)
    {
        Name = name;
        Description = description;

    }
    public Group(GroupName name, string description) : this(Guid.NewGuid(), name, description)
    {

    }
    public void AddStudent(Student student)
    {
        if (_students.Contains(student))
            throw new DoubleEnrollmentException(student, this);
        _students.Add(student);
    }

}
