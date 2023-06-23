using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Descripción breve de ChoferesWS
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class ChoferesWS : System.Web.Services.WebService
{

    public ChoferesWS()
    {

        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hola a todos";
    }

    //Generar metodo web que reciba como argumento el id de un chofer y lo elimine por id
    [WebMethod]
    public String eliminarChofer(int ChoferId)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString);
        if(conn.State == ConnectionState.Open)
        {
            conn.Close();
        }

        SqlCommand cmd = new SqlCommand("Choferes_Eliminar", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@id", ChoferId);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        return "Chofer Eliminado Correctamente";
    }

    //Metodo web que inserte un chofer en la base de datos
    [WebMethod]
    public String insertarChofer(string nombre, string apPaterno, string apMaterno, string telefono, DateTime fechaNac, string licencia, string foto)
    {
        //ado.net
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString);

        if(conn.State == ConnectionState.Open)
        {
            conn.Close();
        }

        SqlCommand cmd = new SqlCommand("Choferes_Insertar", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        //List<SqlParameter> parametros = new List<SqlParameter>();
        //parametros.Add(new SqlParameter("@nombre", nombre));
        //parametros.Add(new SqlParameter("@ApPaterno", apPaterno));
        //parametros.Add(new SqlParameter("@ApMaterno", apMaterno));
        //parametros.Add(new SqlParameter("@Telefono", telefono));
        //parametros.Add(new SqlParameter("@FechaNacimiento", fechaNac));
        //parametros.Add(new SqlParameter("@Licencia", licencia));
        //parametros.Add(new SqlParameter("@UrlFoto", foto));
        cmd.Parameters.AddWithValue("@nombre", nombre);
        cmd.Parameters.AddWithValue("@ApPaterno", apPaterno);
        cmd.Parameters.AddWithValue("@ApMaterno", apMaterno);
        cmd.Parameters.AddWithValue("@Telefono", telefono);
        cmd.Parameters.AddWithValue("@FechaNacimiento", fechaNac);
        cmd.Parameters.AddWithValue("@Licencia", licencia);
        cmd.Parameters.AddWithValue("@UrlFoto", foto);
        //cmd.Parameters.Add(parametros);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        return "Chofer Insertado Correctamente";
    }

}
