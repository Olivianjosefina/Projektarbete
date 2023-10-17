using System;
using System.ComponentModel.DataAnnotations;

namespace Vinlista.Models
{
        public class LoginViewModel
        {
            [Required]
            [Display(Name = "Användarnamn")]
            public string AnvdandarNamn { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Lösenord")]
            public string Losenord { get; set; }
        }
}

