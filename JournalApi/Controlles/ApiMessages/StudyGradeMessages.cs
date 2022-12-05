using JournalApi.Model.Entitys.Journal;

namespace JournalApi.Controlles.ApiMessages
{
    public class StudyGradeMessages
    {
        public record StudyGradeList(List<StudyGrade> StudyGrades);
    }
}
