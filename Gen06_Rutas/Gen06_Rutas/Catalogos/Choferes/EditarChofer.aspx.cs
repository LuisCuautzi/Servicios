using CapaNegocio;
using Gen06_Rutas.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VO;

namespace Gen06_Rutas.Catalogos.Choferes
{
    public partial class EditarChofer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Obtenemos el id del querystring
                if (Request.QueryString["Id"] == null)
                {
                    Response.Redirect("ListaChoferes.aspx");
                }
                else //Si traigo algo en el Id
                {
                    //Obtemenos el Id del Chofer
                    int IdChofer =
                        int.Parse(Request.QueryString["Id"]);
                    ChoferesVo Chofer =
                        BllChoferes.GetChoferById(IdChofer);
                    //Validar que el chofer es correcto
                    if (Chofer.Id == IdChofer)
                    {
                        //Desplegamos la información del chofer
                        this.lblIdChofer.Text = IdChofer.ToString();
                        this.txtLicencia.Text = Chofer.Licencia;
                        this.txtTelefono.Text = Chofer.Telefono;
                        this.txtFechaNacimiento.Text = Chofer.FechaNacimiento.ToString();
                        this.chkDisponibilidad.Checked = Chofer.Disponibilidad;
                        this.imgFotoChofer.ImageUrl = Chofer.UrlFoto;
                        this.urlFoto.Text = Chofer.UrlFoto;
                    }
                    else
                    {
                        Response.Redirect("Catalogos/Choferes/ListaChoferes.aspx");
                    }
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(lblIdChofer.Text);
                string telefono = txtTelefono.Text;
                DateTime fNacimiento = DateTime.Parse(this.txtFechaNacimiento.Text);
                string licencia = txtLicencia.Text;
                string urlfoto = urlFoto.Text;
                BllChoferes.UpdChofer(id, licencia, telefono, fNacimiento, null, null, null, urlfoto, null);
                UtilControls.SweetBoxConfirm("Exito!", "Chofer editado exitosamente", "success", "ListaChoferes.aspx", this.Page, this.GetType());
            }
            catch (Exception ex)
            {
                UtilControls.SweetBox(
                    "Error!", ex.ToString(), "error", this.Page, this.GetType()
                    );
            }
        }

        protected void btnSubeImagen_Click(object sender, EventArgs e)
        {
            //Validar que el usuario haya seleccionado un archivo
            if (SubeImagen.Value != "")
            {
                //asignar a una variable el nombre del archivo seleccionado
                string FileName =
                    Path.GetFileName(SubeImagen.PostedFile.FileName);
                //validar que el archivo sea .jpg o .png
                string FileExt =
                    Path.GetExtension(FileName).ToLower();

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
                    urlFoto.Text = urlfoto;
                    //imgFotoChofer.ImageUrl = urlfoto;
                    imgFoto.ImageUrl = urlfoto;
                    btnGuardar.Visible = true;
                }
            }
            else
            {
                //Enviar mensaje de que no puede ser vacío
                UtilControls.SweetBox("Error!", "Seleccione un archivo válido", "error", this.Page, this.GetType());
            }

        }
    }
}