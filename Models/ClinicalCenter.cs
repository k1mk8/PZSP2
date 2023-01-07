using System.ComponentModel.DataAnnotations;

namespace apka2.Models
{
	public class ClinicalCenter
	{
		public int Id { get; set; }

		
		[Display(Name = "Ulica")]
		public string? Street { get; set; }


		[Display(Name = "Numer budynku")]
		public int BuildingNumber { get; set; }


		[Display(Name = "Numer lokalu")]
		public int? LocalNumber { get; set; }


		[Display(Name = "Miejscowosc")]
		public string? City { get; set; }


		[Display(Name = "Kod pocztowy")]
		public string? PostalCode { get; set; }


		[Display(Name = "Opis")]
		public string? CenterDescription { get; set; }
	}

}
