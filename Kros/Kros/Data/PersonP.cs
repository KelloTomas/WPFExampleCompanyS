using System.ComponentModel.DataAnnotations.Schema;

namespace Kros.Data
{
	public class PersonP : Person
	{
		[ForeignKey("PartOf")]
		public int Projekt_Id { get; set; }
		public Projekt PartOf { get; set; }
	}
}