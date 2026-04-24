using System.ComponentModel.DataAnnotations;

namespace ContactList.Model
{
    public class Contact
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "ФИО обязательно для заполнения")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "ФИО должно быть от 2 до 100 символов")]
        [Display(Name = "ФИО")]
        public string FIO { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email обязателен для заполнения")]
        [EmailAddress(ErrorMessage = "Введите корректный email адрес")]
        [StringLength(100, ErrorMessage = "Email не должен превышать 100 символов")]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Телефон обязателен для заполнения")]
        [Phone(ErrorMessage = "Введите корректный номер телефона")]
        [StringLength(20, MinimumLength = 10, ErrorMessage = "Телефон должен быть от 10 до 20 символов")]
        [Display(Name = "Телефон")]
        public string Phone { get; set; } = string.Empty;

        [Display(Name = "Категория")]
        public int? CategoryId { get; set; }

        public Category? Category { get; set; }
    }
}