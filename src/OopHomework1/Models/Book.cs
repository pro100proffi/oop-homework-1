namespace OopHomework1.Models;

/// <summary>
/// Книга из заданий 1 и 2.
/// </summary>
public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }
    public bool IsRead { get; set; }

    public Book(string title, string author, int year)
    {
        Title = title;
        Author = author;
        Year = year;
    }

    public Book(string title) : this(title, "неизвестен", 0)
    {
    }

    public void Deconstruct(out string title, out bool isRead)
    {
        title = Title;
        isRead = IsRead;
    }

    public override string ToString()
    {
        string yearText = Year == 0 ? "год не указан" : Year.ToString();
        return $"«{Title}», {Author}, {yearText}; прочитана: {(IsRead ? "да" : "нет")}";
    }
}
