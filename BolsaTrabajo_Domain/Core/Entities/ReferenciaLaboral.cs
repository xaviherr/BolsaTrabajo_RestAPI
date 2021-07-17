using System;
using System.Collections.Generic;

#nullable disable

namespace BolsaTrabajo_Domain.Core.Entities
{
    public partial class ReferenciaLaboral
    {
        public ReferenciaLaboral()
        {
            HojaDeVida = new HashSet<HojaDeVida>();
        }

        public int IdReferencia { get; set; }
        public string Nombre { get; set; }
        public string Organizacion { get; set; }
        public string Puesto { get; set; }
        public string Correo { get; set; }
        public string Celular { get; set; }

        public virtual ICollection<HojaDeVida> HojaDeVida { get; set; }
    }
}
