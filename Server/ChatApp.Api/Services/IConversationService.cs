using ChatApp.Api.Models;

public interface IConversationService
{
    Task<List<Conversation>> GetAllConversations();
    Task<Conversation?> GetConversationById(int id);
    Task<Conversation?> CreateConversation(CreateConversationDto conversation);
}