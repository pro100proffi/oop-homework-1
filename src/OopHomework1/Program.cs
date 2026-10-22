using OopHomework1.Models;
using OopHomework1.Services;

Console.OutputEncoding = System.Text.Encoding.UTF8;

ShowUserProfile();

static void ShowUserProfile()
{
    Console.WriteLine("=== Профиль пользователя ===");

    UserProfileService service = new();
    UserProfile profile = service.CreateProfile(
        "Гаврилов Артем Алексеевич",
        "gavrilov.aa",
        "demo-password-hash");

    CommunicationChannel email = new(Guid.NewGuid(), "Электронная почта");
    CommunicationChannel messenger = new(Guid.NewGuid(), "Мессенджер");

    service.AddContact(profile, email, "artem.gavrilov@example.com");
    service.AddContact(profile, messenger, "@gavrilov_aa");
    service.RenameUser(profile, "Гаврилов Артем Алексеевич");

    Console.WriteLine(service.GetBriefStatistics(profile));
    foreach (Contact contact in profile.Contacts)
    {
        Console.WriteLine($"- {contact}");
    }
}
