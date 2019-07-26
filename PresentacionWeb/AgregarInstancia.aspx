<%@ Page Title="Agregar instancia" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarInstancia.aspx.cs" Inherits="PresentacionWeb.AgregarInstancia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">

        $(document).ready(function () {
            $('#btnCancelar').click(function (e) {
                var confirma = confirm('¿Está seguro que desea volver? No se guardarán los datos.');
                if (confirma) {
                    e.preventDefault();
                    window.location.replace("/InstanciasComision.aspx");
                }
            });

            //$('#myModal').on('hide.bs.modal', function (e) {
            //    var title = $('#MainContent_lblModalTitle').val();
            //    if (title == "Atención") {
            //        window.location.replace("/Inscripciones.aspx");
            //    }
            //});
        });

    </script>

    <h3 style="margin-bottom:20px;">
        Nueva instancia
    </h3>

    <div>
        <label>Nombre:</label>
        <asp:TextBox runat="server" ID="txtNombre"></asp:TextBox>
    </div>

    <div style="margin-top:20px;">
        <label>Tipo:</label>
        <asp:DropDownList ID="ddlTipo" runat="server" />
    </div>

    <div style="margin-top:20px;">
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
