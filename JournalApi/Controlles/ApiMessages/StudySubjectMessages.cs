using JournalApi.Model.Entitys.Journal;

namespace JournalApi.Controlles.ApiMessages
{
    public class StudySubjectMessages
    {
        public record StudySubjectList (List<StudySubject> StudySubjects);
    }
}
