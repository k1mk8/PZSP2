using System.ComponentModel.DataAnnotations;

namespace apka2.Models
{
    public class ProcedureSession
    {
        public int Id { get; set; }
        public int ProcedureId { get; set; }
        public string? SessionType { get; set; }
        public bool Initial { get; set; }

        [Display(Name = "Data i godzina początku sesji zabiegu")]
        public DateTime? StartSessionDate { get; set; }

        // Dla heparyny niefrakcjonowanej, początek
        [Display(Name = "Heparyna - bolus początkowy [mg]")]
        public decimal? HeparinBolusDose { get; set; }

        // Tylko dla heparyny niefrakcjonowanej, kolejne
        [Display(Name = "ACT [s]")]
        public decimal? ACT { get; set; }

        
        // Dla heparyny niefrakcjonowanej
        [Display(Name = "Dawka heparyny [mg/h]")]
        public decimal? HeparinDose { get; set; }


        // Dla fraxaparyny
        [Display(Name = "Dawka fraxaparyny [mg/h]")]
        public decimal? FraxiparinDose { get; set; }

        [Display(Name = " Interwał czasowy podawania fraxaparyny")]
        public decimal? FraxiparinDosingTiming { get; set; }

        // Dla fraxaparyny, kolejne
        [Display(Name = "Anty-Xa")]
        public decimal? AntiXa { get; set; }


        // Dla cytrynianów, początek
        [Display(Name = "Stężenie cytrynianów [mmol/l]")]
        public decimal? CitratesConcentration { get; set; }

        [Display(Name = "Kompensacja wapnia [%]")]
        public decimal? CalciumCompensationPercent { get; set; }


        // Dla cytrynianów, kolejne
        [Display(Name = "Wapń zjonizowany [mg/dl lub mmol/l]")]
        public decimal? IonizedCalcium { get; set; }

        [Display(Name = "Wapń całkowity [mg/dl lub mmol/l]")]
        public decimal? TotalCalcium { get; set; }

        [Display(Name = "HCO3 [mmol/l]")]
        public decimal? HCO3 { get; set; }

        [Display(Name = "Cytrynian [mmol/l]")]
        public decimal? Citrate { get; set; }

        [Display(Name = "Kompensacja wapnia [mg/dl lub mmol/l]")]
        public decimal? CalciumCompensationMol { get; set; }


        // Dla wszystkich
        [Display(Name = "QB [mg/min]")]
        public decimal? QBDose { get; set; }

        [Display(Name = "QD [mg/h]")]
        public decimal? QDDose { get; set; }

        [Display(Name = "Predylucja [mg/h]")]
        public decimal? Predilution { get; set; }

        [Display(Name = "Postdylucja [mg/h]")]
        public decimal? Postdilution { get; set; }

        
        // Zależnie od czasu sesji
        [Display(Name = "UF [mg/h]")]
        public decimal? UFDose { get; set; }

        [Display(Name = "TMP [mmhg]")]
        public decimal? TMP { get; set; }


        

        
    }
}
