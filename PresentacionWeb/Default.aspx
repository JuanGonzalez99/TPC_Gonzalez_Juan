<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PresentacionWeb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <%--<div class="imgcontainer">
        <span onclick="document.getElementById('id01').style.display='none'" class="close" title="Close Modal">&times;</span>
        <img src="img_avatar2.png" alt="Avatar" class="avatar">
    </div>

    <div class="container">
        <label for="uname"><b>Username</b></label>
        <input type="text" placeholder="Enter Username" name="uname" required>

        <label for="psw"><b>Password</b></label>
        <input type="password" placeholder="Enter Password" name="psw" required>

        <button type="submit">Login</button>
        <label>
            <input type="checkbox" checked="checked" name="remember">
            Remember me
        </label>
    </div>

    <div class="container" style="background-color: #f1f1f1">
        <button type="button" onclick="document.getElementById('id01').style.display='none'" class="cancelbtn">Cancel</button>
        <span class="psw">Forgot <a href="#">password?</a></span>
    </div>--%>

    <br />
    <br />
    <br />
    <br />

    <table border="1" align="center" width="280" cellpadding="0" cellspacing="0">
        <tbody>
            <tr>
                <td class="tituloTabla">Inicio de Sesión</td>
            </tr>
            <tr>
                <td bgcolor="#0000FF">
                    <table width="100%" cellpadding="0" cellspacing="1" border="0">
                        <tbody>
                            <tr>
                                <td bgcolor="#FFFFFF">
                                    <br>
                                    <table align="center" border="0" cellspacing="2" cellpadding="0">
                                        <tbody>
                                            <tr>
                                                <td align="right" nowrap="" class="textoTabla">Usuario: </td>
                                                <td align="left">
                                                    <input type="text" name="legajo" id="txtUsuario" runat="server"></td>
                                            </tr>

                                            <tr>
                                                <td align="right" nowrap="" class="textoTabla">Contraseña: </td>
                                                <td>
                                                    <input type="password" id="txtPassword" runat="server" name="password" maxlength="20">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">&nbsp;</td>
                                                <td align="center">
                                                    <table>
                                                        <tbody>
                                                            <tr>
                                                                <td class="textoTabla" style="padding-left: 50px;">
                                                                    <asp:Button ID="btnLogin" runat="server" Text="Ingresar" OnClick="btnLogin_Click" />
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="center">
                                                    <table>
                                                        <tbody>
                                                            <tr>
                                                                <td class="textoTabla">Si no recuerda su usuario, ingrese su DNI:&nbsp;
                                                                    <input type="text" id="dni" size="8" placeholder="Ingrese DNI">&nbsp;&nbsp;
                                                                    <asp:Button ID="btnGetLegajo" runat="server" Text="Buscar" />

                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </tbody>
    </table>

    <br />
    <br />
    <br />
    <br />

    <p>
        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Non odio euismod lacinia at quis risus sed vulputate. Urna neque viverra justo nec ultrices. Diam vel quam elementum pulvinar etiam non quam lacus. Orci sagittis eu volutpat odio facilisis mauris. Orci sagittis eu volutpat odio. Vulputate dignissim suspendisse in est ante in nibh mauris cursus. Sed faucibus turpis in eu mi bibendum neque egestas congue. Ut morbi tincidunt augue interdum velit euismod in. Sit amet volutpat consequat mauris. Nibh tortor id aliquet lectus proin nibh nisl condimentum id. Orci nulla pellentesque dignissim enim sit amet venenatis. Cras pulvinar mattis nunc sed blandit libero volutpat. Pretium nibh ipsum consequat nisl vel. Viverra nam libero justo laoreet.
        <br />
        <br />
        Viverra justo nec ultrices dui sapien eget mi proin. Nam libero justo laoreet sit. Aliquet nec ullamcorper sit amet. Consectetur lorem donec massa sapien faucibus et. Malesuada proin libero nunc consequat. Commodo odio aenean sed adipiscing diam. Leo in vitae turpis massa sed elementum tempus. Morbi tristique senectus et netus et. Tincidunt dui ut ornare lectus sit amet est placerat. Turpis nunc eget lorem dolor sed viverra. Etiam sit amet nisl purus in mollis nunc sed id. Tortor condimentum lacinia quis vel eros donec ac. Tellus pellentesque eu tincidunt tortor. Lacus vel facilisis volutpat est velit egestas dui id ornare. Cras adipiscing enim eu turpis egestas pretium. Sit amet mauris commodo quis imperdiet massa. Rhoncus est pellentesque elit ullamcorper dignissim cras.
    </p>

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

    <%--    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Getting started</h2>
            <p>
                ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Get more libraries</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Web Hosting</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
    </div>--%>
</asp:Content>
