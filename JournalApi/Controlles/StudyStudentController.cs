using JournalApi.JournalService;
using JournalApi.Model.Entitys.Journal;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using static JournalApi.Controlles.ApiMessages.StudyStudentMessages;

namespace JournalApi.Controlles
{
    public class StudyStudentController
    {
        // объект сервиса работы со студентами
        private StudyStudentService studyStudentService;

        // конструктор
        public StudyStudentController(StudyStudentService studyStudentService)
        {
            this.studyStudentService = studyStudentService;
        }

        // обработчик получения списка всех студентов из базы
        
        public async Task GetStudyStudentsList(HttpContext context)
        {
            // 1. получить список всех студентов
            List<StudyStudent> studyStudentList = studyStudentService.GetStudyStudentsList();
            // 2. записать в ответ
            await context.Response.WriteAsJsonAsync(new StudyStudentList(studyStudentList));
        }


        // получение группы по id (только для авторизованных пользователей)
        
        public async Task GetStudyStudentByGroup(HttpContext context)
        {
            // 0. считали параметр в строке запроса
            int groupId = Convert.ToInt32(context.Request.Query["group"]);

            // 1. получить студента по id
            List <StudyStudent> studyStudents = studyStudentService.GetStudyStudentByGroup(groupId);

            // 2. вернуть ответ
            await context.Response.WriteAsJsonAsync(studyStudents);
        }

        // добавление новой группы (только для админов)
        [Authorize(Roles = "admin")]
        public async Task AddStudyStudent(HttpContext context)
        {
            // 1. извлечь данные для создания новой группы
            StudyStudent newStudyStudent = await context.Request.ReadFromJsonAsync<StudyStudent>();
            // 2. добавить
            newStudyStudent = studyStudentService.AddStudyStudent(newStudyStudent);
            // 3. отправить ответ - добавленный объект
            await context.Response.WriteAsJsonAsync(newStudyStudent);
        }
    }
}
