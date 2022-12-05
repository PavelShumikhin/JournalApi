using JournalApi.Data;
using JournalApi.Model.Entitys.Journal;
using System.Linq;

namespace JournalApi.JournalService
{
    public class StudyStudentService
    {
        // получение списка студентов из базы
        public List<StudyStudent> GetStudyStudentsList()
        {
            using (var db = new JournalDbContext())
            {
                return db.StudyStudents.ToList();
            }
        }

        // получение студента по группе
        public List <StudyStudent> GetStudyStudentByGroup(int groupId)
        {
            using (var db = new JournalDbContext())
            {
                return db.StudyStudents.Where(s => s.StudyGroupId == groupId).ToList();
            }
        }


        // создание новго студента
        public StudyStudent AddStudyStudent(StudyStudent studyStudent)
        {
            using (var db = new JournalDbContext())
            {
                // Добавили группу в БД
                db.StudyStudents.Add(studyStudent);
                db.SaveChanges();
                return studyStudent;  // вернули добавленный объект
            }
        }
    }
}
