using Microsoft.EntityFrameworkCore;
using Supermarket.API.Persistence.Contexts;
using Supermarket.Domain.Models;
using Supermarket.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

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

