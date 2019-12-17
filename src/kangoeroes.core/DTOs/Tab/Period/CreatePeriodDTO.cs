using System;
using System.ComponentModel.DataAnnotations;

namespace kangoeroes.core.DTOs.Tab.Period
{
    public class CreatePeriodDTO
    {
        [Required(ErrorMessage = "Naam is verplicht.")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Startdatum is verplicht.")]
        public DateTime Start { get; set; }
        
        [Required(ErrorMessage = "Einddatum is verplicht.")]
        public DateTime End { get; set; }
    }
}