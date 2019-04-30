using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Supermarket.API.Extensions{
	//Extension methods should be static
	//They shouldn't handle specific instance data and they're only loaded once when the application starts
	public static class ModelStateExtensions{
		//use of this tells the c# compiler to treat this as an extension method.
		public static List<string> GetErrorMessages(this ModelStateDictionary dictionary){
			return dictionary.SelectMany(m=>m.Value.Errors)
				.Select(m => m.ErrorMessage)
				.ToList();
		}
	}
}
