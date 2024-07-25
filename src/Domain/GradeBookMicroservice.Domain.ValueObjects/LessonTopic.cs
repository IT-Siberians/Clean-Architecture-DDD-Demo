namespace GradeBookMicroservice.Domain.ValueObjects;

public class LessonTopic
{
    public string Topic {get;}
    public LessonTopic(string topic)
    {
        if(string.IsNullOrWhiteSpace(topic))
            throw new ArgumentNullException(nameof(topic));
        if(topic.Length>100)
            throw new ArgumentOutOfRangeException(nameof(topic), "Topic must have less than 100 symbols");
        if(topic.Any(c => !(char.IsLetter(c) || char.IsWhiteSpace(c))))
            throw new ArgumentException("Topic must contain only letters or whitespaces", nameof(topic));
        if(topic.Count(с => char.IsWhiteSpace(с)) > 10)
            throw new ArgumentException("Name must contain less than 10 words", nameof(topic));
        if(topic.Contains("  "))
            throw new ArgumentException("Topic must not contain double whitespaces", nameof(topic));
        Topic = topic;
    }

}
