using JournalApi.Model.Entitys.Journal;

namespace JournalApi.Controlles.ApiMessages
{
    public class StudyGroupMessages
    {
        public record StudyGroupList(List<StudyGroup> StudyGroups);
    }
}
