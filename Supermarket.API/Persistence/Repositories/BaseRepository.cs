using Supermarket.API.Persistence.Contexts;

namespace Supermarket.API.Persistence.Repositories{
	// an abstract class class doesn't have direct instances. 
	public abstract class BaseRepository{
		//recieves an instance of the database context (by dependency injection)
		protected readonly AppDbContext _context;

		public BaseRepository(AppDbContext context){
			_context = context;
		}		
	}

}
