using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace apka.Models
{
	public class ClinicalDiagnosis
	{
		public int Id { get; set; }


		[Display(Name = "Nazwa rozpoznania")]
		public string? DiagnosisName { get; set; }


		[Display(Name = "Uwagi")]
		public string? Remarks { get; set; }
	}
}
