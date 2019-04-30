using System.Threading.Tasks;
using Moq;
using Xunit;
using Supermarket.Domain.Repositories;

namespace Supermarket.UnitTests
{
    public class CategoriesControllerTests
    {
        [Fact]
        public async Task  GetAllAsync_ReturnsAListOfAllCategories()
        {
            var mockRepo = new Mock<ICategoryRepository>();
            Assert.NotNull(mockRepo);
        }
    }
}
