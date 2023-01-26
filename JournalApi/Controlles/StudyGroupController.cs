using JournalApi.JournalService;
using JournalApi.Model.Entitys.Journal;
using Microsoft.AspNetCore.Authorization;
using static JournalApi.Controlles.ApiMessages.StudyGroupMessages;
using System.Data;

namespace JournalApi.Controlles
{
    public class StudyGroupController
    {
        // объект сервиса работы с группами
        private StudyGroupService studyGroupService;

        // конструктор
        public StudyGroupController(StudyGroupService studyGroupService)
        {
            this.studyGroupService = studyGroupService;
        }

        // обработчик получения списка всех групп из базы
        public async Task GetStudyGroupsList(HttpContext context)
        {
            // 1. получить список всех групп
            List<StudyGroup> studyGroupsList = studyGroupService.GetStudyGroupsList();
            // 2. записать в ответ
            await context.Response.WriteAsJsonAsync(new StudyGroupList(studyGroupsList));
        }


        // получение группы по id (только для авторизованных пользователей)
        
        public async Task GetStudyGroupById(HttpContext context)
        {
            // 0. считали параметр в строке запроса
            int id = Convert.ToInt32(context.Request.Query["id"]);

            // 1. получить группу по id
            StudyGroup studyGroup = studyGroupService.GetStudyGroupById(id);

            // 2. вернуть ответ
            await context.Response.WriteAsJsonAsync(studyGroup);
        }

        // добавление новой группы (только для админов)
        [Authorize(Roles = "admin")]
        public async Task AddStudyGroup(HttpContext context)
        {
            // 1. извлечь данные для создания новой группы
            StudyGroup newStudyGroup = await context.Request.ReadFromJsonAsync<StudyGroup>();
            // 2. добавить
            newStudyGroup = studyGroupService.AddStudyGroup(newStudyGroup);
            // 3. отправить ответ - добавленный объект
            await context.Response.WriteAsJsonAsync(newStudyGroup);
        }
    }
}
