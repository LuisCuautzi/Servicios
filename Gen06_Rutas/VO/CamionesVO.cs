using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class CamionesVO
    {
        private int _Id;
        private string _Matricula;
        private string _TipoCamion;
        private int _Modelo;
        private string _Marca;
        private int _Capacidad;
        private float _Kilometraje;
        private string _UrlFoto;
        private bool _Disponibilidad;

        public int Id { get => _Id; set => _Id = value; }
        public string Matricula { get => _Matricula; set => _Matricula = value; }
        public string TipoCamion { get => _TipoCamion; set => _TipoCamion = value; }
        public int Modelo { get => _Modelo; set => _Modelo = value; }
        public string Marca { get => _Marca; set => _Marca = value; }
        public int Capacidad { get => _Capacidad; set => _Capacidad = value; }
        public float Kilometraje { get => _Kilometraje; set => _Kilometraje = value; }
        public string UrlFoto { get => _UrlFoto; set => _UrlFoto = value; }
        public bool Disponibilidad { get => _Disponibilidad; set => _Disponibilidad = value; }

        public CamionesVO()
        {
            Id = 0;
            Matricula = String.Empty;
            TipoCamion = String.Empty;
            Modelo = 0;
            Marca = String.Empty;
            Capacidad = 0;
            Kilometraje = 0.0f;
            UrlFoto = String.Empty;
            Disponibilidad = false;
        }
        public CamionesVO(DataRow dr)
        {
            Id = int.Parse(dr["Id"].ToString());
            Matricula = dr["Matricula"].ToString();
            TipoCamion = dr["TipoCamion"].ToString();
            Modelo = int.Parse (dr["Modelo"].ToString());
            Marca = dr["Marca"].ToString();
            Capacidad = int.Parse(dr["Capacidad"].ToString());
            Kilometraje = float.Parse (dr["Kilometraje"].ToString());
            UrlFoto = dr["URLFoto"].ToString();
            Disponibilidad = bool.Parse(dr["Disponibilidad"].ToString());
        }

    }
}
