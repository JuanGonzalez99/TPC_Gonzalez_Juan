<%@ Page Title="Alumnos por Comision" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AlumnosComision.aspx.cs" Inherits="PresentacionWeb.AlumnosComision" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div>
        <h3>Listado de alumnos </h3>
    </div>

    <div id="divSinRegistros" runat="server" class="row" style="text-align:center; margin-bottom:50px;">
        <h3>
            Comisión sin alumnos registrados.
        </h3>
    </div>

    <asp:GridView ID="dgvAlumnos" runat="server" AutoGenerateColumns="false" CssClass="table"
        RowStyle-BackColor="#f2f2f2" AlternatingRowStyle-BackColor="#cccccc" HeaderStyle-BackColor="#222222" HeaderStyle-ForeColor="LightGray">
        <Columns>
            <asp:BoundField DataField="Alumno.Id" HeaderText="Legajo" ItemStyle-Width="200px" />
            <asp:BoundField DataField="Alumno" HeaderText="Alumno" ItemStyle-Width="200px" />
            <asp:BoundField DataField="Alumno.DNI" HeaderText="DNI" ItemStyle-Width="200px" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" ItemStyle-Width="200px" />
            <asp:BoundField DataField="Nota" HeaderText="Nota" ItemStyle-Width="200px" />

            <%--<asp:TemplateField HeaderText="Acción">
                <ItemTemplate>
                    <asp:Button ID="btnVisualizar" runat="server" CausesValidation="false" OnClick="btnVisualizar_Click" 
                        Text="Visualizar" Font-Size="Small" CssClass="btn btn-primary" />
                </ItemTemplate>
                <HeaderStyle Width="88px" />
            </asp:TemplateField>--%>

        </Columns>
    </asp:GridView>

    <div style="text-align:center;">
        <asp:Button ID="btnVolver" runat="server" OnClick="btnVolver_Click" Text="Volver" CssClass="btn btn-success" />
    </div>

</asp:Content>
