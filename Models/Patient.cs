using System.ComponentModel.DataAnnotations;

namespace apka.Models
{
	public class Patient
	{
		public int Id { get; set; }


		[Display(Name = "Inicjaly")]
		public string? Initials { get; set; }


		[DataType(DataType.Date)]
		[Display(Name = "Data urodzenia")]
		public DateTime BirthDate { get; set; }


		[Display(Name = "Data hospitalizacji")]
		public DateTime HospitalizationDate { get; set; }


		[Display(Name = "Data rozpoczecia CKRT")]
		public DateTime StartOfCKRTDate { get; set; }


		[Display(Name = "Niewydolnosc watroby")]
		public Boolean HasLiverFailure { get; set; }


		[Display(Name = "Masa ciala")]
		public decimal Weight { get; set; }


		[Display(Name = "Wzrost")]
		public decimal Height { get; set; }


		[Display(Name = "BSA")]
		public decimal BSA { get; set; }


		[Display(Name = "ECMO")]
		public Boolean HasECMO { get; set; }


		[Display(Name = "Uwagi")]
		public string? Remarks { get; set; }
	}
}
