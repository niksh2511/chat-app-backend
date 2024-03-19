using API.DTO;
using API.Services.Interface;

namespace API.Services
{
    public class PresenceService : IPresenceService
    {
        public Dictionary<string, string> UserOnlineList = new();
        public async Task UserConnected(UserOnlineDTO userOnlineDTO)
        {
            await Task.Run(() =>
            {
                lock (UserOnlineList)
                {
                    if(UserOnlineList.ContainsKey(userOnlineDTO.Usernmae))
                    {
                        UserOnlineList[userOnlineDTO.Usernmae] = userOnlineDTO.ConnectionId;
                    }else
                    {
                        UserOnlineList.Add(userOnlineDTO.Usernmae, userOnlineDTO.ConnectionId);
                    }
                }
            });
        }


        public async Task<IReadOnlyList<string>> GetUserList()
        {
            return await Task.Run(() =>
            {

                lock (UserOnlineList)
                {
                    return UserOnlineList.Select(x => x.Key).ToList();  
                }
            });
        }


        public async Task UserDisconnected(string connectionId)
        {
            await Task.Run(() =>
            {
                lock (UserOnlineList)
                {
                    var user = UserOnlineList.First(x => x.Value == connectionId);

                    if(user.Key != null)
                    {
                        UserOnlineList.Remove(user.Key);
                    }
                }
            });
        }

        public async Task<string?> GetConnectionId(string usernamne)
        {
            return await Task.Run(() =>
            {
                lock (UserOnlineList)
                {
                    if(UserOnlineList.ContainsKey(usernamne))
                    {
                        return UserOnlineList[usernamne];
                    }

                    return null;
                }
            });
        }
    }
}
