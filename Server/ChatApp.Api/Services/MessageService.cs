using ChatApp.Api.Data;
using ChatApp.Api.DTOs.Messages;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Api.Services
{
    public class MessageSerice:IMessageService
    {
        private readonly ChatAppDbContext _dbContextxt;

        public MessageSerice(ChatAppDbContext dbContext)
        {
            _dbContextxt = dbContext;
        }

        public Task<MessageDto> CreateMessage(int conversationId, CreateMessageDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MessageDto>> GetMessages(int conversationId)
        {
            return await _dbContextxt.Messages
            .Where(m=>m.ConversationId == conversationId)
            .OrderBy(m=>m.SentAt)
            .Select(m =>new MessageDto
                {
                     Id = m.Id,
                    SenderId = m.SenderId,
                    Text = m.Text,
                    SentAt = m.SentAt,
                    EditedAt = m.EditedAt
                }
            ).ToListAsync();
        }
    }
    
}