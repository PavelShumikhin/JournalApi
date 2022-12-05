namespace JournalApi.Model.Entitys.Journal
{
    public class StudyGroup
    {
        public int Id { get; set; }         // идентфикатор
        public string Name { get; set; }    // имя группы

        public override string ToString()
        {
            return $"{Id} - {Name}";
        }
    }
}
