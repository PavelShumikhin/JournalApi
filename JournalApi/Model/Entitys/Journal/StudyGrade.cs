namespace JournalApi.Model.Entitys.Journal
{
    public class StudyGrade
    {
        public int Id { get; set; }
        public int Grade { get; set; }
        public int StudyStudentId { get; set; }
        public int StudyOccupationId {get; set;}
    }
}
