<%@ Page Title="Personal" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Gerente-Personal.aspx.vb" Inherits="RestoApp.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <div class="jumbotron">
        <h1>TU MESA Y PEDIDOS</h1>
        <p class="lead">Visualiza tu mesa, pedidos y gestiona mejor tus entregas!</p>


		<table class="filter">
              <tr>
                  <td class="item-filter">DNI: <asp:TextBox ID="TextBox4" runat="server" CssClass="drop"></asp:TextBox></td>
                  <td class="item-filter">NOMBRE: <asp:TextBox ID="TextBox5" runat="server"  CssClass="drop"></asp:TextBox></td>
                  <td class="item-filter">APELLIDO: <asp:TextBox ID="TextBox6" runat="server"  CssClass="drop"></asp:TextBox></td>
              </tr>
          </table>
    </div>

	<a href="Gerente.aspx">
    <div class="volver-atras-izquierda">
        <div class="texto-atras-izquierda">MENU <br /> GERENTE</div>
    </div>
	</a>

    <a href="Gerente-stock.aspx">
	<div class="volver-atras-derecha-1">
        <div class="texto-atras-derecha">GESTIONAR <br /> STOCK</div>
    </div>
    </a>

	<a href="Gerente-Menu.aspx">
	<div class="volver-atras-derecha-2">
        <div class="texto-atras-derecha">GESTIONAR <br /> MENU</div>
    </div>
    </a>




    <div class="contenido">

				<table class="table user-list">
					<thead>
						<tr>
							<th><span>NOMBRE</span></th>
							<th><span>APELLIDO</span></th>
							<th><span>DNI</span></th>
							<th><span>ESTADO</span></th>
							<th class="text-right"><span>OPCIONES</span></th>
						</tr>
					</thead>
					<tbody>




						<tr>
							<td>
                                PEPITO
							</td>
							<td>
								EL PISTOLERO
							</td>
							<td>
								99.999.999
							</td>
							<td>
                                ACTIVO
							</td>
							<td class="text-right">
								<asp:Button ID="Button1" runat="server" Text="VER SUS PEDIDOS" class="btn btn-theme"/>
								<asp:Button ID="Button3" runat="server" Text="ELIMINAR" class="btn btn-theme"/>
							</td>
						</tr>








						</tbody>
					</table>
</div>
</asp:Content>