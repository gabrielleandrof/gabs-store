using GabsStore.Model.Interfaces;

namespace GabsStore.Model.Entities
{
	public class Carrinho : ICarrinho
	{
		public int Id { get; set; }
		public string SessionIdCliente { get; private set; }
		public List<Item> Itens { get; set; }

		public Carrinho(string sessionIdCliente)
		{
			SessionIdCliente = sessionIdCliente;
			Itens = new List<Item>();
		}

		public void AdicionarItem(Item item)
		{
			Itens.Add(item);
		}

		public void RemoverItem(Item item)
		{
			var itemRemover = Itens.FirstOrDefault(x => x.Id == item.Id);
			if (itemRemover != null)
				Itens.Remove(itemRemover);
		}

		public void RemoverTodosItens()
		{
			Itens.Clear();
		}

		public List<Item> ObterTodosItens()
		{
			return Itens;
		}
	}
}