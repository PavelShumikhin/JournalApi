namespace JournalApi.Model.Entitys.Access
{
    public class User
    {
        public int Id { get;set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int UsersGroupId { get; set; }
        public UsersGroup? UsersGroup { get; set; }
    }
}
