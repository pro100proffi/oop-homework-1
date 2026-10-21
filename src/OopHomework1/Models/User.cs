namespace OopHomework1.Models;

public class User
{
    public Guid Id { get; }
    public string FullName { get; set; }
    public string Login { get; set; }

    // Для учебного примера хранится только хэш, а не исходный пароль.
    public string PasswordHash { get; private set; }

    public User(Guid id, string fullName, string login, string passwordHash)
    {
        Id = id;
        FullName = fullName;
        Login = login;
        PasswordHash = passwordHash;
    }

    public void ChangePasswordHash(string passwordHash)
    {
        PasswordHash = passwordHash;
    }
}
