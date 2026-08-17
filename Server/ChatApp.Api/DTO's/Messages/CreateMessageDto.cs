namespace ChatApp.Api.DTOs.Messages
{
    public class CreateMessageDto
    {
        public int SenderId { get; set; }
        public string Text { get; set; } = string.Empty;
    }
}