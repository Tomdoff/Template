using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.Domain.Models;
using Supermarket.Domain.Repositories;

namespace Supermarket.Domain.Services {
    public class CategoryService : ICategoryService {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService (ICategoryRepository categoryRepository, IUnitOfWork unitOfWork) {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CategoryResponse> DeleteAsync (int id) {
            var existingCategory = await _categoryRepository.FindByIdAsync (id);

            if (existingCategory == null) {
                return new CategoryResponse ("Category not found.");
            }

            try {
                _categoryRepository.Remove (existingCategory);
                await _unitOfWork.CompleteAsync ();

                return new CategoryResponse (existingCategory);
            } catch (Exception ex) {
                // Do some loggin stuff
                return new CategoryResponse ($"An error occured when deleting the category: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Category>> ListAsync () {
            return await _categoryRepository.ListAsync ();
        }

        public async Task<CategoryResponse> SaveAsync (Category category) {
            try {
                await _categoryRepository.AddAsync (category);
                await _unitOfWork.CompleteAsync ();

                return new CategoryResponse (category);
            } catch (Exception ex) {
                // Do some logging stuff
                return new CategoryResponse ($"An error occurred when saving the category: {ex.Message}");
            }
        }

        public async Task<CategoryResponse> UpdateAsync (int id, Category category) {
            var existingCategory = await _categoryRepository.FindByIdAsync (id);
            if (existingCategory == null) {
                return new CategoryResponse ("Category not found.");
            }

            existingCategory.Name = category.Name;

            try {
                _categoryRepository.Update (existingCategory);
                await _unitOfWork.CompleteAsync ();

                return new CategoryResponse (existingCategory);
            } catch (Exception ex) {
                //do some logging stuff
                return new CategoryResponse ($"An error occurred when updating the category: {ex.Message}");
            }
        }
    }
}