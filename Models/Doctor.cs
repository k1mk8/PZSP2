using System.ComponentModel.DataAnnotations;

namespace apka2.Models
{
	public class Doctor
	{
		public int Id { get; set; }


		[Display(Name = "Imię")]
		public string Name { get; set; }


		[Display(Name = "Drugie imię")]
		public string? SecondName { get; set; }


		[Display(Name = "Nazwisko")]
		public string Surname { get; set; }


		[Display(Name = "Administrator")]
		public bool IsAdmin { get; set; }


		[Display(Name = "Zaakceptowany")]
		public bool IsAccepted { get; set; }


		[Display(Name = "Nazwa użytkownika")]
		[Required(ErrorMessage = "Proszę podać login", AllowEmptyStrings = false)]
		public string Username { get; set; }


		[Display(Name = "Hasło")]
		[Required(ErrorMessage = "Proszę podać hasło", AllowEmptyStrings = false)]
		[DataType(DataType.Password)]
		public string Password { get; set; }


		[Display(Name = "Adres e-mail")]
		[DataType(DataType.EmailAddress)]
		public string? EmailAddress { get; set; }


		[Display(Name = "Uwagi")]
		public string? Description { get; set; }
	}
}
