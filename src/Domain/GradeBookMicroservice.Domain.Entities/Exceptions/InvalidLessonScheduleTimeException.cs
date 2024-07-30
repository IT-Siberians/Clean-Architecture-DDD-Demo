namespace GradeBookMicroservice.Domain.Entities.Exceptions;

public class InvalidLessonScheduleTimeException(DateTime time) : ArgumentException(nameof(time), "Lesson can not be reschedulled to past")
{
    public DateTime Time => time;

}
