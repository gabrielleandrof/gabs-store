using GabsStore.Domain.Entities;

namespace GabsStore.Domain.Interfaces.Services
{
	public interface ICarrinhoService
	{
		void AdicionarItem(Item item);
		void RemoverItem(Item item);
		void RemoverTodosItens();
		List<Item> ObterTodosItens();
	}
}