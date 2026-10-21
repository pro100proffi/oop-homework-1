using OopHomework1.Models;
using OopHomework1.Services;

Console.OutputEncoding = System.Text.Encoding.UTF8;

ShowTask1();
ShowTask2();
ShowTask3();

static void ShowTask1()
{
    Console.WriteLine("=== Задание 1: класс Book ===");

    Book mainConstructorBook = new("Чистый код", "Роберт Мартин", 2008)
    {
        IsRead = true
    };

    Book shortConstructorBook = new("Книга с неизвестным автором");

    Book initializedBook = new("Совершенный код", "Стив Макконнелл", 2004)
    {
        IsRead = false
    };

    (string title, bool isRead) = mainConstructorBook;
    Console.WriteLine(mainConstructorBook);
    Console.WriteLine(shortConstructorBook);
    Console.WriteLine(initializedBook);
    Console.WriteLine($"Распаковка: «{title}», прочитана: {(isRead ? "да" : "нет")}.");
}

static void ShowTask2()
{
    Console.WriteLine("\n=== Задание 2: хранилище книг ===");

    Student owner = new("Артем", 20);
    Student stranger = new("Иван", 21);
    Book book = new("Объектно-ориентированное программирование", "Учебный автор", 2026);
    StudentBookStorage storage = new(owner);

    Console.WriteLine($"Владелец размещает книгу: {storage.PutABook(owner, book)}");
    Console.WriteLine($"Другой студент извлекает книгу: {storage.GetABook(stranger) is not null}");
    Book? extractedBook = storage.GetABook(owner);
    Console.WriteLine($"Владелец извлекает книгу: {extractedBook is not null}");
    Console.WriteLine($"Размещение null: {storage.PutABook(owner, null)}");
}

static void ShowTask3()
{
    Console.WriteLine("\n=== Задание 3: профиль пользователя ===");

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
