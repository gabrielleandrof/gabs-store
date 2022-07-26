using GabsStore.Model.Entities;
using GabsStore.Model.Interfaces;

namespace GabsStore.Test.Model
{
	public class CarrinhoTest
	{
		Cliente _cliente;

		public CarrinhoTest()
		{
			_cliente = new Cliente(Guid.NewGuid().ToString());
		}

		[Fact]
		public void DeveAdicionarUmItemAoCarrinho()
		{
			//arrange
			Item item = new Item();
			item.Id = 1;
			item.Nome = "Guitarra Gibson Les Paul Custom 1989";
			item.Preco = 33259.99;
			item.IdEstoque = 1;
			item.Descricao = "Guitarra top de linha da Gibson, fabricada nos EUA com a maior excelência em qualidade... etc";

			//act
			ICarrinho carrinho = new Carrinho(_cliente.SessionId);
			carrinho.AdicionarItem(item);

			//assert
			Assert.True(carrinho.ObterTodosItens().Count() == 1);
		}

		[Fact]
		public void DeveAdicionarVariosItensAoCarrinho()
		{
			//arrange
			Item item = new Item();
			item.Id = 1;
			item.Nome = "Guitarra Gibson Les Paul Custom 1989";
			item.Preco = 33259.99;
			item.IdEstoque = 1;
			item.Descricao = "Guitarra top de linha da Gibson, fabricada nos EUA com a maior excelência em qualidade... etc";

			Item item2 = new Item();
			item2.Id = 2;
			item2.Nome = "Licor Baileys";
			item2.Preco = 77.25;
			item2.IdEstoque = 2;
			item2.Descricao = "Bebida aperitiva para drinks";

			Item item3 = new Item();
			item3.Id = 3;
			item3.Nome = "TV Samsung 43 polegadas 4k Modelo XPTO";
			item3.Preco = 1659.9;
			item3.IdEstoque = 3;
			item3.Descricao = "TV de 43 polegadas com resolução 4k perfeita para seus filmes e games";

			//act
			ICarrinho carrinho = new Carrinho(_cliente.SessionId);
			carrinho.AdicionarItem(item);
			carrinho.AdicionarItem(item2);
			carrinho.AdicionarItem(item3);

			//assert
			Assert.True(carrinho.ObterTodosItens().Count() == 3);
			Assert.Contains(item, carrinho.ObterTodosItens());
			Assert.Contains(item2, carrinho.ObterTodosItens());
			Assert.Contains(item3, carrinho.ObterTodosItens());
		}

		[Fact]
		public void DeveRemoverUmItemDoCarrinhoQuandoTemSomenteUmItem()
		{
			//arrange
			Item item = new Item();
			item.Id = 1;
			item.Nome = "Guitarra Gibson Les Paul Custom 1989";
			item.Preco = 33259.99;
			item.IdEstoque = 1;
			item.Descricao = "Guitarra top de linha da Gibson, fabricada nos EUA com a maior excelência em qualidade... etc";

			ICarrinho carrinho = new Carrinho(_cliente.SessionId);
			carrinho.AdicionarItem(item);

			//act
			carrinho.RemoverItem(item);

			//assert
			Assert.DoesNotContain(item, carrinho.ObterTodosItens());
		}

