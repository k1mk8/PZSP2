using System.ComponentModel.DataAnnotations;

namespace apka2.Models
{
	public class Procedure
	{
		public int Id { get; set; }


		[Display(Name = "ECMO")]
		public bool IsECMO { get; set; }


		[Display(Name = "Zakonczony planowo")]
		public bool EndedOnSchedule { get; set; }


		[Display(Name = "Zwrocono krew")]
		public bool BloodWasReturned { get; set; }


		[Display(Name = "Powod nieplanowanego zakonczenia")]
		public string? ReasonOfUnplannedTermination { get; set; }


		[Display(Name = "Uwagi")]
		public string? Remarks { get; set; }
	}
}
