using JournalApi.Controlles.ApiMessages;
using Microsoft.AspNetCore.Authorization;

namespace JournalApi.Controlles
{
    public class MainController
    {
        public async Task Ping(HttpContext context)
        {
            await context.Response.
                WriteAsJsonAsync(new BaseApiMessages.StringMessage("pong"));
        }
        [Authorize]
        public async Task UserPing(HttpContext context)
        {
            await context.Response.
                WriteAsJsonAsync(new BaseApiMessages.StringMessage("user pong"));
        }
        [Authorize(Roles ="admin")]
        public async Task AdminPing(HttpContext context)
        {
            await context.Response.
                WriteAsJsonAsync(new BaseApiMessages.StringMessage("admin pong"));
        }
    }
}
