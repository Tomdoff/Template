using Supermarket.API.Persistence.Contexts;
using Supermarket.Domain.Repositories;
using System.Threading.Tasks;

namespace Supermarket.API.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context){
            _context = context;
        }
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}