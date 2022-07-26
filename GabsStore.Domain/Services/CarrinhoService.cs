using GabsStore.Domain.Entities;
using GabsStore.Domain.Interfaces.Services;

namespace GabsStore.Domain.Services
{
	public class CarrinhoService : ICarrinhoService
	{
		Carrinho _carrinho;

		public CarrinhoService(string sessionIdCliente)
		{
			_carrinho = new Carrinho();
			_carrinho.SessionIdCliente = sessionIdCliente;
			_carrinho.Itens = new List<Item>();
		}

		public void AdicionarItem(Item item)
		{
			_carrinho.Itens.Add(item);
		}

		public void RemoverItem(Item item)
		{
			var itemRemover = _carrinho.Itens.FirstOrDefault(x => x.Id == item.Id);
			if (itemRemover != null)
				_carrinho.Itens.Remove(itemRemover);
		}

		public void RemoverTodosItens()
		{
			_carrinho.Itens.Clear();
		}

		public List<Item> ObterTodosItens()
		{
			return _carrinho.Itens;
		}
	}
}