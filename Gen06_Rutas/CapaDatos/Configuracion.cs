using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    internal class Configuracion
    {
        //aca unicamente cambiamos nuestros servidor de bd y nuestra base de datos: 
        static string cadenaConexion = @"Data Source=DESKTOP-1L1MF13\SQLEXPRESS;Initial Catalog=Gen06_23RutasJ; Integrated Security=True";

        public static string CadenaConexion
        {
            get
            {
                return cadenaConexion;
            }
        }


    }
}
