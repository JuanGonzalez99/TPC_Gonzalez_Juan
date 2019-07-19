<%@ Page Title="Comisiones" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Comisiones.aspx.cs" Inherits="PresentacionWeb.Comisiones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <h3>Listado de comisiones</h3>
    </div>

    <div id="divSinRegistros" runat="server" class="row" style="text-align:center; margin-bottom:50px;">
        <h3>
            Usted no posee comisiones asociadas.
        </h3>
    </div>

    <asp:GridView ID="dgvComisiones" runat="server" AutoGenerateColumns="false" CssClass="table"
        RowStyle-BackColor="#f2f2f2" AlternatingRowStyle-BackColor="#cccccc" HeaderStyle-BackColor="#222222" HeaderStyle-ForeColor="LightGray">
        <Columns>
            <asp:BoundField DataField="Id" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
            <asp:BoundField DataField="Materia" HeaderText="Materia" ItemStyle-Width="200px" />
            <asp:BoundField DataField="Año" HeaderText="Año" ItemStyle-Width="100px" />
            <asp:BoundField DataField="Cuatrimestre" HeaderText="Cuatrimestre" ItemStyle-Width="100px" />
            <asp:BoundField DataField="Turno" HeaderText="Turno" ItemStyle-Width="200px" />
            <asp:BoundField DataField="Modalidad" HeaderText="Modalidad" ItemStyle-Width="200px" />
            <asp:BoundField DataField="Profesor" HeaderText="Profesor" ItemStyle-Width="200px" />
            <asp:BoundField DataField="Ayudante" HeaderText="Ayudante" ItemStyle-Width="200px" />

            <asp:TemplateField HeaderText="Acción">
                <ItemTemplate>
                    <asp:Button ID="btnVisualizar" runat="server" CausesValidation="false" OnClick="btnVisualizar_Click" 
                        Text="Visualizar" Font-Size="Small" CssClass="btn btn-primary" />
                </ItemTemplate>
                <HeaderStyle Width="88px" />
            </asp:TemplateField>

        </Columns>
    </asp:GridView>

    <div style="text-align:center;">
        <asp:Button ID="btnVolver" runat="server" OnClick="btnVolver_Click" Text="Volver" CssClass="btn btn-success" />
    </div>

</asp:Content>
