<%@ Page Title="Inscripcion a materia" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InscripcionComision.aspx.cs" Inherits="PresentacionWeb.InscripcionComision" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">

        $(document).ready(function() {
            $('#modalInscripto').on('hide.bs.modal', function (e) {
                window.location.replace("/Inscripciones.aspx");
            })
        });

    </script>

    <div>
        <h3>Listado de comisiones</h3>
    </div>

    <div id="divSinRegistros" runat="server" class="row" style="text-align: center; margin-bottom: 50px;">
        <h3>La materia seleccionada aún no posee comisiones asociadas.
        </h3>
    </div>

    <asp:GridView ID="dgvComisiones" runat="server" AutoGenerateColumns="false" CssClass="table"
        RowStyle-BackColor="#f2f2f2" AlternatingRowStyle-BackColor="#cccccc" HeaderStyle-BackColor="#222222" HeaderStyle-ForeColor="LightGray">
        <Columns>
            <asp:BoundField DataField="Id" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
            <asp:BoundField DataField="Materia" HeaderText="Materia" />
            <asp:BoundField DataField="Año" HeaderText="Año" />
            <asp:BoundField DataField="Cuatrimestre" HeaderText="Cuatrimestre" />
            <asp:BoundField DataField="Turno" HeaderText="Turno" />
            <asp:BoundField DataField="Modalidad" HeaderText="Modalidad" />
            <asp:BoundField DataField="Profesor" HeaderText="Profesor" />
            <asp:BoundField DataField="Ayudante" HeaderText="Ayudante" />

            <asp:TemplateField HeaderText="Horario(s)" >
                <ItemTemplate>
                    <asp:Repeater ID="rptHorarios" runat="server" DataSource='<%# Eval("Horarios") %>'>
                        <ItemTemplate>
                            <%# Container.DataItem  %><br />
                        </ItemTemplate>
                    </asp:Repeater>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Acción">
                <ItemTemplate>
                    <asp:Button ID="btnInscribirse" runat="server" CausesValidation="false" OnClick="btnInscribirse_Click"
                        Text="Inscribirse" Font-Size="Smaller" CssClass="btn btn-link" />
                </ItemTemplate>
                <HeaderStyle Width="88px" />
            </asp:TemplateField>

        </Columns>
    </asp:GridView>

    <div style="text-align: center;">
        <asp:Button ID="btnVolver" runat="server" OnClick="btnVolver_Click" Text="Volver" CssClass="btn btn-success" />
    </div>

    <div class="modal fade" id="modalInscripto" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
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
                            <button class="btn btn-primary" data-dismiss="modal" aria-hidden="true">Cerrar</button>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

</asp:Content>
