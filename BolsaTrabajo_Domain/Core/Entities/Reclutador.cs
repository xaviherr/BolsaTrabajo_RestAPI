using System;
using System.Collections.Generic;

#nullable disable

namespace BolsaTrabajo_Domain.Core.Entities
{
    public partial class Reclutador
    {
        public Reclutador()
        {
            Oferta = new HashSet<Oferta>();
        }

        public int Dni { get; set; }
        public int? Ruc { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }

        public virtual Organizacion RucNavigation { get; set; }
        public virtual ICollection<Oferta> Oferta { get; set; }
    }
}
