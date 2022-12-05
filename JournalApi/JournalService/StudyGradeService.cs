using JournalApi.Data;
using JournalApi.Model.Entitys.Journal;

namespace JournalApi.JournalService
{
    public class StudyGradeService
    {
        // получение всех оценок
        public List<StudyGrade> GetStudyGradesList()
        {
            using (var db = new JournalDbContext())
            {
                return db.StudyGrades.ToList();
            }
        }
        // получение оценки студента по id
        public StudyGrade GetStudyGradesStudent(int id)
        {
            using (var db = new JournalDbContext())
            {
                return db.StudyGrades.FirstOrDefault(n => n.StudyStudentId == id);
            }
        }
        // получение оценки за занятие по id
        public StudyGrade GetStudyGradesOccupation(int id)
        {
            using (var db = new JournalDbContext())
            {
                return db.StudyGrades.FirstOrDefault(n => n.StudyOccupationId == id);
            }
        }

        // создание новой оценки
        public StudyGrade AddStudyGrade(StudyGrade studyGrade)
        {
            using (var db = new JournalDbContext())
            {
                // Добавили оценку в БД
                db.StudyGrades.Add(studyGrade);
                db.SaveChanges();
                return studyGrade;  // вернули добавленный объект
            }
        }
        // изменение оценки
        public StudyGrade UpdateStudyGradeById(int id, int grade)
        {
            using (var db = new JournalDbContext())
            {
                StudyGrade updateStudyGrade = db.StudyGrades.FirstOrDefault(n => n.StudyOccupationId == id);
                updateStudyGrade.Grade=grade;
                return updateStudyGrade;
            }
        }
    }
}
