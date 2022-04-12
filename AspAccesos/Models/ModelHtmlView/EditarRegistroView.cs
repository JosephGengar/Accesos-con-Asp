using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspAccesos.Models.ModelHtmlView
{
    public class EditarRegistroView
    {
        public int id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "el {0} debe contener al menos {1} caracter/es"), MinLength(1)]
        [Display(Name = "Usuario")]
        public string usuario { get; set; }
 
        [StringLength(100, ErrorMessage = "la {0} debe tener al menos {1} caracter/es"), MinLength(1)]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string password { get; set; }
     
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "Las contraseñas deben ser iguales")]
        public string passwordConf { get; set; }

        [Required]
        [Display(Name = "Entidad")]
        public string entidad { get; set; }
    }
}