using System.ComponentModel.DataAnnotations;
using System.Data;

namespace apka2.Models
{
    public class Servey
    {
        public int Id { get; set; }
        public int PatientId  { get; set; }
        public int DoctorId { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Data przeprowadzenia ankiety")]
        public DateTime ServeyDate { get; set; }


        [Display(Name = "ECMO")]
        public bool ECMO { get; set; }


        [Display(Name = "Bezmocz / skąpomocz")]
        public bool Anuria { get; set; }


        [Display(Name = "Nadciśnienie tętnicze")]
        public bool ArterialHypertension { get; set; }


        [Display(Name = "Przewodnienie")]
        public bool Overhydration { get; set; }


        [Display(Name = "Obecność AKI")]
        public bool AKI { get; set; }


        [Display(Name = "Kreatynina")]
        public decimal Creatinine { get; set; }


        [Display(Name = "Mocznik")]
        public decimal Urea { get; set; }


        [Display(Name = "Zaburzenia jonowe")]
        public bool IonDisorder { get; set; }


        [Display(Name = "Kwasica metaboliczna")]
        public bool MetabolicAcidosis { get; set; }


        [Display(Name = "Zatrucie egzogenne")]
        public bool ExogenousPoison { get; set; }


        [Display(Name = "Wstrząs septyczny")]
        public bool SepticShock { get; set; }


        [Display(Name = "Zespół zmiażdżenia")]
        public bool LowerNephroneSyndrom { get; set; }


        [Display(Name = "Antykoagulacja")]
        public string? Anticoagulation { get; set; }


        [Display(Name = "Rodzaj dostępu naczyniowego")]
        public string? TypeOfVascularAccess { get; set; }


        [Display(Name = "Grubość cewnika")]
        public decimal CatheterThickness { get; set; }


        [Display(Name = "Długość cewnika")]
        public int CatheterLength { get; set; }


        [Display(Name = "Miejsce założenia dostępu naczyniowego")]
        public string? VascularAccessSite { get; set; }
    }
}
