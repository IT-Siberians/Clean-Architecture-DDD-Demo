namespace GradeBookMicroservice.Domain.ValueObjects;

public class GroupName
{
    public string Name {get;}
    public GroupName(string name)
    {
        if(string.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException(nameof(name));
        if(name.Length>10)
            throw new ArgumentOutOfRangeException(nameof(name), "Name must have less than 10 symbols");
        if(name.Any(c => !(c >='A' && c<='Z' ||  c>='a' && c<='z' || char.IsDigit(c) || c=='-')))
            throw new ArgumentException("Name must contain only letters or minus", nameof(name));
        if(name.Count(c => c=='-')!=3)
            throw new ArgumentException("Name must constains only 3 minus", nameof(name));
        if(name.Contains("--"))
            throw new ArgumentException("Name can't contain double minus", nameof(name));
        Name = name;
    }


}
