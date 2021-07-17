using System;
using System.Collections.Generic;

#nullable disable

namespace BolsaTrabajo_Domain.Core.Entities
{
    public partial class Postulante
    {
        public Postulante()
        {
            HojaDeVida = new HashSet<HojaDeVida>();
            Postulacion = new HashSet<Postulacion>();
        }

        public int Dni { get; set; }
        public int? IdLocalidad { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime? FechaNac { get; set; }

        public virtual Localidad IdLocalidadNavigation { get; set; }
        public virtual ICollection<HojaDeVida> HojaDeVida { get; set; }
        public virtual ICollection<Postulacion> Postulacion { get; set; }
    }
}
