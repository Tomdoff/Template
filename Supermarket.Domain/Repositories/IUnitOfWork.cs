using System.Threading.Tasks;

namespace Supermarket.Domain.Repositories{
	public interface IUnitOfWork{
		Task CompleteAsync();
	}
}
