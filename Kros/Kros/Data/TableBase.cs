using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kros.Data
{
	public abstract class TableBase
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Name { get; set; }
		public int? Code { get; set; }

		public override string ToString()
		{
			return $"{this.GetType().Name} {Name}";
		}

	}
}
