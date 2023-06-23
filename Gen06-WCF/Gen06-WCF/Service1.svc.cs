using Gen06_WCF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Gen06_WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        public AerolineasContext _contexto = new AerolineasContext();
        public void DoWork()
        {
        }

        public void eliminarAerolinea(int id)
        {
            _contexto.Aerolineas.Remove(_contexto.Aerolineas.FirstOrDefault(a => a.Id == id));  
            _contexto.SaveChanges();
            //throw new NotImplementedException();
        }

        public void insertarAerolinea(Aerolineas a)
        {
            _contexto.Aerolineas.Add(a);
            _contexto.SaveChanges();
            //throw new NotImplementedException();
        }
    }
}
