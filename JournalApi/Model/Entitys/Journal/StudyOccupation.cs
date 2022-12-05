using JournalApi.Model.Entitys.Access;

namespace JournalApi.Model.Entitys.Journal
{
    public class StudyOccupation
    {
        public int Id { get; set; }
        public DateTime TimeOccupation { get; set; }
        public int StudyGroupId { get; set; }
        public StudyGroup? StudyGroup { get; set; }
        public int StudySubjectId { get; set; }
        public StudySubject? StudySubject { get; set; }

    }
}
