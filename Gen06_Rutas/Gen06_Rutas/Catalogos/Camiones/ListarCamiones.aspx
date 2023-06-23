<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListarCamiones.aspx.cs" Inherits="Gen06_Rutas.Catalogos.Camiones.ListarCamiones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <h3>LISTA DE CAMIONES</h3>
            <asp:GridView ID="GVCamiones" 
                          runat="server"
                 CssClass="table table-bordered table-striped table-condensed"
                 AutoGenerateColumns="False"
                 DataKeyNames="Id"
                  OnRowDeleting="GVCamiones_RowDeleting"
                     OnRowCommand="GVCamiones_RowCommand"
                 OnRowEditing="GVCamiones_RowEditing"
                OnRowUpdating="GVCamiones_RowUpdating"
                 OnRowCancelingEdit="GVCamiones_RowCancelingEdit"
                >
                <Columns>
                    <asp:ButtonField 
                            ButtonType="Button" 
                            CommandName="Select" 
                            HeaderText="1" 
                            ShowHeader="True" 
                            Text="Seleccionar" 
                            ControlStyle-CssClass="btn btn-success btn-xs"/>
                    <asp:CommandField 
                            ButtonType="Button" 
                            HeaderText="2" 
                            ShowDeleteButton="True" 
                            ShowHeader="True"
                            ControlStyle-CssClass="btn btn-success btn-xs"/>
                    <asp:CommandField 
                            ButtonType="Button" 
                            HeaderText="3" 
                            ShowEditButton="True" 
                            ShowHeader="True" 
                            ControlStyle-CssClass="btn btn-success btn-xs"/>
                        <asp:ImageField 
                            HeaderText="Foto" 
                            ReadOnly="True"
                            ItemStyle-Width="120px"
                            ControlStyle-Width="120px"
                            ControlStyle-Height="90px"
                            DataImageUrlField="URLFoto">
                        </asp:ImageField>
                        <asp:BoundField 
                            DataField="Id" 
                            HeaderText="Camiones" 
                            ItemStyle-Width="50px"
                            ReadOnly="true"/>
                    <asp:BoundField 
                            DataField="Matricula" 
                            HeaderText="Matricula" 
                            ItemStyle-Width="50px"
                            SortExpression="Matricula" />
                    <asp:BoundField 
                            DataField="TipoCamion" 
                            HeaderText="Tipo Camion" 
                            ItemStyle-Width="50px"
                            SortExpression="TipoCamion" />
                        <asp:BoundField 
                            DataField="Modelo" 
                            HeaderText="Modelo"
                            ItemStyle-Width="50px"
                            SortExpression="Modelo" />
                    <asp:BoundField 
                            DataField="Capacidad" 
                            HeaderText="Capacidad" 
                            SortExpression="Capacidad"
                            ItemStyle-Width="50px"/>
                     <asp:BoundField 
                            DataField="Kilometraje" 
                            HeaderText="Kilometraje" 
                            SortExpression="Kilometraje"
                            ItemStyle-Width="50px"/>
                     <asp:TemplateField HeaderText="Disponible" ItemStyle-Width="50px">
                             <ItemTemplate>
                                <div style="width: 100%">
                                    <div style="width: 25%; margin: 0 auto;">
                                        <asp:CheckBox ID="ChkDisponible" runat="server"
                                            Checked='<%#Eval("Disponibilidad")%>'
                                            Enabled="false" />
                                    </div>
                                </div>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <div style="width: 100%">
                                    <div style="width: 25%; margin: 0 auto;">
                                        <asp:CheckBox ID="ChkEditDisponible" runat="server"
                                            Checked='<%#Eval("Disponibilidad")%>' />
                                    </div>
                                </div>
                            </EditItemTemplate>
                        </asp:TemplateField>
                </Columns>

            </asp:GridView>
        </div>
    </div>


</asp:Content>
