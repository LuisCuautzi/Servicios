<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarCamiones.aspx.cs" Inherits="Gen06_Rutas.Catalogos.Camiones.EditarCamiones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row">
            <h3>Editar Camiones</h3>
            <h3>Editando Camiones con id de Camion:
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label></h3>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <div class="form-group">

                <asp:Label ID="lblIdCamion" runat="server" Text=""></asp:Label>

                <asp:Label ID="lblMatricula" runat="server">Matricula</asp:Label>
                <asp:TextBox ID="txtMatricula" runat="server" placeholder="x-00000" MaxLength="7" CssClass="form-control" />

                <asp:Label ID="lblTipoCamion" runat="server">Tipo Camion</asp:Label>
                <asp:TextBox ID="txtTipoCamion" runat="server" placeholder="x-00000" MaxLength="10" CssClass="form-control" />

                <asp:Label ID="lblModelo" runat="server">Modelo</asp:Label>
                <asp:TextBox ID="txtModelo" runat="server" placeholder="" MaxLength="10" CssClass=" form-control" />

                <asp:Label ID="lblMarca" runat="server">Marca</asp:Label>
                <asp:TextBox ID="txtMarca" runat="server" placeholder="" MaxLength="10" CssClass=" form-control" />

                <asp:Label ID="lblCapacidad" runat="server">Capacidad</asp:Label>
                <asp:TextBox ID="txtCapacidad" runat="server" placeholder="" MaxLength="10" CssClass="form-control" />

                <asp:Label ID="lblKilometraje" runat="server">Kilometraje</asp:Label>
                <asp:TextBox ID="txtKilometraje" runat="server" placeholder="KM" MaxLength="10" CssClass="form-control" />

                <asp:Label ID="lblDisponibilidad" runat="server">Disponibilidad</asp:Label>
                <asp:CheckBox ID="chkDisponibilidad" runat="server" />

                <asp:Label ID="lblSubeImagen" runat="server">Seleccionar Foto</asp:Label>
                <input type="file" id="SubeImagen" runat="server" class="btn btn-file" />

                <asp:Button ID="btnSubeImagen" CssClass="btn btn-primary" Text="Subir" runat="server" OnClick="btnSubeImagen_Click" />

                <asp:Label ID="lblFoto" runat="server">Foto</asp:Label>
                <asp:Image ID="imgFotoChofer" Width="150" Height="100" runat="server" />
                <asp:Image ID="imgFoto" Width="100" Height="100" runat="server" />
                <asp:Label ID="urlFoto" runat="server">Aquí debe aparecer el path de la foto que seleccionaste
                </asp:Label>

                <asp:Button ID="btnGuardar" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
            </div>
        </div>
    </div>


</asp:Content>
