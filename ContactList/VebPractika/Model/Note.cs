namespace ContactList.Model
{
    public class Note : EFModel
    {
        public int ContactId { get; set; }
        public string? Text { get; set; }
    }
}
