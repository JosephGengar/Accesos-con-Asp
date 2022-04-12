using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspAccesos.Models.ModelHtmlView
{
    public class AgregarRegistroView
    {
        [Required]
        [StringLength(100, ErrorMessage = "El {0} debe tener minimo {1} caracter/es"), MinLength(1)]
        [Display(Name = "Usuario")]
        public string usuario { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El {0} debe tener minimo {1} caracter/es"), MinLength(1)]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string contrasena { get; set; }

        [Required]
        [Compare("contrasena", ErrorMessage = "Las contraseñas deber ser iguales")]
        [Display(Name = "Confirmar Contraseña")]
        [DataType(DataType.Password)]
        public string contrasenaConfirm { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "la {0} debe contener al menos {1} caracter/es"), MinLength(1)]
        [Display(Name = "Entidad")]
        public string entidad { get; set; }
    }
}