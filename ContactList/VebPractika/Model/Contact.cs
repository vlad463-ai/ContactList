namespace ContactList.Model
{
    public class Contact : EFModel
    {
        public string? Phone { get; set; }
        public string? email { get; set; }
        public string? FIO { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
