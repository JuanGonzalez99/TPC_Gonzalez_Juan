<%@ Page Title="Instancias por Comision" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InstanciasComision.aspx.cs" Inherits="PresentacionWeb.InstanciasComision" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">
        $(document).ready(function () {

            $('#btnAlumnos').click(function (e) {
                e.preventDefault();
                window.location.replace("/AlumnosComision.aspx");
            });

            $('input[value="Borrar"]').on('click', function (e) {

                e.preventDefault();

                var row = $(this).closest('tr'),
                    cells = row.find('td'),
                    btnCell = $(this).parent();

                var confirma = confirm('¿Está seguro que desea borrar la instancia?');
                if (confirma) {

                    var instanciaId = cells[0].textContent;

                    var dataSet = '{instancia: "' + instanciaId + '" }';

                    $.ajax({
                        type: "POST",
                        url: "InstanciasComision.aspx/DeleteInstancia",
                        data: dataSet,
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                        },
                        success: function (response) {
                            if (response != null && response.d != null) {
                                var data = response.d;
                                data = $.parseJSON(data);

                                if (data.exito) {
                                    window.location.reload(true);
                                }
                                else {
                                    $('#myModal').modal();
                                    console.log(data.error);
                                }
                            }
                        }
                    });
                }
            });
        });
    </script>

    <div>
        <h3>Listado de instancias </h3>
    </div>

    <div style="text-align: right; margin-bottom: 20px;">

        <asp:Button ID="btnAgregar" runat="server" CssClass="btn btn-info" Text="Agregar" OnClick="btnAgregar_Click" />
        <button id="btnAlumnos" class="btn btn-default" style="margin-left: 20px;">
            Ver alumnos
        </button>
    </div>

    <div id="divSinRegistros" runat="server" class="row" style="text-align: center; margin-bottom: 50px;">
        <h3>Comisión sin instancias evaluativas generadas.
        </h3>
    </div>

    <asp:GridView ID="dgvInstancias" runat="server" AutoGenerateColumns="false" CssClass="table"
        RowStyle-BackColor="#f2f2f2" AlternatingRowStyle-BackColor="#cccccc" HeaderStyle-BackColor="#222222" HeaderStyle-ForeColor="LightGray">
        <Columns>
            <asp:BoundField DataField="Id" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Tipo" HeaderText="Tipo de calificación" />

            <asp:TemplateField HeaderText="Acción">
                <ItemTemplate>
                    <asp:Button ID="btnBorrar" runat="server" CausesValidation="false"
                        Text="Borrar" Font-Size="Smaller" CssClass="btn btn-link" />
                </ItemTemplate>
                <HeaderStyle Width="88px" />
            </asp:TemplateField>

        </Columns>
    </asp:GridView>

    <div style="text-align: center;">
        <asp:Button ID="btnVolver" runat="server" OnClick="btnVolver_Click" Text="Volver" CssClass="btn btn-success" />
    </div>

    <div class="modal fade" id="myModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header" style="background-color: midnightblue; color: white">
                            <button type="button" style="color: white" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title">
                                <asp:Label ID="lblModalTitle" runat="server" Text="Atención"></asp:Label></h4>
                        </div>
                        <div class="modal-body">
                            <asp:Label ID="lblModalBody" runat="server" Text="No se puede borrar la instancia, existen alumnos con notas cargadas para la misma."></asp:Label>
                        </div>
                        <div class="modal-footer">
                            <button class="btn btn-primary" data-dismiss="modal" aria-hidden="true" onclick="return boton()">Cerrar</button>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

</asp:Content>
