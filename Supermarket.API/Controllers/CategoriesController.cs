﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Services;
using Supermarket.Resources;

namespace Supermarket.API.Controllers {
	[ApiController]
	[Route("api/[controller]")]
	public class CategoriesController : ControllerBase {
		private readonly ICategoryService _categoryService;
		private readonly IMapper _mapper;

		public CategoriesController(ICategoryService categoryService, IMapper mapper) {
			_categoryService = categoryService;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllAsync() {
			var categories = await _categoryService.ListAsync();
			var resources = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryResource>>(categories);
			return Ok(resources);
		}

		[HttpPost]
		public async Task<IActionResult> PostAsync([FromBody] SaveCategoryResource resource) {
			var category = _mapper.Map<SaveCategoryResource, Category>(resource);

			var result = await _categoryService.SaveAsync(category);

			if (!result.Success) {
				return result.GetResponse();
			}

			var categoryResource = _mapper.Map<Category, CategoryResource>(result.Category);
			return Ok(categoryResource);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCategoryResource resource) {
			var category = _mapper.Map<SaveCategoryResource, Category>(resource);
			var result = await _categoryService.UpdateAsync(id, category);

			if (!result.Success) {
				return result.GetResponse();
			}

			var categoryResource = _mapper.Map<Category, CategoryResource>(result.Category);
			return Ok(categoryResource);
		}


		[HttpDelete]
		public async Task<IActionResult> DeleteAsync(int id) {
			var result = await _categoryService.DeleteAsync(id);

			if (!result.Success) {
				return result.GetResponse();
			}

			var categoryResource = _mapper.Map<Category, CategoryResource>(result.Category);
			return Ok(categoryResource);
		}
	}
}