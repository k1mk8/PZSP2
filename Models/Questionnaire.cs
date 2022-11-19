using System.ComponentModel.DataAnnotations;

namespace apka.Models
{
	public class Questionnaire
	{
		public int Id { get; set; }


		[Display(Name ="Bezmocz")]
		public Boolean HasAnuria { get; set; }


		[Display(Name = "Skapomocz")]
		public Boolean HasOligura { get; set; }


		[Display(Name = "Nadcisnienie tetnicze")]
		public Boolean HasHypertension { get; set; }


		[Display(Name = "Przewodnienie")]
		public Boolean HasOverHydration { get; set; }


		[Display(Name = "Obecnosc AKI")]
		public Boolean HasAKI { get; set; }


		[Display(Name = "Kreatynina")]
		public Boolean HasCreatinine { get; set; }


		[Display(Name = "Mocznik")]
		public Boolean HasUrea { get; set; }


		[Display(Name = "Zaburzenia jonowe")]
		public Boolean HasIonicDisturbances { get; set; }


		[Display(Name = "Kwasica metaboliczna")]
		public Boolean HasMetabolicAcidosis { get; set; }


		[Display(Name = "Zatrucie egzogenne")]
		public Boolean HasExogenousPoisoning { get; set; }


		[Display(Name = "Wstrzas septyczny")]
		public Boolean HasSepticShock { get; set; }


		[Display(Name = "Zespol zmiazdzenia")]
		public Boolean HasCrushSyndrome { get; set; }


		[Display(Name = "Antykoagulacja")]
		public Boolean HasAnticoagulation { get; set; }


		[Display(Name = "Uwagi")]
		public string? Remarks { get; set; }
	}
}
