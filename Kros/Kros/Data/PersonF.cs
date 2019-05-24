using System.ComponentModel.DataAnnotations.Schema;

namespace Kros.Data
{
	public class PersonF : Person
	{
		[ForeignKey("PartOf")]
		public int Firma_Id { get; set; }
		public Firma PartOf { get; set; }
	}
}