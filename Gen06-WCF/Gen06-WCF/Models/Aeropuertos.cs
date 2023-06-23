using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Gen06_WCF.Models
{
    public partial class Aeropuertos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Iata { get; set; }
        public string Icao { get; set; }
        public string Latitud { get; set; }
        public string Longuitud { get; set; }
        public string ZonaHoraria { get; set; }
        public string Terminal { get; set; }
        public string Pais { get; set; }
    }
}
