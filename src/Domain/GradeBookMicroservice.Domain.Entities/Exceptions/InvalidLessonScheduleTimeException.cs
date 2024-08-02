namespace GradeBookMicroservice.Domain.Entities.Exceptions;

public class InvalidLessonScheduleTimeException(DateTime time) : ArgumentException("Lesson can not be reschedulled to past",nameof(time))
{
    public DateTime Time => time;

}