		[Fact]
		public void DeveRemoverUmItemDoCarrinhoQuandoTemVariosItensDiferentes()
		{
			//arrange
			Item item = new Item();
			item.Id = 1;
			item.Nome = "Guitarra Gibson Les Paul Custom 1989";
			item.Preco = 33259.99;
			item.IdEstoque = 1;
			item.Descricao = "Guitarra top de linha da Gibson, fabricada nos EUA com a maior excelência em qualidade... etc";

			Item item2 = new Item();
			item2.Id = 2;
			item2.Nome = "Licor Baileys";
			item2.Preco = 77.25;
			item2.IdEstoque = 2;
			item2.Descricao = "Bebida aperitiva para drinks";

			Item item3 = new Item();
			item3.Id = 3;
			item3.Nome = "TV Samsung 43 polegadas 4k Modelo XPTO";
			item3.Preco = 1659.9;
			item3.IdEstoque = 3;
			item3.Descricao = "TV de 43 polegadas com resolução 4k perfeita para seus filmes e games";

			ICarrinho carrinho = new Carrinho(_cliente.SessionId);
			carrinho.AdicionarItem(item);
			carrinho.AdicionarItem(item2);
			carrinho.AdicionarItem(item3);

			//act
			carrinho.RemoverItem(item2);

			//assert
			Assert.DoesNotContain(item2, carrinho.ObterTodosItens());
			Assert.True(carrinho.ObterTodosItens().Count() == 2);
		}
		[Fact]
		public void DeveRemoverTodosOsItensDoCarrinho()
		{
			//arrange
			Item item = new Item();
			item.Id = 1;
			item.Nome = "Guitarra Gibson Les Paul Custom 1989";
			item.Preco = 33259.99;
			item.IdEstoque = 1;
			item.Descricao = "Guitarra top de linha da Gibson, fabricada nos EUA com a maior excelência em qualidade... etc";

			Item item2 = new Item();
			item2.Id = 2;
			item2.Nome = "Licor Baileys";
			item2.Preco = 77.25;
			item2.IdEstoque = 2;
			item2.Descricao = "Bebida aperitiva para drinks";

			Item item3 = new Item();
			item3.Id = 3;
			item3.Nome = "TV Samsung 43 polegadas 4k Modelo XPTO";
			item3.Preco = 1659.9;
			item3.IdEstoque = 3;
			item3.Descricao = "TV de 43 polegadas com resolução 4k perfeita para seus filmes e games";

			ICarrinho carrinho = new Carrinho(_cliente.SessionId);
			carrinho.AdicionarItem(item);
			carrinho.AdicionarItem(item2);
			carrinho.AdicionarItem(item3);

			//act
			carrinho.RemoverTodosItens();

			//assert
			Assert.Empty(carrinho.ObterTodosItens());
		}

		[Fact]
		public void DeveRemoverUmItemDoCarrinhoQuandoTemVariosItensDoMesmoId()
		{
			//arrange
			Item item = new Item();
			item.Id = 1;
			item.Nome = "Guitarra Gibson Les Paul Custom 1989";
			item.Preco = 33259.99;
			item.IdEstoque = 1;
			item.Descricao = "Guitarra top de linha da Gibson, fabricada nos EUA com a maior excelência em qualidade... etc";

			Item item2 = new Item();
			item2.Id = 1;
			item2.Nome = "Guitarra Gibson Les Paul Custom 1989";
			item2.Preco = 33259.99;
			item2.IdEstoque = 1;
			item2.Descricao = "Guitarra top de linha da Gibson, fabricada nos EUA com a maior excelência em qualidade... etc";

			Item item3 = new Item();
			item3.Id = 1;
			item3.Nome = "Guitarra Gibson Les Paul Custom 1989";
			item3.Preco = 33259.99;
			item3.IdEstoque = 1;
			item3.Descricao = "Guitarra top de linha da Gibson, fabricada nos EUA com a maior excelência em qualidade... etc";

			Item item4 = new Item();
			item4.Id = 1;
			item4.Nome = "Guitarra Gibson Les Paul Custom 1989";
			item4.Preco = 33259.99;
			item4.IdEstoque = 1;
			item4.Descricao = "Guitarra top de linha da Gibson, fabricada nos EUA com a maior excelência em qualidade... etc";

			ICarrinho carrinho = new Carrinho(_cliente.SessionId);
			carrinho.AdicionarItem(item);
			carrinho.AdicionarItem(item2);
			carrinho.AdicionarItem(item3);
			carrinho.AdicionarItem(item4);

			//act
			carrinho.RemoverItem(item2);

			//assert
			Assert.True(carrinho.ObterTodosItens().Count() == 3);
		}

