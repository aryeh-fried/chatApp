using ChatApp.Api.Data;
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

        public async Task<Conversation?> GetConversationById(int id)
        {
            return await _context.Conversations
            .Include(c => c.Participants)
            .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Conversation> CreateConversation(CreateConversationDto dto)
        {
             var participants = await _context.Users
            .Where(u => dto.ParticipantIds.Contains(u.Id))
            .ToListAsync();

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