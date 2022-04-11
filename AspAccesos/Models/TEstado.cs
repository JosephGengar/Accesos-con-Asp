using System;
using System.Collections.Generic;

namespace AspAccesos.Models
{
    public partial class TEstado
    {
        public TEstado()
        {
            TUsuarios = new HashSet<TUsuarios>();
        }

        public int Id { get; set; }
        public string Estado { get; set; }

        public virtual ICollection<TUsuarios> TUsuarios { get; set; }
    }
}
