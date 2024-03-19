using API.DTO;

namespace API.Services.Interface
{
    public interface IMessageService
    {
        Task<ApiResponse<MessageDTO>> SendMessageAsync(MessageDTO messageDTO);
    }
}
