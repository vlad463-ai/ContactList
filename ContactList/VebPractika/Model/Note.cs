using System.ComponentModel.DataAnnotations;

namespace ContactList.Model
{
    public class Note
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Текст заметки обязателен")]
        [StringLength(500, MinimumLength = 1, ErrorMessage = "Заметка должна быть от 1 до 500 символов")]
        [Display(Name = "Текст заметки")]
        public string Text { get; set; } = string.Empty;

        [Display(Name = "Дата создания")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Контакт обязателен")]
        [Display(Name = "Контакт")]
        public int ContactId { get; set; }

        public Contact? Contact { get; set; }
    }
}