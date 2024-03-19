using API.DTO;

namespace API.Services.Interface
{
    public interface IPresenceService
    {
        Task UserConnected(UserOnlineDTO userOnlineDTO);
        Task<IReadOnlyList<string>> GetUserList();
        Task UserDisconnected(string connectionId);
        Task<string?> GetConnectionId(string usernamne);
    }
}
