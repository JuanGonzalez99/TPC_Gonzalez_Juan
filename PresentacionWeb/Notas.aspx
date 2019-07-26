<%@ Page Title="Notas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Notas.aspx.cs" Inherits="PresentacionWeb.Notas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">

        $(document).ready(function () {
            $('#btnVolver').click(function (e) {
                e.preventDefault();
                
                window.location.replace("/MateriasEstudiante.aspx");
            });
        });

    </script>

    <div>
        <h3>Listado de notas</h3>
    </div>

    <div style="text-align:center; margin-top:20px; margin-bottom:20px; ">
        <asp:Label runat="server" ID="lblComision"></asp:Label>
    </div>

    <div id="divSinRegistros" runat="server" class="row" style="text-align:center; margin-bottom:50px;">
        <h3>
            Comisión sin instancias evaluativas asignadas.
        </h3>
    </div>

    <asp:GridView ID="dgvNotas" runat="server" AutoGenerateColumns="false" CssClass="table"
        RowStyle-BackColor="#f2f2f2" AlternatingRowStyle-BackColor="#cccccc" HeaderStyle-BackColor="#222222" HeaderStyle-ForeColor="LightGray">
        <Columns>
            <asp:BoundField DataField="Instancia.Id" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
            <asp:BoundField DataField="Instancia.Nombre" HeaderText="Instancia" />
            <asp:BoundField DataField="Instancia.Tipo" HeaderText="Tipo de calificación" />
            <asp:BoundField DataField="Nota" HeaderText="Nota" />
            <asp:BoundField DataField="Comentarios" HeaderText="Comentarios" />
        </Columns>
    </asp:GridView>

    <div style="text-align:center;">
        <button id="btnVolver" class="btn btn-success">Volver</button>
    </div>

</asp:Content>
