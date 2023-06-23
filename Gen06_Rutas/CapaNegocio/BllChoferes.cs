using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace CapaNegocio
{
    public class BllChoferes
    {
        //Listar Choferes
        public static List<ChoferesVo> GetLstChoferes(bool? paramDisponibilidad)
        {
            return DalChoferes.GetLstChoferes(paramDisponibilidad);
        }
        //Insertar
        public static void InsChofer(string paramLicencia, string paramTelefono, DateTime paramFechaNacimiento, string paramNombre,
            string paramApPaterno, string paramApMaterno, string paramUrlFoto)
        {
            try
            {
                DalChoferes.InsChofer(paramLicencia, paramTelefono, paramFechaNacimiento, paramNombre, paramApPaterno, paramApMaterno, paramUrlFoto);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        //Actualizar
        public static void UpdChofer(int paramIdChofer, string paramLicencia, string paramTelefono, DateTime? paramFechaNacimiento,
            string paramNombre, string paramApPaterno, string paramApMaterno, string paramUrlFoto, bool? paramDisponibilidad)
        {
            DalChoferes.UpdChofer(paramIdChofer, paramLicencia, paramTelefono, paramFechaNacimiento, paramNombre, paramApPaterno, paramApMaterno, paramUrlFoto, paramDisponibilidad);
        }

        //Eliminar
        public static string DelChofer(int paramIdChofer)
        {
            try
            {
                //Verificar la disponibilidad del chofer
                ChoferesVo Chofer = DalChoferes.GetChoferById(paramIdChofer);
                if (Chofer.Disponibilidad)
                {
                    DalChoferes.DelChofer(paramIdChofer);
                    return "1";
                }
                else
                {
                    return "0";
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //GetByID
        public static ChoferesVo GetChoferById(int paramIdChofer)
        {
            return DalChoferes.GetChoferById(paramIdChofer);
        }


    }
}
