using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace CapaNegocio
{
    public class BllCamiones
    {
        //Listar Camiones
        public static List<CamionesVO> GetLstCamiones(bool? paramDisponibilidad)
        {
            return DalCamiones.GetLstCamiones(paramDisponibilidad);
        }
        //Insertar
        public static void InsCamion(string paramMatricula, string paramTipoCamion, int paramModelo, string paramMarca,
            int paramCapacidad, float paramKilometraje, string paramUrlFoto)
        {
            try
            {
                DalCamiones.InsCamion(paramMatricula, paramTipoCamion, paramModelo, paramMarca, paramCapacidad, paramKilometraje, paramUrlFoto);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        //Actualizar
        public static void UpdCamiones(int paramIdCamion, string paramMatricula, string paramTipoCamion, int paramModelo,
            string paramMarca, int paramCapacidad, float paramKilometraje, string paramUrlFoto, bool? paramDisponibilidad)
        {
            DalCamiones.UpdCamiones(paramIdCamion, paramMatricula, paramTipoCamion, paramModelo, paramMarca, paramCapacidad, paramKilometraje, paramUrlFoto, paramDisponibilidad);
        }

        //Eliminar
        public static string DelCamion(int paramIdCamion)
        {
            try
            {
                //Verificar la disponibilidad del chofer
                CamionesVO Camion = DalCamiones.GetCamionesById(paramIdCamion);
                if (Camion.Disponibilidad)
                {
                    DalCamiones.DelCamiones(paramIdCamion);
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
        public static CamionesVO GetCamionesById(int paramIdCamion)
        {
            return DalCamiones.GetCamionesById(paramIdCamion);
        }

    }
}
