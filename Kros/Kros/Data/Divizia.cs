using System.Collections.Generic;

namespace Kros.Data
{
	public class Divizia : TableBase
	{
		public PersonD MainPerson { get; set; }
		public Firma ParentTable { get; set; }
		public List<Projekt> SubTable { get; set; }
		public List<PersonD> Employee { get; set; }
	}
}
