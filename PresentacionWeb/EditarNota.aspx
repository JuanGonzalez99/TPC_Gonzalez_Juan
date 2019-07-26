<%@ Page Title="Editar nota" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarNota.aspx.cs" Inherits="PresentacionWeb.EditarNota" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <script type="text/javascript">

        $(document).ready(function () {
            $('#btnCancelar').click(function (e) {
                var confirma = confirm('¿Está seguro que desea volver? No se guardarán los datos.');
                if (confirma) {
                    e.preventDefault();
                    window.location.replace("/NotasAlumno.aspx");
                }
            });
        });

    </script>

    <div>
        <h3>Edición de nota</h3>
    </div>

    <div style="margin-top:20px; margin-bottom:20px;">        
        <label>Nota:</label>
        <asp:DropDownList ID="ddlNotas" runat="server" />
    </div>

    <div style="margin-top:20px; margin-bottom:20px;">        
        <label style="vertical-align:top;">Comentarios:</label>
        <asp:TextBox ID="txtComentarios" runat="server" MaxLength="300" TextMode="MultiLine" Rows="3"  />
    </div>


    <div>
        <asp:Button runat="server" ID="btnGuardar" CssClass="btn btn-success" Text="Guardar" OnClick="btnGuardar_Click" />
    
        <button id="btnCancelar" class="btn btn-danger" style="margin-left:20px;" >Cancelar</button>
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
                            <button class="btn btn-primary" data-dismiss="modal" aria-hidden="true">Cerrar</button>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

</asp:Content>
