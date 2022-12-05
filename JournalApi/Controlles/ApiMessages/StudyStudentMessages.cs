using JournalApi.Model.Entitys.Journal;

namespace JournalApi.Controlles.ApiMessages
{
    public class StudyStudentMessages
    {
        public record StudyStudentList(List<StudyStudent> StudyStudents);
    }
}
