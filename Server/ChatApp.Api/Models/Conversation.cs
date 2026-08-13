namespace ChatApp.Api.Models;

public class Conversation
{
    public int Id { get; set; }

    public List<User> Participants { get; set; } = new();

    public List<Message> Messages { get; set; } = new();
}

