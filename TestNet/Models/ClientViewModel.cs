using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestNet.Models
{
    public class ClientViewModel
    {
        public int id { get; set; }

        [Display(Name="Primer Nombre")]
        [Required(ErrorMessage ="El campo {0} es obligatorio.")]
        public string first_name { get; set; }

        [Display(Name = "Segundo Nombre")]
        public string second_name { get; set; }

        [Display(Name = "Primer Apellido")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string surname { get; set; }

        [Display(Name = "Segundo Apellido")]
        public string second_surname { get; set; }

        [Display(Name = "DPI")]
        [Required(ErrorMessage = "El DPI es obligatorio.")]
        public long dpi { get; set; }
    }
}