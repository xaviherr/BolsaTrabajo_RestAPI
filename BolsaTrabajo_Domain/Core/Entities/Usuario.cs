using System;
using System.Collections.Generic;

#nullable disable

namespace BolsaTrabajo_Domain.Core.Entities
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
    }
}
