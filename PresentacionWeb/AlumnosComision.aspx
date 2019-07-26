<%@ Page Title="Alumnos por Comision" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AlumnosComision.aspx.cs" Inherits="PresentacionWeb.AlumnosComision" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <script type="text/javascript">
        $(document).ready(function () {
            $('#btnInstancias').click(function (e) {
                e.preventDefault();
                window.location.replace("/InstanciasComision.aspx");
            });
        });
    </script>
    
    <div>
        <h3>Listado de alumnos </h3>
    </div>
    
    <div style="text-align:right; margin-bottom:20px;">

        <button id="btnInstancias" class="btn btn-default" style="margin-left:20px;" >
            Ver instancias
        </button>

    </div>

    <div id="divSinRegistros" runat="server" class="row" style="text-align:center; margin-bottom:50px;">
        <h3>
            Comisión sin alumnos registrados.
        </h3>
    </div>

    <asp:GridView ID="dgvAlumnos" runat="server" AutoGenerateColumns="false" CssClass="table"
        RowStyle-BackColor="#f2f2f2" AlternatingRowStyle-BackColor="#cccccc" HeaderStyle-BackColor="#222222" HeaderStyle-ForeColor="LightGray">
        <Columns>
            <asp:BoundField DataField="Alumno.Id" HeaderText="Legajo" />
            <asp:BoundField DataField="Alumno" HeaderText="Alumno" />
            <asp:BoundField DataField="Alumno.DNI" HeaderText="DNI" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" />
            <%--<asp:BoundField DataField="Nota" HeaderText="Nota final" />--%>

            <asp:TemplateField HeaderText="Acción">
                <ItemTemplate>
                    <asp:Button ID="btnNotas" runat="server" CausesValidation="false" OnClick="btnNotas_Click" 
                        Text="Notas" Font-Size="Smaller" CssClass="btn btn-link" />
                </ItemTemplate>
                <HeaderStyle Width="88px" />
            </asp:TemplateField>

        </Columns>
    </asp:GridView>

    <div style="text-align:center;">
        <asp:Button ID="btnVolver" runat="server" OnClick="btnVolver_Click" Text="Volver" CssClass="btn btn-success" />
    </div>

</asp:Content>
