<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inscripciones.aspx.cs" Inherits="PresentacionWeb.Inscripciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <div>
            <h3>Listado de materias</h3>
        </div>

        <asp:GridView ID="dgvMaterias" runat="server" CssClass="table">

        </asp:GridView>

        <%--<div class="form-group">
            <asp:Button ID="btnInscribirse" runat="server" Text="Agregar" CssClass="btn btn-primary btn-lg" OnClick="btnAgregar_Click" />
        </div>--%>

</asp:Content>
