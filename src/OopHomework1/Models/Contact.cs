namespace OopHomework1.Models;

public class Contact
{
    public Guid Id { get; }
    public CommunicationChannel Channel { get; }
    public string Identifier { get; set; }

    public Contact(Guid id, CommunicationChannel channel, string identifier)
    {
        Id = id;
        Channel = channel;
        Identifier = identifier;
    }

    public override string ToString() => $"{Channel.Name}: {Identifier}";
}
