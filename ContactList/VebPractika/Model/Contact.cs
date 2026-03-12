namespace ContactList.Model
{
    public class Contact : EFModel
    {
        public string? Phone { get; set; }
        public string? email { get; set; }

        public string? FIO { get; set; }
    }
}
