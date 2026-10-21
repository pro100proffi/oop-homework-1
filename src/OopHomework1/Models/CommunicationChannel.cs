namespace OopHomework1.Models;

public class CommunicationChannel
{
    public Guid Id { get; }
    public string Name { get; set; }

    public CommunicationChannel(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}
