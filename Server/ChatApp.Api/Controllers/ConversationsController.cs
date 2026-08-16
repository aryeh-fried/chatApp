using ChatApp.Api.Models;
using ChatApp.Api.DTOs.Users;
using Microsoft.AspNetCore.Mvc;
using ChatApp.Api.Services;

namespace ChatApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConversationsController(IConversationService conversationService) : ControllerBase
{
    private readonly IConversationService _conversationService = conversationService;

    [HttpGet]
    public async Task<ActionResult<List<Conversation>>> GetAllConversations()
    {
        var conversations = await _conversationService.GetAllConversations();
        return Ok(conversations);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Conversation?>> GetConversationById(int id)
    {
        var conversation = await _conversationService.GetConversationById(id);
        if (conversation == null)
        {
            return NotFound();
        }
        return Ok(conversation);
    }

    [HttpPost]
    public async Task<ActionResult<Conversation>> CreateConversation(CreateConversationDto dto)
    {
        var conversation = await _conversationService.CreateConversation(dto);
        return CreatedAtAction(nameof(GetConversationById), new { id = conversation.Id }, conversation);
    }
}