		[Fact]
		public void DeveRemoverUmItemDoCarrinhoQuandoTemVariosItensAleatorios()
		{
			//arrange
			Item item = new Item();
			item.Id = 1;
			item.Nome = "Guitarra Gibson Les Paul Custom 1989";
			item.Preco = 33259.99;
			item.IdEstoque = 1;
			item.Descricao = "Guitarra top de linha da Gibson, fabricada nos EUA com a maior excelência em qualidade... etc";

			Item item2 = new Item();
			item2.Id = 1;
			item2.Nome = "Guitarra Gibson Les Paul Custom 1989";
			item2.Preco = 33259.99;
			item2.IdEstoque = 1;
			item2.Descricao = "Guitarra top de linha da Gibson, fabricada nos EUA com a maior excelência em qualidade... etc";

			Item item3 = new Item();
			item3.Id = 3;
			item3.Nome = "TV Samsung 43 polegadas 4k Modelo XPTO";
			item3.Preco = 1659.9;
			item3.IdEstoque = 3;
			item3.Descricao = "TV de 43 polegadas com resolução 4k perfeita para seus filmes e games";

			Item item4 = new Item();
			item4.Id = 4;
			item4.Nome = "Licor Baileys";
			item4.Preco = 77.25;
			item4.IdEstoque = 2;
			item4.Descricao = "Bebida aperitiva para drinks";

			Item item5 = new Item();
			item5.Id = 2;
			item5.Nome = "Licor Baileys";
			item5.Preco = 77.25;
			item5.IdEstoque = 2;
			item5.Descricao = "Bebida aperitiva para drinks";

			ICarrinho carrinho = new Carrinho(_cliente.SessionId);
			carrinho.AdicionarItem(item);
			carrinho.AdicionarItem(item2);
			carrinho.AdicionarItem(item3);
			carrinho.AdicionarItem(item4);
			carrinho.AdicionarItem(item5);

			//act
			carrinho.RemoverItem(item2);

			//assert
			Assert.True(carrinho.ObterTodosItens().Count() == 4);
		}

		[Fact]
		public void DeveRemoverDoisItensDoCarrinhoQuandoTemVariosItensAleatorios()
		{
			//arrange
			Item item = new Item();
			item.Id = 1;
			item.Nome = "Guitarra Gibson Les Paul Custom 1989";
			item.Preco = 33259.99;
			item.IdEstoque = 1;
			item.Descricao = "Guitarra top de linha da Gibson, fabricada nos EUA com a maior excelência em qualidade... etc";

			Item item2 = new Item();
			item2.Id = 1;
			item2.Nome = "Guitarra Gibson Les Paul Custom 1989";
			item2.Preco = 33259.99;
			item2.IdEstoque = 1;
			item2.Descricao = "Guitarra top de linha da Gibson, fabricada nos EUA com a maior excelência em qualidade... etc";

			Item item3 = new Item();
			item3.Id = 3;
			item3.Nome = "TV Samsung 43 polegadas 4k Modelo XPTO";
			item3.Preco = 1659.9;
			item3.IdEstoque = 3;
			item3.Descricao = "TV de 43 polegadas com resolução 4k perfeita para seus filmes e games";

			Item item4 = new Item();
			item4.Id = 4;
			item4.Nome = "Licor Baileys";
			item4.Preco = 77.25;
			item4.IdEstoque = 2;
			item4.Descricao = "Bebida aperitiva para drinks";

			Item item5 = new Item();
			item5.Id = 2;
			item5.Nome = "Licor Baileys";
			item5.Preco = 77.25;
			item5.IdEstoque = 2;
			item5.Descricao = "Bebida aperitiva para drinks";

			ICarrinho carrinho = new Carrinho(_cliente.SessionId);
			carrinho.AdicionarItem(item);
			carrinho.AdicionarItem(item2);
			carrinho.AdicionarItem(item3);
			carrinho.AdicionarItem(item4);
			carrinho.AdicionarItem(item5);

			//act
			carrinho.RemoverItem(item2);
			carrinho.RemoverItem(item5);

			//assert
			Assert.True(carrinho.ObterTodosItens().Count() == 3);
		}

		[Fact]
		public void DeveAumentarQuantidadeDeUmItemDoCarrinho()
		{
			//arrange
			Item item = new Item();
			item.Id = 1;
			item.Nome = "Guitarra Gibson Les Paul Custom 1989";
			item.Preco = 33259.99;
			item.IdEstoque = 1;
			item.Descricao = "Guitarra top de linha da Gibson, fabricada nos EUA com a maior excelência em qualidade... etc";

			ICarrinho carrinho = new Carrinho(_cliente.SessionId);
			carrinho.AdicionarItem(item);

			Item item2 = new Item();
			item2.Id = 1;
			item2.Nome = "Guitarra Gibson Les Paul Custom 1989";
			item2.Preco = 33259.99;
			item2.IdEstoque = 1;
			item2.Descricao = "Guitarra top de linha da Gibson, fabricada nos EUA com a maior excelência em qualidade... etc";

			//act
			carrinho.AdicionarItem(item2);

			//assert
			Assert.True(carrinho.ObterTodosItens().Count() == 2);

		}
	}
}
