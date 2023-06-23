using CapaNegocio;
using Gen06_Rutas.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Gen06_Rutas.Catalogos.Choferes
{
    public partial class AltaChoferes : System.Web.UI.Page
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
                        Server.MapPath("~/Imagenes/Choferes/");
                    if (!Directory.Exists(pathDir))
                    {
                        //crea el arbol completo
                        Directory.CreateDirectory(pathDir);
                    }

                    //Guardamos la imagen en el directorio correspondiente
                    SubeImagen.PostedFile.SaveAs(pathDir + FileName);
                    string urlfoto = "/Imagenes/Choferes/" + FileName;
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
                string nombre = this.txtNombre.Text;
                string apPaterno = this.txtApPaterno.Text;
                string apMaterno = this.txtApMaterno.Text;
                string telefono = this.txtTelefono.Text;
                DateTime fNacimiento = DateTime.Parse(this.txtFechaNacimiento.Text);
                string licencia = this.txtLicencia.Text;
                string urlFoto = this.urlFoto.Text;
                BllChoferes.InsChofer(licencia, telefono, fNacimiento, nombre, apPaterno, apMaterno, urlFoto);


                //consumir web service 
                ReferenciaMiServicioWeb.ChoferesWSSoapClient obl = new ReferenciaMiServicioWeb.ChoferesWSSoapClient();

                obl.insertarChofer(nombre , apPaterno, apMaterno, telefono,
                    fNacimiento, licencia, urlFoto);

                Util.UtilControls.SweetBoxConfirm("Extito!", "Chofer agregado exitosamente", "success",
                    "/Catalogos/Choferes/ListaChoferes.aspx", this.Page, this.GetType());

            }
            catch (Exception ex)
            {
                UtilControls.SweetBox("Error!", ex.ToString(), "Error", this.Page, this.GetType());

            }

        }
    }
}