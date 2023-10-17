using System.ComponentModel.DataAnnotations;

namespace Vinlista.Models
{
    public class Vin
    {
        public int VinID { get; set; }

        [Required]
        public string VinNamn { get; set; }

        public string VinTyp { get; set; }

        [Required]
        [Display(Name = "Årgång")]
        public int Argang { get; set; }

        public float AlkoholHalt { get; set; }

        public string Producent { get; set; }

        [Required]
        public string Land { get; set; }

        [Display(Name = "BildNamn")]
        public string BildNamn { get; set; }

        [Required]
        public string VinFarg { get; set; }

        [Required]
        public int Pris { get; set; }
    }
}
