using System.ComponentModel.DataAnnotations.Schema;

namespace Kros.Data
{
	public class PersonD : Person
	{
		[ForeignKey("PartOf")]
		public int Divizia_Id { get; set; }
		public Divizia PartOf { get; set; }
	}
}