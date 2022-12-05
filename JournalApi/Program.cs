using JournalApi.Controlles;
using JournalApi.JournalService;
using JournalApi.Security;

var builder = WebApplication.CreateBuilder(args);
//1.Сервисы аунтефикации и авторизации
builder.Services.AddAuthentication("Cookies").AddCookie(async option =>
{
    option.LoginPath = "/login";                // обработчики установки логина
    option.AccessDeniedPath = "/access-denied"; // обработчик для запрета доступа
    option.LogoutPath = "/logout";               // обработчик для логаута
});
builder.Services.AddAuthorization();

//1.1 Добавим сервисы
builder.Services.AddSingleton<ISecurityUserService, DbSecurityUserService>();
builder.Services.AddSingleton<IPasswordEncoder, HMACSHA256Encoder>();
builder.Services.AddSingleton<StudyGroupService>();
builder.Services.AddSingleton<StudySubjectService>();
builder.Services.AddSingleton<StudyOccupationService>();
builder.Services.AddSingleton<StudyStudentService>();
builder.Services.AddSingleton<StudyGradeService>();

//2.Добавление контроллера
builder.Services.AddSingleton<MainController>();
builder.Services.AddSingleton<SecurityController>();
builder.Services.AddSingleton<StudyGroupController>();
builder.Services.AddSingleton<StudySubjectController>();
builder.Services.AddSingleton<StudyOccupationController>();
builder.Services.AddSingleton<StudyStudentController>();
builder.Services.AddSingleton<StudyGradeController>();

//3.
var app = builder.Build();

// 4.добавлем middleware для аутентификации и авторизации
app.UseAuthentication();
app.UseAuthorization();


app.MapGet("/ping", app.Services.GetService<MainController>().Ping);
app.MapGet("/user-ping", app.Services.GetService<MainController>().UserPing);
app.MapGet("/admin-ping", app.Services.GetService<MainController>().AdminPing);
// Обработчики аунтификации
app.MapGet("login" ,app.Services.GetService<SecurityController>().LoginGet);
app.MapPost("login", app.Services.GetService<SecurityController>().LoginPost);
app.Map("logout", app.Services.GetService<SecurityController>().Logout);
app.MapGet("access-denied", app.Services.GetService<SecurityController>().AccessDenied);

// обработчики учебных групп
app.MapGet("/study-groups", app.Services.GetRequiredService<StudyGroupController>().GetStudyGroupsList);
app.MapGet("/study-group", app.Services.GetRequiredService<StudyGroupController>().GetStudyGroupById);
app.MapPost("/add-study-group", app.Services.GetRequiredService<StudyGroupController>().AddStudyGroup);
//Обработчики предметов
app.MapGet("/study-subjects", app.Services.GetRequiredService<StudySubjectController>().GetStudySubjectsList);
app.MapPost("/study-subject", app.Services.GetRequiredService<StudySubjectController>().GetStudySubjectById);
app.MapPost("/add-study-subject", app.Services.GetRequiredService<StudySubjectController>().AddStudySubject);
//Обработчики занятий
app.MapGet("/study-occupations", app.Services.GetRequiredService<StudyOccupationController>().GetStudyOccupationList);
app.MapGet("/study-occupation-group", app.Services.GetRequiredService<StudyOccupationController>().GetStudyOccupationById);
app.MapPost("/add-study-occupation", app.Services.GetRequiredService<StudyOccupationController>().AddStudyOccupation);
//Обработчики студента
app.MapGet("/study-students", app.Services.GetRequiredService<StudyStudentController>().GetStudyStudentsList);
app.MapGet("/study-students-group", app.Services.GetRequiredService<StudyStudentController>().GetStudyStudentByGroup);
app.MapPost("/add-study-student", app.Services.GetRequiredService<StudyStudentController>().AddStudyStudent);
//Обработчик оценок
app.MapGet("/study-grades", app.Services.GetRequiredService<StudyGradeController>().GetStudyGradesList);
app.MapGet("/study-grades-student", app.Services.GetRequiredService<StudyGradeController>().GetStudyGradeStudentById);
app.MapGet("/study-grades-occupation", app.Services.GetRequiredService<StudyGradeController>().GetStudyGradeOccupationById);
app.MapPost("/add-study-grade", app.Services.GetRequiredService<StudyGradeController>().AddStudyGrade);
app.MapPost("/update-study-grade", app.Services.GetRequiredService<StudyGradeController>().UpdateStudyGrade);

app.MapPost("test", async (context) =>
{
    string login = context.Request.Form["login"];
    string password = context.Request.Form["password"];
    string group = context.Request.Form["group"];

    DbSecurityUserService service = new DbSecurityUserService();
    HMACSHA256Encoder encoder = new HMACSHA256Encoder();
    service.AddUser(login, password, group, encoder);

    await context.Response.WriteAsync("Test user added");

});

app.Run();
