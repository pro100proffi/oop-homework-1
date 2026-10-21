using OopHomework1.Models;

namespace OopHomework1.Services;

public class UserProfileService
{
    private readonly Dictionary<Guid, UserProfile> _profiles = [];

    public UserProfile CreateProfile(string fullName, string login, string passwordHash)
    {
        if (string.IsNullOrWhiteSpace(fullName) ||
            string.IsNullOrWhiteSpace(login) ||
            string.IsNullOrWhiteSpace(passwordHash))
        {
            throw new ArgumentException("ФИО, логин и хэш пароля должны быть заполнены.");
        }

        if (_profiles.Values.Any(profile =>
                string.Equals(profile.User.Login, login, StringComparison.OrdinalIgnoreCase)))
        {
            throw new InvalidOperationException("Профиль с таким логином уже существует.");
        }

        User user = new(Guid.NewGuid(), fullName.Trim(), login.Trim(), passwordHash);
        UserProfile profile = new(user);
        _profiles.Add(user.Id, profile);
        return profile;
    }

    public void AddContact(UserProfile profile, CommunicationChannel channel, string identifier)
    {
        ArgumentNullException.ThrowIfNull(profile);
        ArgumentNullException.ThrowIfNull(channel);

        if (string.IsNullOrWhiteSpace(identifier))
        {
            throw new ArgumentException("Идентификатор контакта должен быть заполнен.", nameof(identifier));
        }

        profile.AddContact(new Contact(Guid.NewGuid(), channel, identifier.Trim()));
    }

    public void RenameUser(UserProfile profile, string newFullName)
    {
        ArgumentNullException.ThrowIfNull(profile);
        if (string.IsNullOrWhiteSpace(newFullName))
        {
            throw new ArgumentException("Новое ФИО должно быть заполнено.", nameof(newFullName));
        }

        profile.User.FullName = newFullName.Trim();
    }

    public string GetBriefStatistics(UserProfile profile)
    {
        ArgumentNullException.ThrowIfNull(profile);
        (string fullName, string login, int contactCount) = profile;
        return $"Пользователь: {fullName}; логин: {login}; контактов: {contactCount}.";
    }
}
