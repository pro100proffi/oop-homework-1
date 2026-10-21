namespace OopHomework1.Models;

/// <summary>
/// Хранилище одной книги. Если владелец определён, доступ есть только у него.
/// </summary>
public class StudentBookStorage
{
    private readonly Student? _storageOwner;
    private Book? _storedBook;

    public StudentBookStorage(Student? owner, Book? book)
    {
        _storageOwner = owner;
        _storedBook = book;
    }

    public StudentBookStorage(Student owner) : this(owner, null)
    {
    }

    public StudentBookStorage() : this(null, null)
    {
    }

    public Book? GetABook(Student? student)
    {
        if (!IsValidAccess(student))
        {
            return null;
        }

        Book? book = _storedBook;
        _storedBook = null;
        return book;
    }

    /// <summary>
    /// Размещает определённую книгу в свободном хранилище при наличии доступа.
    /// </summary>
    public bool PutABook(Student? student, Book? book)
    {
        if (!IsValidAccess(student) || book is null || _storedBook is not null)
        {
            return false;
        }

        _storedBook = book;
        return true;
    }

    private bool IsValidAccess(Student? student)
    {
        return student is not null &&
               (_storageOwner is null ||
                string.Equals(student.GetName(), _storageOwner.GetName(), StringComparison.Ordinal));
    }
}
