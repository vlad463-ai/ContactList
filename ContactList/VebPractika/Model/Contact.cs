using System.ComponentModel.DataAnnotations;

namespace ContactList.Model
{
    public class Contact
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "ФИО обязательно")]
        [Display(Name = "ФИО")]
        public string FIO { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email обязателен")]
        [EmailAddress(ErrorMessage = "Введите корректный email адрес")]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Телефон обязателен")]
        [Phone(ErrorMessage = "Введите корректный номер телефона")]
        [Display(Name = "Телефон")]
        public string Phone { get; set; } = string.Empty;

        [Display(Name = "Категория")]
        public int? CategoryId { get; set; }

        [Display(Name = "Категория")]
        public Category? Category { get; set; }
    }
}
