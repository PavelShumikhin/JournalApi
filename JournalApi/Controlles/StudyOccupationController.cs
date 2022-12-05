using JournalApi.JournalService;
using JournalApi.Model.Entitys.Journal;
using Microsoft.AspNetCore.Authorization;
using static JournalApi.Controlles.ApiMessages.StudySubjectMessages;
using System.Data;
using static JournalApi.Controlles.ApiMessages.StudyOccupationMessages;
using static JournalApi.Controlles.ApiMessages.BaseApiMessages;

namespace JournalApi.Controlles
{
    public class StudyOccupationController
    {
        // объект сервиса работы с занятиями
        private StudyOccupationService studyOccupationService;
        // конструктор
        public StudyOccupationController(StudyOccupationService studyOccupationService)
        {
            this.studyOccupationService = studyOccupationService;
        }
        // обработчик получения списка всех занятий из базы
        public async Task GetStudyOccupationList(HttpContext context)
        {
            // 1. получить список всех групп
            List<StudyOccupation> studyOccupationsList = studyOccupationService.GetStudyOccupationList();
            // 2. записать в ответ
            await context.Response.WriteAsJsonAsync(new StudyOccupationList(studyOccupationsList));
        }
        //Обработчик получения занятия определенной группы и даты из базы
        
        public async Task GetStudyOccupationById(HttpContext context)
        {
            // 0. считали параметр в строке запроса
            int id = Convert.ToInt32(context.Request.Query["id"]);

            // 1. получить группу по id
            StudyOccupation studyOccupation = studyOccupationService.GetStudyOccupationById(id);

            // 2. вернуть ответ
            await context.Response.WriteAsJsonAsync(studyOccupation);
        }
        //Обработчик добавления предмета
        [Authorize(Roles = "admin")]
        public async Task AddStudyOccupation(HttpContext context)
        {
            try
            {
                // 1. извлечь данные для создания новой группы
                StudyOccupation studyOccupation = await context.Request.ReadFromJsonAsync<StudyOccupation>();
                // 2. добавить
                studyOccupation = studyOccupationService.AddStudyOccupation(studyOccupation);
                // 3. отправить ответ - добавленный объект
                await context.Response.WriteAsJsonAsync(studyOccupation);
            }
            catch (Exception ex)
            {

                context.Response.WriteAsJsonAsync(new StringMessage("Enter Format yyyy-MM-ddTHH:mm"));
            }

        }
    }
}
