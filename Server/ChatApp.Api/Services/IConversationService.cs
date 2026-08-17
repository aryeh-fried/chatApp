using ChatApp.Api.DTOs.Conversations;
using ChatApp.Api.Models;

public interface IConversationService
{
    Task<List<ConversationDto>> GetAllConversations();
    Task<ConversationDto?> GetConversationById(int id);
    Task<Conversation?> CreateConversation(CreateConversationDto conversation);
}