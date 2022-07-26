namespace GabsStore.Domain.Entities
{
	public class Cliente
	{
		public int Id { get; set; }
		public string SessionId { get; private set; }
		public string NomeCompleto { get; set; }
		public string Cpf { get; set; }
		public string Email { get; set; }
		public string TelefonePrincipal { get; set; }
		public string? TelefoneSecundario { get; set; }
		public DateTime DataNascimento { get; set; }
		public Endereco Endereco { get; set; }

		public Cliente(string sessionId)
		{
			SessionId = sessionId;
			Endereco = new Endereco();
		}
	}
}