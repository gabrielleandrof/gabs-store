using GabsStore.Domain.Entities;
using GabsStore.Domain.Interfaces.Repositories;
using GabsStore.Domain.Interfaces.Services;
using GabsStore.Domain.Services;
using Moq;

namespace GabsStore.Test.Domain
{
	public class ClienteTest
	{
		[Fact]
		public void DeveInserirUmCliente()
		{
			//arrange
			Endereco endereco = new Endereco()
			{
				Id = new Random().Next(),
				Cep = "",
				Estado = "",
				Cidade = "",
				Bairro = "",
				Logradouro = "",
				Numero = "",
				Complemento = ""
			};
			Cliente cliente = new Cliente(Guid.NewGuid().ToString())
			{
				Id = new Random().Next(),
				NomeCompleto = "Jarbas Jolênio Silva",
				Cpf = "123.870.908-123",
				Email = "jarbas.jolenio@email.com.br",
				TelefonePrincipal = "119978121234",
				DataNascimento = new DateTime(1989, 04, 16),
				Endereco = endereco
			};

			Mock<IClienteRepository> repository = new Mock<IClienteRepository>();
			repository.Setup(x => x.GetById(cliente.Id)).Returns(cliente);

			//act
			IClienteService clienteService = new ClienteService(repository.Object);
			clienteService.Add(cliente);
			var clienteInserido = clienteService.GetById(cliente.Id);

			//assert
			Assert.True(clienteInserido != null);
			Assert.Equal(cliente.Id, clienteInserido?.Id);
		}

		[Fact]
		public void DeveAtualizarUmCliente()
		{
			//arrange
			Endereco endereco = new Endereco()
			{
				Id = new Random().Next(),
				Cep = "",
				Estado = "",
				Cidade = "",
				Bairro = "",
				Logradouro = "",
				Numero = "",
				Complemento = ""
			};
			Cliente cliente = new Cliente(Guid.NewGuid().ToString())
			{
				Id = new Random().Next(),
				NomeCompleto = "Jarbas Jolênio Silva",
				Cpf = "123.870.908-123",
				Email = "jarbas.jolenio@email.com.br",
				TelefonePrincipal = "119978121234",
				DataNascimento = new DateTime(1989, 04, 16),
				Endereco = endereco
			};

			Mock<IClienteRepository> repository = new Mock<IClienteRepository>();
			repository.Setup(x => x.GetById(cliente.Id)).Returns(cliente);

			//act
			cliente.NomeCompleto = "Telê Santana";
			IClienteService clienteService = new ClienteService(repository.Object);
			clienteService.Update(cliente);
			var clienteAlterado = clienteService.GetById(cliente.Id);

			//assert
			Assert.True(clienteAlterado != null);
			Assert.Equal("Telê Santana", clienteAlterado?.NomeCompleto);
		}

		[Fact]
		public void DeveExcluirUmCliente()
		{
			//arrange
			Endereco endereco = new Endereco()
			{
				Id = new Random().Next(),
				Cep = "",
				Estado = "",
				Cidade = "",
				Bairro = "",
				Logradouro = "",
				Numero = "",
				Complemento = ""
			};
			Cliente cliente = new Cliente(Guid.NewGuid().ToString())
			{
				Id = new Random().Next(),
				NomeCompleto = "Jarbas Jolênio Silva",
				Cpf = "123.870.908-123",
				Email = "jarbas.jolenio@email.com.br",
				TelefonePrincipal = "119978121234",
				DataNascimento = new DateTime(1989, 04, 16),
				Endereco = endereco
			};
			var clienteId = cliente.Id;

			Mock<IClienteRepository> repository = new Mock<IClienteRepository>();

			//act
			IClienteService clienteService = new ClienteService(repository.Object);
			clienteService.Delete(cliente);
			var clienteExcluido = clienteService.GetById(clienteId);

			//assert
			Assert.Null(clienteExcluido);
		}


		[Fact]
		public void DeveObterTodosOsClientes()
		{
			//arrange
			List<Cliente> clientes = new List<Cliente>();

			for (int i = 0; i < 10; i++)
			{
				Endereco endereco = new Endereco()
				{
					Id = new Random().Next(),
					Cep = "",
					Estado = "",
					Cidade = "",
					Bairro = "",
					Logradouro = "",
					Numero = "",
					Complemento = ""
				};
				Cliente cliente = new Cliente(Guid.NewGuid().ToString())
				{
					Id = new Random().Next(),
					NomeCompleto = $"Jarbas Jolênio Silva {i}",
					Cpf = $"{i}23.870.908-12{i}",
					Email = "jarbas.jolenio@email.com.br",
					TelefonePrincipal = "119978121234",
					DataNascimento = new DateTime(1989, 04, 16),
					Endereco = endereco
				};
				clientes.Add(cliente);
			}

			Mock<IClienteRepository> repository = new Mock<IClienteRepository>();
			repository.Setup(x => x.GetAll()).Returns(clientes);

			//act
			IClienteService clienteService = new ClienteService(repository.Object);
			var todosClientes = clienteService.GetAll();

			//assert
			Assert.True(clientes.Count() > 1);
			Assert.True(clientes.Count() == 10);
			Assert.Equal(todosClientes, clientes);
		}
	}
}