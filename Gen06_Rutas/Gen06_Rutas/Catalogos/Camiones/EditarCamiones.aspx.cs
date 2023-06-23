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

namespace Gen06_Rutas.Catalogos.Camiones
{
    public partial class EditarCamiones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Obtenemos el id del querystring
                if (Request.QueryString["Id"] == null)
                {
                    Response.Redirect("ListarCamiones.aspx");
                }
                else //Si traigo algo en el Id
                {
                    //Obtemenos el Id del Chofer
                    int IdCamion =
                        int.Parse(Request.QueryString["Id"]);
                    CamionesVO Camion =
                        BllCamiones.GetCamionesById(IdCamion);
                    //Validar que el chofer es correcto
                    if (Camion.Id == IdCamion)
                    {
                        //Desplegamos la información del chofer
                        this.lblIdCamion.Text = IdCamion.ToString();
                        this.txtMatricula.Text = Camion.Matricula;
                        this.txtTipoCamion.Text = Camion.TipoCamion;
                        this.txtModelo.Text = Camion.Modelo.ToString();
                        this.txtTipoCamion.Text = Camion.Marca;
                        this.txtCapacidad.Text = Camion.Capacidad.ToString();
                        this.txtKilometraje.Text = Camion.Kilometraje.ToString();
                        this.chkDisponibilidad.Checked = Camion.Disponibilidad;
                        this.imgFotoChofer.ImageUrl = Camion.UrlFoto;
                        this.urlFoto.Text = Camion.UrlFoto;
                    }
                    else
                    {
                        Response.Redirect("Catalogos/Camiones/ListarCamiones.aspx");
                    }
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(lblIdCamion.Text);
                string Matricula = txtMatricula.Text;
                string TipoCamion = txtTipoCamion.Text;
                int Modelo = int.Parse(txtModelo.Text);
                string Marca = txtMarca.Text;
                int Capacidad = int.Parse(txtCapacidad.Text);
                float Kilometraje = float.Parse(txtKilometraje.Text);
                string urlfoto = urlFoto.Text;
                BllCamiones.UpdCamiones(id, Matricula, TipoCamion, Modelo, Marca, Capacidad, Kilometraje, urlfoto, null);
                UtilControls.SweetBoxConfirm("Exito!", "Camion editado exitosamente", "success", "ListarCamiones.aspx", this.Page, this.GetType());
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
                        Server.MapPath("~/Imagenes/Camiones/");
                    if (!Directory.Exists(pathDir))
                    {
                        //crea el arbol completo
                        Directory.CreateDirectory(pathDir);
                    }

                    //Guardamos la imagen en el directorio correspondiente
                    SubeImagen.PostedFile.SaveAs(pathDir + FileName);
                    string urlfoto = "/Imagenes/Camiones/" + FileName;
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