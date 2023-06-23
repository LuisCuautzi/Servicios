using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Gen06_WCF.Models
{
    public partial class Aerolineas
    {
        public Aerolineas()
        {
            Aviones = new HashSet<Aviones>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Iata { get; set; }
        public int Status { get; set; }

        public virtual ICollection<Aviones> Aviones { get; set; }
    }
}
