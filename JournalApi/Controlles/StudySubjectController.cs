using JournalApi.JournalService;
using JournalApi.Model.Entitys.Journal;
using Microsoft.AspNetCore.Authorization;
using static JournalApi.Controlles.ApiMessages.StudyGroupMessages;
using static JournalApi.Controlles.ApiMessages.StudySubjectMessages;

namespace JournalApi.Controlles
{
    public class StudySubjectController
    {
        // объект сервиса работы с предметами
        private StudySubjectService studySubjectService;
        // конструктор
        public StudySubjectController(StudySubjectService studySubjectService)
        {
            this.studySubjectService = studySubjectService;
        }
        // обработчик получения списка всех предметов из базы
      
        public async Task GetStudySubjectsList(HttpContext context)
        {
            // 1. получить список всех групп
            List<StudySubject> studySubjectsList = studySubjectService.GetStudySubjectsList();
            // 2. записать в ответ
            await context.Response.WriteAsJsonAsync(new StudySubjectList(studySubjectsList));
        }
        //Обработчик получения предмат по ID из базы
        public async Task GetStudySubjectById(HttpContext context)
        {
            // 0. считали параметр в строке запроса
            int id = Convert.ToInt32(context.Request.Query["id"]);
            // 1. получить группу по id
            StudySubject studySubject= studySubjectService.GetStudySubjectById(id);
            // 2. вернуть ответ
            await context.Response.WriteAsJsonAsync(studySubject);
        }
        //Обработчик добавления предмета
        [Authorize(Roles = "admin")]
        public async Task AddStudySubject(HttpContext context)
        {
            // 1. извлечь данные для создания новой группы
            StudySubject studySubject = await context.Request.ReadFromJsonAsync<StudySubject>();
            // 2. добавить
            studySubject=studySubjectService.AddStudySubject(studySubject);
            // 3. отправить ответ - добавленный объект
            await context.Response.WriteAsJsonAsync(studySubject);
        }
    }
}
