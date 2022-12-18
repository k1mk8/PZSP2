using System.ComponentModel.DataAnnotations;

namespace apka2.Models
{
    public class Procedure
    {
        public int Id { get; set; }
        public int SurveyId { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data rozpoczęcia zabiegu")]
        public DateTime ProcedureDate { get; set; }

        [Display(Name = "ECMO")]
        public bool ECMO { get; set; }

        [Display(Name = "Filtr")]
        public string? Filter { get; set; }

        [Display(Name = "Czas trwania zabiegu [h]")]
        public decimal ProcedureTime { get; set; }


        // Zależnie od metody jedno z pól do ukrycia
        [Display(Name = "Metoda oczyszczania pozaustrojowego")]
        public string? ExtracorporealClearingMethod { get; set; }

        [Display(Name = "Koncentrat cytrynianów")]
        public string? CitrateConcentrate { get; set; }


        [Display(Name = "Nieplanowe zakończenie")]
        public bool UnplanedTermination { get; set; }

        [Display(Name = "Przyczyna zakończenia")]
        public string? TerminationReason { get; set; }

        [Display(Name = "Zwrot krwi")]
        public bool BloodReturn { get; set; }

        [Display(Name = "Zgon pacjenta")]
        public bool PatientDeath { get; set; }

        [Display(Name = "Data i godzina zgonu")]
        public DateTime DeathDate { get; set; }

        [Display(Name = "Uwagi")]
        public string? Remarks { get; set; }
    }
}
