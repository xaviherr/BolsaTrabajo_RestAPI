using System;
using System.Collections.Generic;

#nullable disable

namespace BolsaTrabajo_Domain.Core.Entities
{
    public partial class Capacitacion
    {
        public Capacitacion()
        {
            HojaDeVida = new HashSet<HojaDeVida>();
        }

        public int IdCapacitacion { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }

        public virtual ICollection<HojaDeVida> HojaDeVida { get; set; }
    }
}
