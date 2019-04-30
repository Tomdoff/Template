using Microsoft.EntityFrameworkCore;
using Supermarket.API.Persistence.Contexts;
using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Repositories;

namespace Supermarket.API.Persistence.Repositories
{
    public class ProductRepository: BaseRepository, IProductRepository{
		public ProductRepository(AppDbContext context) : base(context){
		}

		public async Task<IEnumerable<Product>> ListAsync(){
			return await _context.Products.Include(p=>p.Category)
				.ToListAsync();
		}
	}
}

