using Microsoft.AspNetCore.Cors;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace apka.Models
{
	public class ClinicalCenter
	{
		public int Id { get; set; }


		[Display(Name = "Nazwa osrodka")]
		public string? CenterName { get; set; }


		[Display(Name = "Adres")]
		public string? CenterAddress { get; set;}


		[Display(Name = "Opis")]
		public string? CenterDescription { get; set; }
	}
}
