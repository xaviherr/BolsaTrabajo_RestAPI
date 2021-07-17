using System;
using System.Collections.Generic;

#nullable disable

namespace BolsaTrabajo_Domain.Core.Entities
{
    public partial class Organizacion
    {
        public Organizacion()
        {
            Reclutador = new HashSet<Reclutador>();
        }

        public int Ruc { get; set; }
        public string RazonSocial { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }

        public virtual ICollection<Reclutador> Reclutador { get; set; }
    }
}
