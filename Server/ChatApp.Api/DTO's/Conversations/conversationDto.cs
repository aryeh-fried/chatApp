using ChatApp.Api.DTOs.Users;


namespace ChatApp.Api.DTOs.Conversations
{
    public class ConversationDto
    {
        public int Id { get; set; } 
        public List<UserDto> Participants { get; set; } = new List<UserDto>();
    }
}