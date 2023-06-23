using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace CapaDatos
{
    public class DalChoferes
    {
        //Listar Choferes
        public static List<ChoferesVo> GetLstChoferes(bool? paramDisponibilidad)
        {
            try
            {
                //Declaramos un DataSet
                DataSet dsChoferes;

                ////Verificar la disponibilidad 
                if (paramDisponibilidad == null)
                {
                    //    //Obtenemos todos los Choferes de la BD
                    dsChoferes = MetodoDatos.ExecuteDataSet("Choferes_Listar");
                }
                else
                {
                    //Obtenemos los choferes según paramDisponibilidad
                    dsChoferes = MetodoDatos.ExecuteDataSet("Choferes_Listar", "@Disponibilidad", paramDisponibilidad);
                }

                //Declaramos la lista a retornar
                List<ChoferesVo> ListaChoferes = new List<ChoferesVo>();

                //Recorremos el DataSet para llenar la lista
                foreach (DataRow dr in dsChoferes.Tables[0].Rows)
                {
                    ListaChoferes.Add(new ChoferesVo(dr));
                }

                return ListaChoferes;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Insertar
        public static void InsChofer(string paramLicencia, string paramTelefono, DateTime paramFechaNacimiento, string paramNombre, string paramApPaterno, string paramApMaterno, string paramUrlFoto)
        {
            try
            {
                int intResult;

                intResult = MetodoDatos.ExecuteNonQuery("Choferes_Insertar",
                    "@Nombre", paramNombre,
                    "@ApPaterno", paramApPaterno,
                    "@ApMaterno", paramApMaterno,
                    "@Telefono", paramTelefono,
                    "@FechaNacimiento", paramFechaNacimiento,
                    "@Licencia", paramLicencia,
                    "@UrlFoto", paramUrlFoto);

                //consuminos nuestro web service para insertar el chofer

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Actualizar
        public static void UpdChofer(int paramIdChofer, string paramLicencia, string paramTelefono, DateTime? paramFechaNacimiento, string paramNombre, string paramApPaterno, string paramApMaterno, string paramUrlFoto, bool? paramDisponibilidad)
        {
            try
            {
                MetodoDatos.ExecuteNonQuery("actualizar_Choferes",
                    "@id", paramIdChofer,
                    "@Nombre", paramNombre,
                    "@ApPaterno", paramApPaterno,
                    "@ApMaterno", paramApMaterno,
                    "@Telefono", paramTelefono,
                    "@FechaNacimiento", paramFechaNacimiento,
                    "@Licencia", paramLicencia,
                    "@UrlFoto", paramUrlFoto,
                    "@Disponibilidad", paramDisponibilidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Eliminar
        public static void DelChofer(int paramIdChofer)
        {
            try
            {
                MetodoDatos.ExecuteNonQuery("Choferes_Eliminar", "@id", paramIdChofer);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static ChoferesVo GetChoferById(int paramIdChofer)
        {
            try
            {
                DataSet dsChofer = MetodoDatos.ExecuteDataSet("Choferes_GetByID", "@id", paramIdChofer);
                if (dsChofer.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = dsChofer.Tables[0].Rows[0];
                    ChoferesVo Chofer = new ChoferesVo(dr);
                    return Chofer;
                }
                else
                {
                    ChoferesVo Chofer = new ChoferesVo();
                    return Chofer;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
