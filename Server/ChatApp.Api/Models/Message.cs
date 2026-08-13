namespace ChatApp.Api.Models;

public class Message
{
    public int Id { get; set; }

    public int ConversationId { get; set; }

    public int SenderId { get; set; }

    public string Text { get; set; } = string.Empty;

    public DateTimeOffset SentAt { get; set; }

    public bool IsEdited { get; set; }

    public Conversation Conversation { get; set; } = null!;
}