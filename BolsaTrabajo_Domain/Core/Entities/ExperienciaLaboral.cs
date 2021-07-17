using System;
using System.Collections.Generic;

#nullable disable

namespace BolsaTrabajo_Domain.Core.Entities
{ 
    public partial class ExperienciaLaboral
    {
        public ExperienciaLaboral()
        {
            HojaDeVida = new HashSet<HojaDeVida>();
        }

        public int IdExperiencia { get; set; }
        public string Puesto { get; set; }
        public string Organizacion { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<HojaDeVida> HojaDeVida { get; set; }
    }
}
