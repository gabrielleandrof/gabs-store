using GabsStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GabsStore.Data.Context
{
	public class DbGabsStoreContext : DbContext
	{
		public DbGabsStoreContext()
		{
		}

		public DbGabsStoreContext(DbContextOptions<DbGabsStoreContext> options) : base(options)
		{
		}

		public DbSet<Cliente> Clientes { get; set; }
	}
}