using System;
using System.Collections.Generic;

namespace AspAccesos.Models
{
    public partial class TUsuarios
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string Entidad { get; set; }
        public int IdEstado { get; set; }

        public virtual TEstado IdEstadoNavigation { get; set; }
    }
}
