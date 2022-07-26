using GabsStore.Data.Context;
using GabsStore.Domain.Interfaces.Repositories;

namespace GabsStore.Data.Repositories
{
	public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
	{
		private readonly DbGabsStoreContext _dbContext;

		public BaseRepository(DbGabsStoreContext dbContext)
		{
			_dbContext = dbContext;
		}

		public void Add(TEntity obj)
		{
			try
			{
				_dbContext.Set<TEntity>().Add(obj);
				_dbContext.SaveChanges();
			}
			catch (Exception ex)
			{
			}
		}

		public void Delete(TEntity obj)
		{
			try
			{
				_dbContext.Set<TEntity>().Remove(obj);
				_dbContext.SaveChanges();
			}
			catch (Exception ex)
			{
			}
		}

		public IEnumerable<TEntity> GetAll()
		{
			try
			{
				return _dbContext.Set<TEntity>().ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		public TEntity GetById(int id)
		{
			try
			{
				return _dbContext.Set<TEntity>().Find(id);
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		public void Update(TEntity obj)
		{
			try
			{
				_dbContext.Set<TEntity>().Update(obj);
				_dbContext.SaveChanges();
			}
			catch (Exception ex)
			{
			}
		}
	}
}
