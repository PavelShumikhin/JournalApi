namespace JournalApi.Controlles.ApiMessages
{
    public class BaseApiMessages
    {
        public record StringMessage(string message);
        public record LoginData(string Login,string password);
    }
}
