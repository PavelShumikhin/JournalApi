namespace JournalApi.Security
{
    public interface IPasswordEncoder
    {
        public string Encode(string value);
    }
}
