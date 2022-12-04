using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apka2.Models
{
	public class Patient
	{
		public int Id { get; set; }


		[Display(Name = "Inicjaly")]
		public string? Initials { get; set; }


		[DataType(DataType.Date)]
		[Display(Name = "Data urodzenia")]
		public DateTime BirthDate { get; set; }


		[DataType(DataType.Date)]
		[Display(Name = "Data hospitalizacji")]
		public DateTime HospitalizationDate { get; set; }


		[DataType(DataType.Date)]
		[Display(Name = "Data rozpoczecia CKRT")]
		public DateTime StartOfCKRTDate { get; set; }


		[Display(Name = "Niewydolnosc watroby")]
		public bool HasLiverFailure { get; set; }


		[Display(Name = "Istotne klinicznie zaburzenia krzepniecia")]
		public bool HasClinicallySignificantCoagulationDisorders { get; set; }


		[Display(Name = "Masa ciala")]
		[Column(TypeName = "decimal(6, 2)")]
		public decimal Weight { get; set; }


		[Display(Name = "Wzrost")]
		[Column(TypeName = "decimal(6, 2)")]
		public decimal Height { get; set; }


		[Display(Name = "Uwagi")]
		public string? Remarks { get; set; }
	}
}
