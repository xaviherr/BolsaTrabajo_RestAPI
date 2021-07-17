using System;
using System.Collections.Generic;

#nullable disable

namespace BolsaTrabajo_Domain.Core.Entities
{
    public partial class Oferta
    {
        public Oferta()
        {
            Postulacion = new HashSet<Postulacion>();
        }

        public int IdOferta { get; set; }
        public int? IdLocalidad { get; set; }
        public int? Dni { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public decimal? Salario { get; set; }
        public DateTime? FechaPublicacion { get; set; }

        public virtual Reclutador DniNavigation { get; set; }
        public virtual Localidad IdLocalidadNavigation { get; set; }
        public virtual ICollection<Postulacion> Postulacion { get; set; }
    }
}
