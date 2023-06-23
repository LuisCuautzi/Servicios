using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Gen06_Rutas.Util
{
    public class Enumeradores
    {
        public enum Tipo
        {
            Trailer,
            Torton,
            [Description("Doble Remolque")]
            Doble_Remolque,
            Volteo,
            [Description("Semi Remolque")]
            Semi_Remolque
        }
        public enum Marca
        {
            Volvo,
            Alliance,
            Ford,
            [Description("Mercedes Benz")]
            Mercedes,
            Dina
        }


    }
}