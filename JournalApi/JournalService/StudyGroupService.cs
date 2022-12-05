using JournalApi.Data;
using JournalApi.Model.Entitys.Journal;


namespace JournalApi.JournalService
{
    public class StudyGroupService
    {
        // получение списка учебных групп из базы
        public List<StudyGroup> GetStudyGroupsList()
        {
            using (var db = new JournalDbContext())
            {
                return db.StudyGroups.ToList();
            }
        }

        // получение группы по id
        public StudyGroup GetStudyGroupById(int id)
        {
            using (var db = new JournalDbContext())
            {
                return db.StudyGroups.FirstOrDefault(studyGroup => studyGroup.Id == id);
            }
        }


        // создание новой группы
        public StudyGroup AddStudyGroup(StudyGroup studyGroup)
        {
            using (var db = new JournalDbContext())
            {
                // Добавили оценку в БД
                db.StudyGroups.Add(studyGroup);
                db.SaveChanges();
                return studyGroup;  // вернули добавленный объект
            }
        }
    }
}
