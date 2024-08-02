using GradeBookMicroservice.Domain.Entities.Base;
using GradeBookMicroservice.Domain.Entities.Enumes;
using GradeBookMicroservice.Domain.Entities.Exceptions;
using GradeBookMicroservice.Domain.ValueObjects;

namespace GradeBookMicroservice.Domain.Entities;

public class Lesson : Entity<Guid>
{
    #region Private fields
    private Group _group;
    private Teacher _teacher;
    private string _description;
    private DateTime _classTime;
    private LessonTopic _topic;
    private LessonStatus _state;
    #endregion
    #region Public Readonly Properties
    public Group Group => _group;
    public Teacher Teacher => _teacher;
    public string Description => _description;
    public DateTime ClassTime => _classTime;
    public LessonTopic Topic => _topic;
    public LessonStatus State => _state;
    #endregion
    #region  Constructors
    public Lesson(Guid id, Group group, Teacher teacher, LessonTopic topic, string description, DateTime classTime, LessonStatus status) : base(id)
    {
        ValidateLessonSchedule(classTime);
        _group = group;
        _teacher = teacher;
        _description = description;
        _classTime = classTime;
        _topic = topic;
        _state = status;
        if(status==LessonStatus.New)
            teacher.ScheduleLesson(this);
    }
    public Lesson(Group group, Teacher teacher, string description, DateTime classTime, LessonTopic topic) : this(Guid.NewGuid(), group, teacher, topic, description, classTime, LessonStatus.New)
    {

    }

    #endregion
    #region Private methods
    private void ValidateLesson()
    {
        if (State == LessonStatus.Canselled)
            throw new LessonCanselledException(this);
        if (State == LessonStatus.Teached)
            throw new LessonAlreadyTeachedException(this);

    }
    private static void ValidateLessonSchedule(DateTime classTime)
    {
        if (classTime < DateTime.Today)
            throw new InvalidLessonScheduleTimeException(classTime);

    }
    #endregion
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
        ValidateLessonSchedule(time);
        _classTime = time;

    }


}
