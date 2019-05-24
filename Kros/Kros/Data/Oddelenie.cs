using System.Collections.Generic;

namespace Kros.Data
{
	public class Oddelenie : TableBase
	{
		public PersonO MainPerson { get; set; }
		public Projekt ParentTable { get; set; }
		public List<PersonO> Employee { get; set; }
	}
}
