using JournalApi.Data;
using JournalApi.Model.Entitys.Journal;

namespace JournalApi.JournalService
{
    public class StudySubjectService
    {
        // получение списка учебных предмета из базы
        public List<StudySubject> GetStudySubjectsList()
        {
            using (var db = new JournalDbContext())
            {
                return db.StudySubjects.ToList();
            }
        }
        // получение предмета по id
        public StudySubject GetStudySubjectById(int id)
        {
            using (var db = new JournalDbContext())
            {
                return db.StudySubjects.FirstOrDefault(s=>s.Id == id);
            }
        }

        // создание нового предмета
        public StudySubject AddStudySubject(StudySubject studySubject)
        {
            using (var db = new JournalDbContext())
            {
                // Добавили предмет в БД
                db.StudySubjects.Add(studySubject);
                db.SaveChanges();
                return studySubject;  // вернули добавленный объект
            }
        }
    }
}
