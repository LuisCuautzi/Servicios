<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaCamiones.aspx.cs" Inherits="Gen06_Rutas.Catalogos.Camiones.AltaCamiones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h3>Alta de Camion</h3>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="form-group">
                    <asp:Label ID="lblMatricula" runat="server" Text="Matricula"></asp:Label>
                    <asp:TextBox ID="txtMatricula" runat="server" placeholder="Matricula" MaxLength="50"
                        CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtMatricula" ControlToValidate="txtMatricula"
                        CssClass="text-danger" runat="server"
                        ErrorMessage="Matricula de Camion requerido"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="col-md-12">
                <div class="form-group">
                    <asp:Label ID="lblTipoCamion" runat="server" Text="Tipo Camion"></asp:Label>
                    <asp:TextBox ID="txtTipoCamion" runat="server" placeholder="Tipo Camion" MaxLength="150"
                        CssClass="form-control">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtTipoCamion"
                        CssClass="text-danger" runat="server" ErrorMessage="Tipo de Camion requerido">
                    </asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="col-md-12">
                <div class="form-group">
                    <asp:Label ID="lblModelo" runat="server" Text="Modelo"></asp:Label>
                    <asp:TextBox ID="txtModelo" runat="server" placeholder="Modelo" MaxLength="150"
                        CssClass="form-control">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtModelo"
                        CssClass="text-danger"
                        runat="server" ErrorMessage="Modelo del Camion requerido"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="col-md-12">
                <div class="form-group">
                    <asp:Label ID="lblMarca" runat="server" Text="Marca"></asp:Label>
                    <asp:TextBox ID="txtMarca" runat="server" placeholder="X-00000" MaxLength="7"
                        CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtMarca" ControlToValidate="txtMarca"
                        CssClass="text-danger" runat="server"
                        ErrorMessage="Marca del Camion requerido"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="col-md-12">
                <div class="form-group">
                    <asp:Label ID="lblCapacidad" runat="server" Text="Capacidad"></asp:Label>
                    <asp:TextBox ID="txtCapacidad" runat="server" placeholder="Capacidad" MaxLength="10"
                        CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-12">
                <div class="form-group">
                    <asp:Label ID="lblKilometraje" runat="server" Text="Kilometraje"></asp:Label>
                    <asp:TextBox ID="txtKilometraje" runat="server" placeholder="km" MaxLength="10"
                        CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-12">
                <div class="form-group">

                    <asp:Label ID="lblSubirImagen" runat="server" Text="Seleccionar Foto"></asp:Label>
                    <div class="row">
                        <div class="col-md-3">
                            <input type="file" id="SubeImagen" runat="server" class="btn btn-file" />
                        </div>
                        <div class="col-md-9">
                            <asp:Button ID="btnSubeImagen" CssClass="btn btn-primary" Text="Subir" runat="server" OnClick="btnSubeImagen_Click"
                                />
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-12">
                <div class="form-group">
                    <asp:Label ID="lblFoto" runat="server">Foto</asp:Label>
                    <asp:Image ID="imgFotoChofer" Width="150" Height="100" runat="server" />
                    <asp:Label ID="urlFoto" runat="server">Aquí aparece el path de la foto que seleccionaste
                    </asp:Label>
                </div>
            </div>
            <div class="col-md-12 col-md-offset-5">
                <div class="form-group">
                    <asp:Button ID="btnGuardar" Visible="false" CssClass="btn btn-primary" runat="server"
                        Text="Guardar" OnClick="btnGuardar_Click" />
                </div>
            </div>
        </div>
    </div>


</asp:Content>
