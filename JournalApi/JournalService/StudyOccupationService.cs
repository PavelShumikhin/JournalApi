using JournalApi.Data;
using JournalApi.Model.Entitys.Journal;

namespace JournalApi.JournalService
{
    public class StudyOccupationService
    {
        // получение списка занятий из базы
        public List<StudyOccupation> GetStudyOccupationList()
        {
            using (var db = new JournalDbContext())
            {
                return db.StudyOccupations.ToList();
            }
        }

        // получение занятия по дате для определенной группы
        public StudyOccupation GetStudyOccupationById(int id)
        {
            using (var db = new JournalDbContext())
            {
                return db.StudyOccupations.FirstOrDefault(s => s.StudyGroupId == id);
            }
        }

        // создание нового занятия
        public StudyOccupation AddStudyOccupation(StudyOccupation studyOccupation)
        {
            using (var db = new JournalDbContext())
            {
                // Добавили группу в БД
                db.StudyOccupations.Add(studyOccupation);
                db.SaveChanges();
                return studyOccupation;  // вернули добавленный объект
            }
        }
    }
}
