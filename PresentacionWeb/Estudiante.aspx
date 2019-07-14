<%@ Page Title="Estudiante" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Estudiante.aspx.cs" Inherits="PresentacionWeb.Estudiante" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 id="txtAlumno" runat="server">Bienvenide, estudiante</h2>

    <div style="text-align:center"> 
        <asp:Button ID="btnInscripciones" runat="server" OnClick="btnInscripciones_Click" Text="Inscripciones" CssClass="btn btn-primary" />
    </div>
</asp:Content>
