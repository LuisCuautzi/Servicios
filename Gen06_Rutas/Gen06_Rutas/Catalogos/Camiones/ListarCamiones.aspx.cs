using CapaNegocio;
using Gen06_Rutas.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gen06_Rutas.Catalogos.Camiones
{
    public partial class ListarCamiones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    RefrescaGrid();
                }
                catch (Exception ex)
                {
                    Util.UtilControls.SweetBox("ERROR!", ex.Message, "danger", this.Page, this.GetType());
                }
            }
        }

        public void RefrescaGrid()
        {
            
            GVCamiones.DataSource = CapaNegocio.BllCamiones.GetLstCamiones(true);

            GVCamiones.DataBind();

        }

        protected void GVCamiones_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string IdCamiones = GVCamiones.DataKeys[e.RowIndex].Values["Id"].ToString();
            string Resultado = BllCamiones.DelCamion(int.Parse(IdCamiones));
            string mensaje = "";
            string sub = "";
            string clase = "";

            switch (Resultado)
            {
                case "1":
                    mensaje = "Camion Eliminado con éxito";
                    sub = "";
                    clase = "success";
                    break;
                default:
                    mensaje = "Camion no puede ser eliminado";
                    sub = "Los Camion no pueden ser eliminados";
                    clase = "warning";
                    break;

            }
            UtilControls.SweetBox(mensaje, sub, clase, this.Page, this.GetType());
            RefrescaGrid();
        }

        protected void GVCamiones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //este boton va a redireccionar a un nuevo aspx llamado EditarChofer
            //por lo tanto hay que crearlo
            if (e.CommandName == "Select")
            {
                int index = int.Parse(e.CommandArgument.ToString());
                string IdCamiones = GVCamiones.DataKeys[index].Values["Id"].ToString();
                Response.Redirect("EditarCamion.aspx?Id=" + IdCamiones);
            }
        }

        protected void GVCamiones_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GVCamiones.EditIndex = e.NewEditIndex;
            RefrescaGrid();

        }

        protected void GVCamiones_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string Idcamiones = GVCamiones.DataKeys[e.RowIndex].Values["Id"].ToString();
            string Matricula = e.NewValues["Matricula"].ToString();
            string TipoCamion = e.NewValues["TipoCamion"].ToString();
            int Modelo = int.Parse(e.NewValues["Modelo"].ToString());
            string Marca = e.NewValues["Marca"].ToString();
            int Capacidad = int.Parse(e.NewValues["Capacidad"].ToString());
            float Kilometraje = float.Parse(e.NewValues["Kilometraje"].ToString());

            CheckBox ChkAux = (CheckBox)GVCamiones.Rows[e.RowIndex].FindControl("ChkEditDisponible");
            bool Disponibilidad = ChkAux.Checked;

            BllCamiones.UpdCamiones(int.Parse(Idcamiones), Matricula,TipoCamion, Modelo,Marca, Capacidad,Kilometraje, null, Disponibilidad);

            GVCamiones.EditIndex = -1;
            RefrescaGrid();
            UtilControls.SweetBox("Registro actualizado", "", "success", this.Page, this.GetType());
        }

        protected void GVCamiones_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GVCamiones.EditIndex = -1;
            RefrescaGrid();
        }

    }
}