using GabsStore.Domain.Interfaces.Repositories;
using GabsStore.Domain.Interfaces.Services;

namespace GabsStore.Domain.Services
{
	public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
	{
		private readonly IBaseRepository<TEntity> _repository;

		public BaseService(IBaseRepository<TEntity> repository)
		{
			_repository = repository;
		}

		public void Add(TEntity entity)
		{
			_repository.Add(entity);
		}

		public void Delete(TEntity entity)
		{
			_repository.Delete(entity);
		}

		public IEnumerable<TEntity> GetAll()
		{
			return _repository.GetAll();
		}

		public TEntity GetById(int id)
		{
			return _repository.GetById(id);
		}

		public void Update(TEntity entity)
		{
			_repository.Update(entity);
		}
	}
}