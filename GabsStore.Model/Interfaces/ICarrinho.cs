using GabsStore.Model.Entities;

namespace GabsStore.Model.Interfaces
{
	public interface ICarrinho
	{
		void AdicionarItem(Item item);
		void RemoverItem(Item item);
		void RemoverTodosItens();
		List<Item> ObterTodosItens();
	}
}