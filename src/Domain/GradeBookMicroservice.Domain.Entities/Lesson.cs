using GradeBookMicroservice.Domain.Entities.Base;
using GradeBookMicroservice.Domain.Entities.Enumes;
using GradeBookMicroservice.Domain.Entities.Exceptions;
using GradeBookMicroservice.Domain.ValueObjects;

namespace GradeBookMicroservice.Domain.Entities;

public class Lesson : Entity<Guid>
{
    #region Public Readonly Properties
    public Group Group {get; }
    public Teacher Teacher {get; }
    public string Description {get; }
    public DateTime ClassTime {get; private set;}
    public LessonTopic Topic {get; }
    public LessonStatus State {get; private set;}
    #endregion
    #region  Constructors
    protected Lesson(Guid id, Group group, Teacher teacher, LessonTopic topic, string description, DateTime classTime, LessonStatus status) : base(id)
    {
        ValidateLessonSchedule(classTime);
        Group = group;
        Teacher = teacher;
        Description = description;
        ClassTime = classTime;
        Topic = topic;
        State= status;
        if(status==LessonStatus.New)
            teacher.ScheduleLesson(this);
    }
    public Lesson(Group group, Teacher teacher, string description, DateTime classTime, LessonTopic topic) : this(Guid.NewGuid(), group, teacher, topic, description, classTime, LessonStatus.New)
    {

    }
    protected Lesson() :base(Guid.NewGuid())
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
        State = LessonStatus.Teached;
    }
    internal void Cancel()
    {
        ValidateLesson();
        State = LessonStatus.Canselled;
    }
    internal void Reschedule(DateTime time)
    {
        ValidateLesson();
        ValidateLessonSchedule(time);
        ClassTime = time;

    }


}
