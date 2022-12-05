using JournalApi.Controlles.ApiMessages;
using JournalApi.Security;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using static JournalApi.Controlles.ApiMessages.BaseApiMessages;

namespace JournalApi.Controlles
{
    public class SecurityController
    {
        private ISecurityUserService userService;  // сервис для работы с пользователями
        private IPasswordEncoder passwordEncoder;   // кодировщик паролей
        // конструктор
        public SecurityController(ISecurityUserService securityUserService,
            IPasswordEncoder passwordEncoder)
        {
            this.userService = securityUserService;
            this.passwordEncoder = passwordEncoder;
        }
        public async Task LoginGet(HttpContext context)
        {
            await context.Response.WriteAsJsonAsync(new StringMessage("You need to authorize "));
        }
        public async Task LoginPost(HttpContext context)
        {
            try
            {
                // 1. считать данные пользователя из запроса
                LoginData userData = await context.Request.ReadFromJsonAsync<LoginData>();
                // 2. проверим userData
                if (userService.IsUserValid(userData.Login, userData.password, passwordEncoder))
                {
                    // пользователь валидный
                    // то авторизуем его
                    ClaimsPrincipal userPrincipal = userService.GetUserPrincipal(userData.Login);
                    await context.SignInAsync("Cookies",userPrincipal);
                    // сказать что авторизован
                    await context.Response.WriteAsJsonAsync(
                        new StringMessage($"Authorized: {userData.Login}"));
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                // если что-то с логином не так - то доступ запрещен
                context.Response.Redirect("/access-denied");
            }

        }
        public async Task AccessDenied(HttpContext context)
        {
            context.Response.StatusCode = 403;
            await context.Response.WriteAsJsonAsync(new StringMessage("Access denied"));
        }
        public async Task Logout(HttpContext context)
        {
            await context.SignOutAsync("Cookies");
            await context.Response.WriteAsJsonAsync(new StringMessage("You has been logout"));
        }
    }
}
