using ChatApp.Api.Data;
using ChatApp.Api.DTOs.Conversations;
using ChatApp.Api.DTOs.Users;
using ChatApp.Api.Models;
using Microsoft.EntityFrameworkCore;
namespace ChatApp.Api.Services
{
    public class ConversationService(ChatAppDbContext context) : IConversationService
    {
        private readonly ChatAppDbContext _context = context;

        public async Task<List<Conversation>> GetAllConversations()
        {
            return await _context.Conversations
            .Include(c => c.Participants)
            .ToListAsync();
        }

        public async Task<ConversationDto?> GetConversationById(int id)
        {
            var conversation = await _context.Conversations
            .Include(c => c.Participants)
            .FirstOrDefaultAsync(c => c.Id == id);

            if (conversation == null)
            {
                return null;
            }
            var conversationDto = new ConversationDto
            {
                Id = conversation.Id,
                Participants = conversation.Participants.Select(p => new UserDto
                {
                    Id = p.Id,
                    UserName = p.UserName
                }).ToList()
            };
            return conversationDto;
        }

        public async Task<Conversation?> CreateConversation(CreateConversationDto dto)
        {
             var participants = await _context.Users
            .Where(u => dto.ParticipantIds.Contains(u.Id))
            .ToListAsync();
        
            if(participants.Count != dto.ParticipantIds.Count)
            {
                return null; // or throw an exception, depending on your error handling strategy
            }
            var conversation = new Conversation
            {
                Participants = participants
            };

            _context.Conversations.Add(conversation);

            await _context.SaveChangesAsync();

            return conversation;
        }
    }
}