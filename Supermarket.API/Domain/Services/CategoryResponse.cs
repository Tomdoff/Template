using Supermarket.API.Domain.Models;
using Supermarket.API.Services.Communication;

namespace Supermarket.API.Domain.Services.Communication {
		public class CategoryResponse : BaseResponse {
				public Category Category { get; private set; }

				private CategoryResponse (bool success, string message, Category category) : base (success, message) {
					Category = category;
				}

				/// <summary>
				/// creates a success response
				/// </summary>
				/// <param name="category">Saved category.abstract</param>
				/// <returns>Response.abstract</returns>
				public CategoryResponse(Category category) : this(true, string.Empty, category){

				}

				/// <summary>
				/// Creates an error response
				/// </summary>
				/// <param name="message">Error message.</param>
				/// <returns>Response</returns>
				public CategoryResponse(string message) : this(false, message, null){

				}
		}
}