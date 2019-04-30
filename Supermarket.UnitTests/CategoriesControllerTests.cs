using Moq;
using Supermarket.Domain.Models;
using Supermarket.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Supermarket.UnitTests
{
    public class CategoriesControllerTests
    {
        [Fact]
        public async Task  GetAllAsync_ReturnsAListOfAllCategories()
        {
            var mockService = new Mock<ICategoryService>();
            mockService.Setup(repo => repo.ListAsync())
	            .ReturnsAsync(GetTestCategories());
            //var controller = new CategoriesController(mockService.Object, )
            //Assert.NotNull(mockRepo);
        }

        private IEnumerable<Category> GetTestCategories() {
	        yield break;
        }
    }
}
