using JournalApi.Model.Entitys.Access;

namespace JournalApi.Model.Entitys.Journal
{
    public class StudyStudent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string SecondName { get; set; }
        public int StudyGroupId { get; set; }
        public StudyGroup? StudyGroup { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }


    }
}
