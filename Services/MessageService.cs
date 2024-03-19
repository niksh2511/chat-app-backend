using API.DTO;
using API.Hubs;
using API.Services.Interface;
using Microsoft.AspNetCore.SignalR;

namespace API.Services
{
    public class MessageService(IHubContext<ChatHub> chatHub, IPresenceService presenceService) : IMessageService
    {
        private readonly IHubContext<ChatHub> _chatHub = chatHub;
        private readonly IPresenceService _presenceService = presenceService;

        public async Task<ApiResponse<MessageDTO>> SendMessageAsync(MessageDTO messageDTO)
        {
            ApiResponse<MessageDTO> response = new()
            {
                Data = messageDTO
            };

            // Find the ConnectionId of particular user
            List<string> connectionIds = [];
            string? fromConnectionId = await _presenceService.GetConnectionId(messageDTO.From);
            if(fromConnectionId != null) connectionIds.Add(fromConnectionId);

            string? toConnectionId = await _presenceService.GetConnectionId(messageDTO.To);
            if(toConnectionId != null) connectionIds.Add(toConnectionId);  

            await _chatHub.Clients.Clients(connectionIds).SendAsync("sendMessage", messageDTO);

            return response;
        }
    }
}
