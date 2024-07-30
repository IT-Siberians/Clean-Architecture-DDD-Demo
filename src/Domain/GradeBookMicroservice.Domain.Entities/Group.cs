using System.Collections.Immutable;
using GradeBookMicroservice.Domain.Entities.Base;
using GradeBookMicroservice.Domain.Entities.Exceptions;
using GradeBookMicroservice.Domain.ValueObjects;

namespace GradeBookMicroservice.Domain.Entities;

public class Group(Guid id, GroupName name, string description, IEnumerable<Student> students) : Entity<Guid>(id)
{
    private IEnumerable<Student> _students = students;
    private GroupName _name = name;
    private string _description = description;
    public IReadOnlyCollection<Student> Students => _students.ToImmutableList();
    public GroupName Name => _name;
    public string Description => _description;
    public Group(GroupName name, string description) : this(Guid.NewGuid(), name, description, [])
    {

    }
    public void AddStudent(Student student)
    {
        if (_students.Contains(student))
            throw new DoubleEnrollmentException(student, this);
        _students = _students.Append(student);
    }

}
