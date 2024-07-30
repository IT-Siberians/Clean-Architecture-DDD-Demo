using GradeBookMicroservice.Domain.Entities.Base;
using GradeBookMicroservice.Domain.Entities.Exceptions;
using GradeBookMicroservice.Domain.ValueObjects;

namespace GradeBookMicroservice.Domain.Entities;

public class Lesson(Group group, Teacher teacher, LessonTopic topic, string desctiption, DateTime classTime, LessonStatus status) : Entity<Guid>(Guid.NewGuid())
{
    private Group _group = group;
    private Teacher _teacher = teacher;
    private string _description = desctiption;
    private DateTime _classTime = classTime;
    private LessonTopic _topic = topic;
    private LessonStatus _state = status;
    public Group Group => _group;
    public Teacher Teacher => _teacher;
    public string Description => _description;
    public DateTime ClassTime => _classTime;
    public LessonTopic Topic => _topic;
    public LessonStatus State => _state;
    public Lesson(Group group, Teacher teacher, string description, DateTime classTime, LessonTopic topic) : this(group, teacher, topic, description, classTime, LessonStatus.New)
    {

    }
    private void ValidateLesson()
    {
        if (State == LessonStatus.Canselled)
            throw new LessonCanselledException(this);
        if (State == LessonStatus.Teached)
            throw new LessonAlreadyTeachedException(this);

    }
    internal void Teach()
    {
        ValidateLesson();
        _state = LessonStatus.Teached;
    }
    internal void Cancel()
    {
        ValidateLesson();
        _state = LessonStatus.Canselled;
    }
    internal void Reschedule(DateTime time)
    {
        ValidateLesson();
        if (time < DateTime.Today)
            throw new InvalidLessonRescheduleTime(time);
        _classTime = time;

    }


}
