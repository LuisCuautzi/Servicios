using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Gen06_WCF.Models
{
    public partial class Aviones
    {
        public int Id { get; set; }
        public string NumRegistro { get; set; }
        public string Tipo { get; set; }
        public string Modelo { get; set; }
        public string CodigoModelo { get; set; }
        public int Capacidad { get; set; }
        public DateTime FechaPrimerVuelo { get; set; }
        public int NumMotores { get; set; }
        public int Antiguedad { get; set; }
        public int Estatus { get; set; }
        public int AerolineaId { get; set; }

        public virtual Aerolineas Aerolinea { get; set; }
    }
}
