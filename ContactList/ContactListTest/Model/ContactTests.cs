using ContactList.Model;
using System.ComponentModel.DataAnnotations;

namespace ContactListTest.UnitTests.Model
{
    public class ContactTests
    {
        [Fact]
        public void Contact_WithValidData_ShouldBeValid()
        {
            var contact = new Contact
            {
                FIO = "Иванов Иван Иванович",
                Email = "ivanov@mail.ru",
                Phone = "+7(999)123-45-67"
            };

            var context = new ValidationContext(contact);
            var result = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(contact, context, result, true);

            Assert.True(isValid);
            Assert.Empty(result);
        }

        [Fact]
        public void Contact_WithEmptyFIO_ShouldBeInvalid()
        {
            var contact = new Contact
            {
                FIO = "",
                Email = "ivanov@mail.ru",
                Phone = "+7(999)123-45-67"
            };

            var context = new ValidationContext(contact);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(contact, context, results, true);

            Assert.False(isValid);
            Assert.Contains(results, r => r.ErrorMessage != null && r.ErrorMessage.Contains("ФИО"));
        }

        [Fact]
        public void Contact_WithInvalidEmail_ShouldBeInvalid()
        {
            var contact = new Contact
            {
                FIO = "Иванов Иван",
                Email = "неправильный-email",
                Phone = "+7(999)123-45-67"
            };

            var context = new ValidationContext(contact);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(contact, context, results, true);

            Assert.False(isValid);
            Assert.Contains(results, r => r.ErrorMessage != null && r.ErrorMessage.Contains("Email"));
        }
    }
}