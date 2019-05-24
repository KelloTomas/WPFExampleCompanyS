using System.Collections.Generic;

namespace Kros.Data
{
	public class Projekt : TableBase
	{
		public PersonP MainPerson { get; set; }
		public Divizia ParentTable { get; set; }
		public List<Oddelenie> SubTable { get; set; }
		public List<PersonP> Employee { get; set; }
	}
}
