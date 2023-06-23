using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class ChoferesVo
    {
        private int _Id;
        private string _Nombre;
        private string _ApPaterno;
        private string _ApMaterno;
        private string _Telefono;
        private DateTime _FechaNacimiento;
        private string _Licencia;
        private string _UrlFoto;
        private bool _Disponibilidad;

        public int Id { get => _Id; set => _Id = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string ApPaterno { get => _ApPaterno; set => _ApPaterno = value; }
        public string ApMaterno { get => _ApMaterno; set => _ApMaterno = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public DateTime FechaNacimiento { get => _FechaNacimiento; set => _FechaNacimiento = value; }
        public string Licencia { get => _Licencia; set => _Licencia = value; }
        public string UrlFoto { get => _UrlFoto; set => _UrlFoto = value; }
        public bool Disponibilidad { get => _Disponibilidad; set => _Disponibilidad = value; }

        public ChoferesVo()
        {
            Id = 0;
            Nombre = String.Empty;
            ApPaterno = String.Empty;
            ApMaterno = String.Empty;
            Telefono = String.Empty;
            FechaNacimiento = DateTime.Parse("1900-01-01");
            Licencia = String.Empty;
            UrlFoto = String.Empty;
            Disponibilidad = false;
        }
        public ChoferesVo(DataRow dr)
        {
            Id = int.Parse(dr["Id"].ToString());
            Nombre = dr["Nombre"].ToString();
            ApPaterno = dr["ApPaterno"].ToString();
            ApMaterno = dr["ApMaterno"].ToString();
            Telefono = dr["Telefono"].ToString();
            FechaNacimiento = DateTime.Parse(dr["FechaNacimiento"].ToString());
            Licencia = dr["Licencia"].ToString();
            UrlFoto = dr["URLFoto"].ToString();
            Disponibilidad = bool.Parse(dr["Disponibilidad"].ToString());
        }

    }
}
