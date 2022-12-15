using System.ComponentModel.DataAnnotations;

namespace apka2.Models
{
    public class DoctorApplication
    {
        public int Id { get; set; }


        [Display(Name = "Imię")]
        public string Name { get; set; }


        [Display(Name = "Drugie imię")]
        public string? SecondName { get; set; }


        [Display(Name = "Nazwisko")]
        public string Surname { get; set; }


        [Display(Name = "Nazwa użytkownika")]
        [Required(ErrorMessage = "Proszę podać login", AllowEmptyStrings = false)]
        public string Username { get; set; }


        [Display(Name = "Hasło")]
        [Required(ErrorMessage = "Proszę podać hasło", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
