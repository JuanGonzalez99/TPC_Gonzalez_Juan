<%@ Page Title="Notas por alumno" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NotasAlumno.aspx.cs" Inherits="PresentacionWeb.NotasAlumno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">

        $(document).ready(function () {

            $('input[value="Borrar"]').on('click', function (e) {

                e.preventDefault();

                var row = $(this).closest('tr'),
                    cells = row.find('td'),
                    btnCell = $(this).parent();

                if (cells[3].textContent.trim() == "") {
                    return;
                }

                var input = $(this).closest('input');

                var confirma = confirm('¿Está seguro que desea borrar la nota? Podrá volver a cargarla más adelante.');
                if (confirma) {

                    var instanciaId = cells[0].textContent;

                    var DataSet = JSON.stringify(
                        {
                            data: {
                                id: instanciaId
                            }
                        });

                    $.ajax({
                        type: "POST",
                        url: "NotasAlumno.aspx/DeleteNota",
                        data: DataSet,
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                        },
                        success: function (response) {
                            if (response != null && response.d != null) {
                                var data = response.d;
                                data = $.parseJSON(data);

                                if (data.exito) {
                                    cells[3].textContent = "";
                                    cells[4].textContent = "";
                                    input.remove();
                                }
                                else {
                                    $('#MainContent_lblModalTitle').text('Error');
                                    $('#MainContent_lblModalBody').text('Ha ocurrido un error. Intente nuevamente en unos instantes.');
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
        <h3>Listado de notas por alumno</h3>
    </div>

    <div style="text-align: center; margin-bottom: 20px;">
        <asp:Label runat="server" ID="lblAlumno"></asp:Label>
    </div>

    <div id="divSinRegistros" runat="server" class="row" style="text-align: center; margin-bottom: 50px;">
        <h3>Comisión sin instancias evaluativas asignadas.</h3>
    </div>

    <asp:GridView ID="dgvNotas" runat="server" AutoGenerateColumns="false" CssClass="table" OnRowDataBound="dgvNotas_RowDataBound"
        RowStyle-BackColor="#f2f2f2" AlternatingRowStyle-BackColor="#cccccc" HeaderStyle-BackColor="#222222" HeaderStyle-ForeColor="LightGray">
        <Columns>
            <asp:BoundField DataField="Instancia.Id" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
            <asp:BoundField DataField="Instancia.Nombre" HeaderText="Instancia" />
            <asp:BoundField DataField="Instancia.Tipo" HeaderText="Tipo de calificación" />
            <asp:BoundField DataField="Nota" HeaderText="Nota" />
            <asp:BoundField DataField="Comentarios" HeaderText="Comentarios" />

            <asp:TemplateField HeaderText="Acción">
                <ItemTemplate>
                    <asp:Button ID="btnEditar" runat="server" CausesValidation="false" OnClick="btnEditar_Click"
                        Text="Editar" Font-Size="Smaller" CssClass="btn btn-link" />
                    <asp:Button ID="btnBorrar" runat="server" CausesValidation="false"
                        Text="Borrar" Font-Size="Smaller" CssClass="btn btn-link" />
                    <%--<button id="btnBorrar" style="font-size: smaller;" class="btn btn-link">Borrar</button>--%>
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
                                <asp:Label ID="lblModalTitle" runat="server" Text=""></asp:Label></h4>
                        </div>
                        <div class="modal-body">
                            <asp:Label ID="lblModalBody" runat="server" Text=""></asp:Label>
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
