<%@ Page Title="Inscripciones" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inscripciones.aspx.cs" Inherits="PresentacionWeb.Inscripciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div>
        <h3>Listado de materias</h3>
    </div>

    <div id="divSinRegistros" runat="server" class="row" style="text-align:center; margin-bottom:50px;">
        <h3>
            No hay materias a las que pueda inscribirse de momento.
        </h3>
    </div>

    <asp:GridView ID="dgvMaterias" runat="server" AutoGenerateColumns="false" CssClass="table" 
        RowStyle-BackColor="#f2f2f2" AlternatingRowStyle-BackColor="#cccccc" HeaderStyle-BackColor="#222222" HeaderStyle-ForeColor="LightGray">
        <Columns>
            <asp:BoundField DataField="Id" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Carrera" HeaderText="Carrera" />
            <asp:BoundField DataField="Año" HeaderText="Año" />
            <asp:BoundField DataField="Cuatrimestre" HeaderText="Cuatrimestre" />

            <asp:TemplateField HeaderText="Acción">
                <ItemTemplate>
                    <asp:Button ID="btnComisiones" runat="server" CausesValidation="false" OnClick="btnComisiones_Click" 
                        Text="Comisiones" Font-Size="Smaller" CssClass="btn btn-link" />
                </ItemTemplate>
                <HeaderStyle Width="88px" />
            </asp:TemplateField>

        </Columns>
    </asp:GridView>
    
    <div style="text-align:center;">
        <asp:Button ID="btnVolver" runat="server" OnClick="btnVolver_Click" Text="Volver" CssClass="btn btn-success" />
    </div>

</asp:Content>
