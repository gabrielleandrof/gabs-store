using GabsStore.Data.Context;
using GabsStore.Domain.Entities;
using GabsStore.Domain.Interfaces.Repositories;

namespace GabsStore.Data.Repositories
{
	public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
	{
		private readonly DbGabsStoreContext _dbContext;

		public ClienteRepository(DbGabsStoreContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}
	}
}