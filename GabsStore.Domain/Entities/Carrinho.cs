namespace GabsStore.Domain.Entities
{
	public class Carrinho
	{
		public int Id { get; set; }
		public string SessionIdCliente { get; set; }
		public List<Item> Itens { get; set; }
	}
}