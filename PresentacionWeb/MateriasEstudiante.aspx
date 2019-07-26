<%@ Page Title="Materias" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MateriasEstudiante.aspx.cs" Inherits="PresentacionWeb.MateriasEstudiante" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h3>Listado de materias cursadas</h3>
    </div>

    <div id="divSinRegistros" runat="server" class="row" style="text-align:center; margin-bottom:50px;">
        <h3>
            Usted no está inscripto a ninguna materia.
        </h3>
    </div>

    <asp:GridView ID="dgvMaterias" runat="server" AutoGenerateColumns="false" CssClass="table" 
        RowStyle-BackColor="#f2f2f2" AlternatingRowStyle-BackColor="#cccccc" HeaderStyle-BackColor="#222222" HeaderStyle-ForeColor="LightGray">
        <Columns>
            <asp:BoundField DataField="Id" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
            <asp:BoundField DataField="Materia" HeaderText="Materia" />
            <asp:BoundField DataField="Materia.Carrera" HeaderText="Carrera" />
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
                    <asp:Button ID="btnNotas" runat="server" CausesValidation="false" OnClick="btnNotas_Click" 
                        Text="Notas" Font-Size="Smaller" CssClass="btn btn-link" />
                    <%--<asp:Button ID="btnDarseDeBaja" runat="server" CausesValidation="false" OnClick="btnDarseDeBaja_Click" 
                        Text="Darse de baja" Font-Size="Small" CssClass="btn btn-link" />--%>
                </ItemTemplate>
                <HeaderStyle Width="88px" />
            </asp:TemplateField>

        </Columns>
    </asp:GridView>
    
    <div style="text-align:center;">
        <asp:Button ID="btnVolver" runat="server" OnClick="btnVolver_Click" Text="Volver" CssClass="btn btn-success" />
    </div>

</asp:Content>
