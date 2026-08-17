using ChatApp.Api.DTOs.Messages;
using ChatApp.Api.Models;

namespace ChatApp.Api.Services
{
    public interface IMessageService
    {
       Task<List<MessageDto>> GetMessages(int conversationId);
       Task <MessageDto> CreateMessage(int conversationId,CreateMessageDto dto);

    }
}