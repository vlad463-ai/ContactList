using System.ComponentModel.DataAnnotations;

namespace ContactList.Model
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Название категории обязательно")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Название должно быть от 2 до 50 символов")]
        [Display(Name = "Название категории")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Цвет обязателен")]
        [RegularExpression(@"^#([A-Fa-f0-9]{6})$", ErrorMessage = "Цвет должен быть в формате #RRGGBB (например #ff0000)")]
        [Display(Name = "Цвет")]
        public string Color { get; set; } = "#007bff";

        public ICollection<Contact>? Contacts { get; set; }
    }
}