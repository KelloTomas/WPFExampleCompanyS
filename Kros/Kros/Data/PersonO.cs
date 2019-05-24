using System.ComponentModel.DataAnnotations.Schema;

namespace Kros.Data
{
	public class PersonO : Person
	{
		[ForeignKey("PartOf")]
		public int Oddelenie_Id { get; set; }
		public Oddelenie PartOf { get; set; }
	}
}