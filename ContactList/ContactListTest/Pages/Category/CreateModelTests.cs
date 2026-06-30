using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContactList.Data;
using ContactList.Model;
using FluentAssertions;

namespace ContactListTest.UnitTests.Pages.Category
{
    public class CreateModelTests
    {
        private ApplicationDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            return new ApplicationDbContext(options);
        }

        [Fact]
        public void OnPost_ShouldReturnPage_WhenModelStateIsInvalid()
        {
            var context = GetDbContext();
            var pageModel = new ContactList.Pages.Categories.CreateModel(context);

            pageModel.ModelState.AddModelError("Name", "Required");

            var result = pageModel.OnPostAsync().Result;

            result.Should().BeOfType<PageResult>();
            context.Categories.Count().Should().Be(0);
        }
    }
}