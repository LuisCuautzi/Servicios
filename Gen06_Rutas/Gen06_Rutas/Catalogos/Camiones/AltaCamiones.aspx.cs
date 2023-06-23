using CapaNegocio;
using Gen06_Rutas.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gen06_Rutas.Catalogos.Camiones
{
    public partial class AltaCamiones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubeImagen_Click(object sender, EventArgs e)
        {
            //Validar que el usuario haya seleccionado un archivo
            if (SubeImagen.Value != "")
            {
                //asignar a una variable el nombre del archivo seleccionado
                string FileName = Path.GetFileName(SubeImagen.PostedFile.FileName);
                //validar que el archivo sea .jpg o .png
                string FileExt = Path.GetExtension(FileName).ToLower();

                if ((FileExt != ".jpg") && (FileExt != ".png") && (FileExt != ".jfif"))
                {
                    //Informamos que el archivo no es válido
                    UtilControls.SweetBox(
                   "Error!", "Seleccione un archivo válido", "error", this.Page, this.GetType()
                   );
                }
                else
                {
                    //Verificar que el directorio donde vamos
                    //guardar el archivo exista
                    string pathDir =
                        Server.MapPath("~/Imagenes/Camiones/");
                    if (!Directory.Exists(pathDir))
                    {
                        //crea el arbol completo
                        Directory.CreateDirectory(pathDir);
                    }

                    //Guardamos la imagen en el directorio correspondiente
                    SubeImagen.PostedFile.SaveAs(pathDir + FileName);
                    string urlfoto = "/Imagenes/Camiones/" + FileName;
                    this.urlFoto.Text = urlfoto;
                    this.imgFotoChofer.ImageUrl = urlfoto;
                    this.btnGuardar.Visible = true;
                }
            }
            else
            {
                //Enviar mensaje de que no puede ser vacío
                UtilControls.SweetBox("Error!", "Seleccione un archivo válido", "error", this.Page, this.GetType());
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string matricula = this.txtMatricula.Text;
                string tipocamion = this.txtTipoCamion.Text;
                int modelo = int.Parse(this.txtModelo.Text);
                string marca = this.txtMarca.Text;
                int capacidad = int.Parse(this.txtCapacidad.Text);
                float kilometraje = float.Parse(this.txtKilometraje.Text);
                string urlFoto = this.urlFoto.Text;
                BllCamiones.InsCamion(matricula, tipocamion, modelo, marca, capacidad, kilometraje, urlFoto);
                Util.UtilControls.SweetBoxConfirm("Extito!", "Camion agregado exitosamente", "success",
                    "/Catalogos/Camiones/ListarCamiones.aspx", this.Page, this.GetType());

            }
            catch (Exception ex)
            {
                UtilControls.SweetBox("Error!", ex.ToString(), "Error", this.Page, this.GetType());

            }

        }
    }
}