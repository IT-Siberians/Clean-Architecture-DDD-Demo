namespace GradeBookMicroservice.Domain.ValueObjects;

public class GroupName : IEquatable<GroupName>, IEquatable<string>
{
    public string Name { get; }
    public GroupName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException(nameof(name));
        if (name.Length > 10)
            throw new ArgumentOutOfRangeException(nameof(name), "Name must have less than 10 symbols");
        if (name.Any(c => !(c >= 'A' && c <= 'Z' || c >= 'a' && c <= 'z' || char.IsDigit(c) || c == '-')))
            throw new ArgumentException("Name must contain only letters or minus", nameof(name));
        if (name.Count(c => c == '-') != 2)
            throw new ArgumentException("Name must constains only 2 minus", nameof(name));
        if (name.Contains("--"))
            throw new ArgumentException("Name can't contain double minus", nameof(name));
        Name = name;
    }

    public bool Equals(GroupName? other) => other is not null && EqualityComparer<string>.Default.Equals(Name, other.Name);


    public bool Equals(string? other) => other is not null && EqualityComparer<string>.Default.Equals(Name, other);

    public override bool Equals(object? obj) => obj is GroupName other && EqualityComparer<string>.Default.Equals(Name, other.Name);

    public override int GetHashCode() => EqualityComparer<string>.Default.GetHashCode(Name);

    public override string ToString() => Name;
    public static bool operator ==(GroupName first, GroupName second)
    {
        if (ReferenceEquals(first, second))
            return true;
        return !first.Name.Equals(default) && first.Equals(second);
    }
    public static bool operator ==(string first, GroupName second) => !second.Name.Equals(default) && first.Equals(second.Name);
    public static bool operator ==(GroupName first, string second) => !first.Name.Equals(default) && !first.Name.Equals(second);

    public static bool operator !=(GroupName first, GroupName second) => !(first == second);
    public static bool operator !=(string first, GroupName second) => !(first == second);
    public static bool operator !=(GroupName first, string second) => !(first == second);
}
