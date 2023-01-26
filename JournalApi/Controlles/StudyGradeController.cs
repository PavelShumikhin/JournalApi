using JournalApi.JournalService;
using JournalApi.Model.Entitys.Journal;
using Microsoft.AspNetCore.Authorization;
using static JournalApi.Controlles.ApiMessages.StudyGradeMessages;

namespace JournalApi.Controlles
{
    public class StudyGradeController
    {
        // объект сервиса работы с группами
        private StudyGradeService studyGradeService;

        // конструктор
        public StudyGradeController(StudyGradeService studyGradeService)
        {
            this.studyGradeService = studyGradeService;
        }

        // обработчик получения списка всех оценок из базы
        [Authorize (Roles ="student,teacher")]
        public async Task GetStudyGradesList(HttpContext context)
        {
            // 1. получить список всех групп
            List<StudyGrade> studyGradesList = studyGradeService.GetStudyGradesList();
            // 2. записать в ответ
            await context.Response.WriteAsJsonAsync(new StudyGradeList(studyGradesList));
        }
        // получение оценки по id (только для авторизованных пользователей)
        [Authorize (Roles= "student,teacher")]
        public async Task GetStudyGradeStudentById(HttpContext context)
        {
            // 0. считали параметр в строке запроса
            int id = Convert.ToInt32(context.Request.Query["id"]);

            // 1. получить группу по id
            StudyGrade studyGrade = studyGradeService.GetStudyGradesStudent(id);

            // 2. вернуть ответ
            await context.Response.WriteAsJsonAsync(studyGrade);
        }
        //Получение оценки за занятие по id
        [Authorize(Roles = "student,teacher")]
        public async Task GetStudyGradeOccupationById(HttpContext context)
        {
            // 0. считали параметр в строке запроса
            int id = Convert.ToInt32(context.Request.Query["id"]);

            // 1. получить группу по id
            StudyGrade studyGrade = studyGradeService.GetStudyGradesOccupation(id);

            // 2. вернуть ответ
            await context.Response.WriteAsJsonAsync(studyGrade);
        }

        // добавление новой оценки (только для преподавателей)
        [Authorize (Roles="teacher")]
        public async Task AddStudyGrade(HttpContext context)
        {
            // 1. извлечь данные для создания новой оценки
            StudyGrade newStudyGrade = await context.Request.ReadFromJsonAsync<StudyGrade>();
            // 2. добавить
            newStudyGrade = studyGradeService.AddStudyGrade(newStudyGrade);
            // 3. отправить ответ - добавленный объект
            await context.Response.WriteAsJsonAsync(newStudyGrade);
        }
        //Изменение оценки
        [Authorize(Roles = "teacher")]
        public async Task UpdateStudyGrade(HttpContext context)
        {
            // 1. извлечь данные для изменения оценки
            int id = Convert.ToInt32(context.Request.Query["id"]);
            int grade = Convert.ToInt32(context.Request.Form["grade"]);
            // 2. добавить
            StudyGrade updateStudyGrade = studyGradeService.UpdateStudyGradeById(id,grade);
            // 3. отправить ответ - добавленный объект
            await context.Response.WriteAsJsonAsync(updateStudyGrade);
        }
    }
}
