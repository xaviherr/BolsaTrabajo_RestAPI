using System;
using System.Collections.Generic;

#nullable disable

namespace BolsaTrabajo_Domain.Core.Entities
{
    public partial class Postulacion
    {
        public int IdPostulacion { get; set; }
        public int? Dni { get; set; }
        public int? IdOferta { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual Postulante DniNavigation { get; set; }
        public virtual Oferta IdOfertaNavigation { get; set; }
    }
}
