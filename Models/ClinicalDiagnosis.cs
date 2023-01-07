using System.ComponentModel.DataAnnotations;

namespace apka2.Models
{
	public class ClinicalDiagnosis
	{
		public int Id { get; set; }


		[Display(Name = "Nazwa")]
		public string? Name { get; set; }


		[Display(Name = "Uwagi")]
		public string? Remarks { get; set; }
	}

}
