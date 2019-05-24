using System.Collections.Generic;

namespace Kros.Data
{
	public class Firma : TableBase
	{
		public PersonF MainPerson { get; set; }
		public List<Divizia> SubTable { get; set; }
		public List<PersonF> Employee { get; set; }
	}
}
