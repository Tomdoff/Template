using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Supermarket.API.Domain.Services {
    public abstract class BaseResponse {
        public bool Success { get; protected set; }
        public string Message { get; protected set; }
		public HttpStatusCode StatusCode { get; set; }

        protected BaseResponse(bool success, string message, HttpStatusCode statusCode) {
            Success = success;
            Message = message;
            StatusCode = statusCode;
        }

		/// <summary>
        /// Creates an object result built from the error message and status code
        /// </summary>
        /// <returns></returns>
        public ObjectResult GetResponse()
        {
	        return new ObjectResult(new {Message}) {StatusCode = (int)StatusCode};
        }
    }
}