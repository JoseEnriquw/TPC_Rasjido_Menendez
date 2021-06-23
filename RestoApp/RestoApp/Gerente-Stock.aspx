<%@ Page Title="Stock" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Gerente-Stock.aspx.vb" Inherits="RestoApp.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <div class="jumbotron">
        <h1>TU MESA Y PEDIDOS</h1>
        <p class="lead">Visualiza tu mesa, pedidos y gestiona mejor tus entregas!</p>


		<table class="filter">
              <tr>
                  <td class="item-filter">INSUMO: <asp:TextBox ID="TextBox4" runat="server" CssClass="drop"></asp:TextBox></td>
                  <td class="item-filter">PRECIO MENOR A: <asp:TextBox ID="TextBox5" runat="server"  CssClass="drop"></asp:TextBox></td>
                  <td class="item-filter">CANTIDAD MENOR A: <asp:TextBox ID="TextBox6" runat="server"  CssClass="drop"></asp:TextBox></td>
              </tr>
          </table>
    </div>

	<a href="Gerente.aspx">
    <div class="volver-atras-izquierda">
        <div class="texto-atras-izquierda">MENU <br /> GERENTE</div>
    </div>
	</a>

    <a href="Gerente-Personal">
	<div class="volver-atras-derecha-1">
        <div class="texto-atras-derecha">VER<br /> PERSONAL</div>
    </div>
    </a>

	<a href="Gerente-Menu">
	<div class="volver-atras-derecha-2">
        <div class="texto-atras-derecha">GESTIONAR <br /> MENU</div>
    </div>
    </a>




    <div class="contenido">

				<table class="table user-list">
					<thead>
						<tr>
							<th><span>INSUMO</span></th>
							<th><span>PRECIO</span></th>
							<th><span>CANTIDAD</span></th>
							<th class="text-right"><span>OPCIONES</span></th>
						</tr>
					</thead>
					<tbody>




						<tr>
							<td>
								<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
							</td>
							<td>
								<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
							</td>
							<td>
								<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
							</td>
							<td class="text-right">
								<asp:Button ID="Button1" runat="server" Text="ACTUALIZAR"  class="btn btn-theme"/>
								<asp:Button ID="Button3" runat="server" Text="ELIMINAR"  class="btn btn-theme"/>
							</td>
						</tr>








						</tbody>
					</table>
</div>
</asp:Content>
