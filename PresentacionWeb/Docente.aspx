<%@ Page Title="Docente" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Docente.aspx.cs" Inherits="PresentacionWeb.Docente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 id="txtProfesor" runat="server">Bienvenide, docente</h2>

    <div style="text-align:center"> 
        <asp:Button ID="btnComisiones" runat="server" OnClick="btnComisiones_Click" Text="Comisiones" CssClass="btn btn-primary" />
    </div>
</asp:Content>
