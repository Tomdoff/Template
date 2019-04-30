using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.Domain.Models;
using Supermarket.Domain.Repositories;

namespace Supermarket.Domain.Services{
	public class ProductService : IProductService{
		private readonly IProductRepository _productRepository;

		public ProductService(IProductRepository productRepository){
			_productRepository = productRepository;
		}

		public async Task<IEnumerable<Product>> ListAsync(){
			return await _productRepository.ListAsync();
		}
	}
}
