using System.Security.Claims;

namespace JournalApi.Security
{
    //Сервес для работы с пользователями в контексте
    public interface ISecurityUserService
    {
        // добавления пользователя
        void AddUser(string login, string password, string role,IPasswordEncoder encoder);

        // метод, проверяющий что логин/пароль пользователя валидный
        bool IsUserValid(string login, string password, IPasswordEncoder encoder);

        // метод, создающий ClaimsPrincipal
        ClaimsPrincipal GetUserPrincipal(string login);

    }
}
