namespace JournalApi.Model.Entitys.Access
{
    public class UsersGroup
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public ICollection<User> Users { get; set; }

    }
}
