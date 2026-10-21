namespace OopHomework1.Models;

public class Student
{
    private const string Unknown = "Unknown";
    private string? _name;
    private int _age;

    public Student() : this(Unknown, 0)
    {
    }

    public Student(string name, int age)
    {
        SetName(name);
        SetAge(age);
    }

    public string GetName() => string.IsNullOrWhiteSpace(_name) ? Unknown : _name;

    public int GetAge() => _age;

    public void SetName(string? name)
    {
        _name = string.IsNullOrWhiteSpace(name) ? Unknown : name.Trim();
    }

    public void SetAge(int age)
    {
        if (age < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(age), "Возраст не может быть отрицательным.");
        }

        _age = age;
    }
}
