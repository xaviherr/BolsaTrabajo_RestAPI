using System;
using System.Collections.Generic;

#nullable disable

namespace BolsaTrabajo_Domain.Core.Entities
{
    public partial class Localidad
    {
        public Localidad()
        {
            Oferta = new HashSet<Oferta>();
            Postulante = new HashSet<Postulante>();
        }

        public int IdLocalidad { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Oferta> Oferta { get; set; }
        public virtual ICollection<Postulante> Postulante { get; set; }
    }
}
