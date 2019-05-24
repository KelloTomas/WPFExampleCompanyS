using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kros.Data
{
	public abstract class Person
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Title { get; set; }
		public string FirstName { get; set; }
		public string SurName { get; set; }
		public string Telephone { get; set; }
		public string Email { get; set; }
		public override string ToString()
		{
			return $"{Title} {SurName} {FirstName}";
		}
	}
}