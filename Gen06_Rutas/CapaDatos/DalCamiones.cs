using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace CapaDatos
{
    public class DalCamiones
    {
        //Listar Camiones
        public static List<CamionesVO> GetLstCamiones(bool? paramDisponibilidad)
        {
            try
            {
                //Declaramos un DataSet
                DataSet dsCamiones;

                ////Verificar la disponibilidad 
                if (paramDisponibilidad == null)
                {
                    //    //Obtenemos todos los Camiones de la BD
                    dsCamiones = MetodoDatos.ExecuteDataSet("Camiones_Listar");
                }
                else
                {
                    //Obtenemos los camiones según paramDisponibilidad
                    dsCamiones = MetodoDatos.ExecuteDataSet("Camiones_Listar", "@Disponibilidad", paramDisponibilidad);
                }

                //Declaramos la lista a retornar
                List<CamionesVO> ListaCamiones = new List<CamionesVO>();

                //Recorremos el DataSet para llenar la lista
                foreach (DataRow dr in dsCamiones.Tables[0].Rows)
                {
                    ListaCamiones.Add(new CamionesVO(dr));
                }

                return ListaCamiones;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Insertar
        public static void InsCamion(string paramMatricula, string paramTipoCamion, int paramModelo, string paramMarca, int paramCapacidad, float paramKilometraje, string paramUrlFoto)
        {
            try
            {
                int intResult;

                intResult = MetodoDatos.ExecuteNonQuery("Camiones_Insertar",
                    "@Matricula", paramMatricula,
                    "@TipoCamion", paramTipoCamion,
                    "@Modelo", paramModelo,
                    "@Marca", paramMarca,
                    "@Capacidad", paramCapacidad,
                    "@Kilometraje", paramKilometraje,
                    "@UrlFoto", paramUrlFoto);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Actualizar
        public static void UpdCamiones(int paramIdCamion, string paramMatricula, string paramTipoCamion, int paramModelo, string paramMarca, int paramCapacidad, float paramKilometraje, string paramUrlFoto, bool? paramDisponibilidad)
        {
            try
            {
                MetodoDatos.ExecuteNonQuery("Camiones_Actualizar",
                    "@id", paramIdCamion,
                    "@Matricula", paramMatricula,
                    "@TipoCamion", paramTipoCamion,
                    "@Modelo", paramModelo,
                    "@Marca", paramMarca,
                    "@Capacidad", paramCapacidad,
                    "@Kilometraje", paramKilometraje,
                    "@UrlFoto", paramUrlFoto,
                    "@Disponibilidad", paramDisponibilidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Eliminar
        public static void DelCamiones(int paramIdCamion)
        {
            try
            {
                MetodoDatos.ExecuteNonQuery("Camiones_Eliminar", "@id", paramIdCamion);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static CamionesVO GetCamionesById(int paramIdCamion) 
        {
            try
            {
                DataSet dsCamiones = MetodoDatos.ExecuteDataSet("Camiones_GetByID", "@id", paramIdCamion);
                if (dsCamiones.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = dsCamiones.Tables[0].Rows[0];
                    CamionesVO Chofer = new CamionesVO(dr);
                    return Chofer;
                }
                else
                {
                    CamionesVO Camion = new CamionesVO();
                    return Camion;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
