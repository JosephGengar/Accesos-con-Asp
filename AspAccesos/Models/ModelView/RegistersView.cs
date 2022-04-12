using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspAccesos.Models.ModelView
{
    public class RegistersView
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string Entidad { get; set; }
    }
}