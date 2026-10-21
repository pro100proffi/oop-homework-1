namespace OopHomework1.Models;

public class UserProfile
{
    private readonly List<Contact> _contacts = [];

    public User User { get; }
    public IReadOnlyList<Contact> Contacts => _contacts.AsReadOnly();

    public UserProfile(User user)
    {
        User = user;
    }

    public void AddContact(Contact contact)
    {
        ArgumentNullException.ThrowIfNull(contact);
        _contacts.Add(contact);
    }

    public bool RemoveContact(Guid contactId)
    {
        Contact? contact = _contacts.FirstOrDefault(item => item.Id == contactId);
        return contact is not null && _contacts.Remove(contact);
    }

    public void Deconstruct(out string fullName, out string login, out int contactCount)
    {
        fullName = User.FullName;
        login = User.Login;
        contactCount = _contacts.Count;
    }
}
