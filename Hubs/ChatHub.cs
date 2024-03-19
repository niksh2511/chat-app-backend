using API.Services;
using API.Services.Interface;
using Microsoft.AspNetCore.SignalR;

namespace API.Hubs
{
    public class ChatHub(IPresenceService presenceService) : Hub
    {
        private readonly IPresenceService _presenceService = presenceService;

        public override async Task OnConnectedAsync()
        {

            await Clients.All.SendAsync("onConnected", Context.ConnectionId);

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {

            await Clients.All.SendAsync("onDisconnected", Context.ConnectionId);

            await _presenceService.UserDisconnected(Context.ConnectionId);

            await base.OnDisconnectedAsync(exception);
        }
    }
}
