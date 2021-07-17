using System;
using System.Collections.Generic;

#nullable disable

namespace BolsaTrabajo_Domain.Core.Entities
{ 
    public partial class HojaDeVida
    {
        public int IdHojavida { get; set; }
        public int? IdExperiencia { get; set; }
        public int? IdReferencia { get; set; }
        public int? IdCapacitacion { get; set; }
        public int? Dni { get; set; }

        public virtual Postulante DniNavigation { get; set; }
        public virtual Capacitacion IdCapacitacionNavigation { get; set; }
        public virtual ExperienciaLaboral IdExperienciaNavigation { get; set; }
        public virtual ReferenciaLaboral IdReferenciaNavigation { get; set; }
    }
}
