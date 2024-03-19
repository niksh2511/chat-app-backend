using API.DTO;
using API.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class MessageController(IMessageService messageService): BaseApiController
    {
        private readonly IMessageService _messageService = messageService;

        [HttpPost]
        public async Task<ActionResult> SendMessageAsync([FromBody]MessageDTO messageDTO)
        {
            ApiResponse<MessageDTO> response =
                await _messageService.SendMessageAsync(messageDTO);

            return StatusCode(response.StatusCode, response);
        }
    }
}