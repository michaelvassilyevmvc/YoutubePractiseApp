namespace DataAccess
{
    public class Note
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
