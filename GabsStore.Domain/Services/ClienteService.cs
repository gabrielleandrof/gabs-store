using GabsStore.Domain.Entities;
using GabsStore.Domain.Interfaces.Repositories;
using GabsStore.Domain.Interfaces.Services;

namespace GabsStore.Domain.Services
{
	public class ClienteService : BaseService<Cliente>, IClienteService
	{
		private readonly IClienteRepository _clienteRepository;

		public ClienteService(IClienteRepository clienteRepository)
			: base(clienteRepository)
		{
			_clienteRepository = clienteRepository;
		}
	}
}