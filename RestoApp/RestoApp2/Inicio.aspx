<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="RestoApp2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>RESTO APP</h1>
        <p class="lead">Tu mejor app para gestionar tu negocio!.</p>
    </div>

    <div class="contenido">

  
       <table class="logueo">
           <tr>
               <td class="login">
                    <div>
                       <h3>INGRESA CON TU USUARIO</h3>
                       <label for="yourName">DNI</label>
                       <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                       <label for="exampleInputEmail1">Contraseña</label>
                       <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                       <br />
                       <asp:Button ID="Button1" runat="server" Text="INGRESAR" CssClass="btn btn-theme" OnClick="ingreso"/>
                   </div>
               </td>
               <td class="login-menue">
                   <div>
                        <h3 class="text-white mb-4">QUE HAY EN EL MENU?</h3>
                        <asp:Button ID="Button2" runat="server" Text="VER MENU" CssClass="btn btn-theme"/>
                   </div>
               </td>
           </tr>
       </table>                

</div>

<div id="ventanaEmergente" class="ventanaEmerg" style="
	background: #232528;
    border: 6px solid #009ffd;
    color: #fff;
    position: absolute;
    top: 45%;
    width: 30%;
    height: 20%;
    left: 41%;
	text-align: center;
    z-index: 10;
	display: none;
    animation-direction:reverse;
    animation-delay: 10s;
	">
		<h1 style="color: #fca014">HUBO UN ERROR!</h1>
        <asp:Label Text="text" runat="server" ID="msjError"/>
        <br /><br /><br />
        <asp:Button ID="Button3" runat="server" Text="CONTINUAR" CssClass="btn btn-theme"/>
    </div>
	

    <script>
        function abrirventanaEmerg() {
            document.getElementById("ventanaEmergente").style.display = "block";
            document.body.style.visibility = "visible: false";
        }
    </script>

</asp:Content>
