using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apka2.Models
{
	public class Patient
	{
		public int Id { get; set; }

        public int DoctorId { get; set; }


        [Display(Name = "Inicjały")]
		public string? Initials { get; set; }


		[DataType(DataType.Date)]
		[Display(Name = "Data urodzenia")]
		public DateTime BirthDate { get; set; }


		[DataType(DataType.Date)]
		[Display(Name = "Data hospitalizacji")]
		public DateTime HospitalizationDate { get; set; }


		[DataType(DataType.Date)]
		[Display(Name = "Data rozpoczęcia CKRT")]
		public DateTime StartOfCKRTDate { get; set; }


		[Display(Name = "Ośrodek kliniczny")]
		public int ClinicalCenterId { get; set; }


		[Display(Name = "Rozpoznanie kliniczne")]
		public string? ClinicalDiagnose { get; set; }


		[Display(Name = "Niewydolność wątroby")]
		public bool HasLiverFailure { get; set; }


		[Display(Name = "Masa ciała")]
		[Column(TypeName = "decimal(6, 2)")]
		public decimal Weight { get; set; }


		[Display(Name = "Wzrost")]
		[Column(TypeName = "decimal(6, 2)")]
		public decimal Height { get; set; }


		[Display(Name = "Data zgonu")]
		public DateTime? DateOfDeath { get; set; }


		[Display(Name = "BSA")]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal BSA { get; set; }


		[Display(Name = "Uwagi")]
		public string? Remarks { get; set; }
	}
}
