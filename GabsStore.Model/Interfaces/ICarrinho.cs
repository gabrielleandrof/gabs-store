using GabsStore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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