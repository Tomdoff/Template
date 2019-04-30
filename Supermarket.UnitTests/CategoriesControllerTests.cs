using AutoMapper;
using Moq;
using Supermarket.API.Controllers;
using Supermarket.API.Mapping;
using Supermarket.API.Resources;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Services;
// https://fluentassertions.com/documentation/ for more information
using Xunit;

namespace Supermarket.UnitTests
{
    public class CategoriesControllerTests
    {
        [Fact]
        public async Task GetAllAsync_ReturnsAListOfAllCategories()
        {
			//set up
	        var controller = GetController();
            var expectedResult = GetTestCategoryResources();

            var result = await controller.GetAllAsync();
            var actualResult = result.ToList();
            expectedResult.Should().BeEquivalentTo(actualResult);
        }

        private List<Category> GetTestCategories()
        {
            List<Category> result = new List<Category> {
                new Category { Id = 100, Name = "Fruits and Vegetables" }, // Id set manually due to in-memory provider
		        new Category { Id = 101, Name = "Dairy" }
            };

            return result;
        }

        private List<CategoryResource> GetTestCategoryResources()
        {
            List<CategoryResource> result = new List<CategoryResource> {
                new CategoryResource { Id = 100, Name = "Fruits and Vegetables" }, // Id set manually due to in-memory provider
		        new CategoryResource { Id = 101, Name = "Dairy" }
            };

            return result;
        }

        private CategoriesController GetController()
        {
            var mockService = new Mock<ICategoryService>();
            mockService.Setup(repo => repo.ListAsync()).ReturnsAsync(GetTestCategories());
            var profile = new ModelToResourceProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            var mapper = new Mapper(configuration);
            var controller = new CategoriesController(mockService.Object, mapper);
            return controller;
        }
    }
}
