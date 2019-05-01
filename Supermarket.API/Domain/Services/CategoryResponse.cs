using System.Net;
using Supermarket.API.Domain.Models;

namespace Supermarket.API.Domain.Services
{
    public class CategoryResponse : BaseResponse
    {
        public Category Category { get; }

        private CategoryResponse(bool success, string message, HttpStatusCode statusCode, Category category) : base(success, message, statusCode)
        {
            Category = category;
        }

        /// <summary>
        /// creates a success response
        /// </summary>
        /// <param name="category">Saved category.abstract</param>
        /// <returns>Response.abstract</returns>
        public CategoryResponse(Category category) : base(true, string.Empty, HttpStatusCode.OK)
        {
            Category = category;
        }

        /// <summary>
        /// Creates an error response
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <param name="statusCode">The http response code</param>
        /// <returns>Response</returns>
        public CategoryResponse(string message, HttpStatusCode statusCode) : base(false, message, statusCode)
        {

        }
    }
}