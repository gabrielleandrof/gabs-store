using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GabsStore.Model.Entities
{
	public class Item
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public double Preco { get; set; }
		public int IdEstoque { get; set; }
		public string Descricao { get; set; }
	}
}