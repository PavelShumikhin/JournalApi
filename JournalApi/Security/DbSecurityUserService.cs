using JournalApi.Data;
using JournalApi.Model.Entitys.Access;
using System.Security.Claims;

namespace JournalApi.Security
{
    public class DbSecurityUserService : ISecurityUserService
    {
        public void AddUser(string login, string password, string role, IPasswordEncoder encoder)
        {
            using(var db =new JournalDbContext())
            {
                //1.Ищем группу по имени
                UsersGroup group=db.UsersGroups.FirstOrDefault(obj=>obj.GroupName== role);
                //2 Ckplfnm юзера
                User user=new User() {Login=login,Password=encoder.Encode(password),UsersGroup=group };
                // 3. сохранить
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public ClaimsPrincipal GetUserPrincipal(string login)
        {
            using (var db = new JournalDbContext())
            {
                User user = db.Users.FirstOrDefault(obj => obj.Login == login);
                UsersGroup group = db.UsersGroups.FirstOrDefault(obj => obj.Id == user.UsersGroupId);
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, login),
                    new Claim(ClaimTypes.Role, group.GroupName)
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
                return new ClaimsPrincipal(claimsIdentity);
            }

        }

        public bool IsUserValid(string login, string password, IPasswordEncoder encoder)
        {
            using (var db =new JournalDbContext())
            {
                User user=db.Users.First(obj=>obj.Login==login);
                return user != null && user.Password == encoder.Encode(password);
            }
        }
    }
}
