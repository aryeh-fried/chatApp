namespace ChatApp.Api.DTOs.Messages
{
    public class MessageDto
    {
    public int Id { get; set; }

    public int SenderId { get; set; }

    public string Text { get; set; } = string.Empty;

    public DateTimeOffset SentAt { get; set; }

    public DateTimeOffset? EditedAt { get; set; }

    }
}