using API.Services;
using API.Services.Interface;

namespace API.Configure
{
    public static class ConfigureService
    {
        public static void Configure(this IServiceCollection services)
        {
            services.AddSignalR();

            services.AddScoped<IMessageService, MessageService>();

            services.AddSingleton<IPresenceService, PresenceService>(); 
        }
    }
}
