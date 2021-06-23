<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.vb" Inherits="RestoApp._Default" %>

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
                       <input type="text" class="form-control" id="yourName" />
                       <label for="exampleInputEmail1">Contraseña</label>
                       <input type="password" class="form-control" id="exampleInputEmail1" />
                       <br />
                       <button class="btn btn-theme" OnClick="window.open('Mesa.aspx');" >INGRESAR</button>
                   </div>
               </td>
               <td class="login-menue">
                   <div>
                        <h3 class="text-white mb-4">QUE HAY EN EL MENU?</h3>
                        <button class="btn btn-theme" OnClick="window.open('Menu.aspx');">VER MENU</button>
                   </div>
               </td>
           </tr>
       </table>              



</div>
</asp:Content>
