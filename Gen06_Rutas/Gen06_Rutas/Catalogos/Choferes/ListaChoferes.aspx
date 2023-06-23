<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaChoferes.aspx.cs" Inherits="Gen06_Rutas.Catalogos.Choferes.ListaChoferes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <%--    pintamos una tabla con el elemento GridView(de inicio va a estar vacia)--%>
    <div class="container">
        <div class="row">
            <h3>LISTA DE CHOFERES</h3>
            <asp:GridView ID="GVChoferes" 
                          runat="server"
                 CssClass="table table-bordered table-striped table-condensed"
                 AutoGenerateColumns="False"
                 DataKeyNames="Id"
                  OnRowDeleting="GVChoferes_RowDeleting"
                     OnRowCommand="GVChoferes_RowCommand"
                 OnRowEditing="GVChoferes_RowEditing"
                OnRowUpdating="GVChoferes_RowUpdating"
                 OnRowCancelingEdit="GVChoferes_RowCancelingEdit"
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
                            HeaderText="Chofer" 
                            ItemStyle-Width="50px"
                            ReadOnly="true"/>
                    <asp:BoundField 
                            DataField="Nombre" 
                            HeaderText="Nombre" 
                            ItemStyle-Width="50px"
                            SortExpression="Nombre" />
                    <asp:BoundField 
                            DataField="ApPaterno" 
                            HeaderText="Apellido Paterno" 
                            ItemStyle-Width="50px"
                            SortExpression="ApPaterno" />
                        <asp:BoundField 
                            DataField="ApMaterno" 
                            HeaderText="Apellido Materno"
                            ItemStyle-Width="50px"
                            SortExpression="ApMaterno" />
                    <asp:BoundField 
                            DataField="Licencia" 
                            HeaderText="Licencia" 
                            SortExpression="Licencia"
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
