using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GabsStore.Model.Entities
{
	public class Cliente
	{
		public int Id { get; set; }
		public string SessionId { get; private set; }

		public Cliente(string sessionId)
		{
			SessionId = sessionId;
		}
	}
}