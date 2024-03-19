using API.DTO;
using API.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UserOnline(IPresenceService presenceService): BaseApiController
    {
        private readonly IPresenceService _presenceService = presenceService;

        [HttpPost]
        public async Task<ActionResult> UserOnlineRegister([FromBody]UserOnlineDTO userOnlineDTO)
        {
            await _presenceService.UserConnected(userOnlineDTO);

            return StatusCode(204);
        }

        [HttpGet]
        public async Task<ActionResult> GetOnlineUserList()
        {
            IReadOnlyList<string> usernameList =  await _presenceService.GetUserList();

            ApiResponse<IReadOnlyList<string>> response = new()
            {
                Data = usernameList
            };

            return StatusCode(200, response);
        }
    }
}
