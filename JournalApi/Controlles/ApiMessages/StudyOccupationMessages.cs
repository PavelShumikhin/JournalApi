using JournalApi.Model.Entitys.Journal;

namespace JournalApi.Controlles.ApiMessages
{
    public class StudyOccupationMessages
    {
        public record StudyOccupationList(List<StudyOccupation> StudyOccupations);
       // public record StudyOccupationData(DateTime);
    }
}
