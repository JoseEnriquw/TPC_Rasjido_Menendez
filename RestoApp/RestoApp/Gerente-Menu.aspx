<%@ Page Title="Gerente-Menu" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Gerente-Menu.aspx.vb" Inherits="RestoApp.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <div class="jumbotron">
        <h1>TU MESA Y PEDIDOS</h1>
        <p class="lead">Visualiza tu mesa, pedidos y gestiona mejor tus entregas!</p>


		<table class="filter">
              <tr>
                  <td class="item-filter">INSUMO: <asp:TextBox ID="TextBox8" runat="server" CssClass="drop"></asp:TextBox></td>
                  <td class="item-filter">CATEGORIA: <asp:DropDownList ID="DropDownList1" runat="server" CssClass="drop"></asp:DropDownList></td>
                  <td class="item-filter">TIPO: <asp:DropDownList ID="DropDownList2" runat="server" CssClass="drop"></asp:DropDownList></td>
                  
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

	<a href="Gerente-Personal.aspx">
	<div class="volver-atras-derecha-2">
        <div class="texto-atras-derecha">VER <br /> PERSONAL</div>
    </div>
    </a>




    <div class="contenido">

				<table class="table user-list">
					<thead>
						<tr>
							<th><span>FOTO</span></th>
							<th><span>INSUMO</span></th>
							<th><span>HORARIO</span></th>
							<th><span>CATEGORIA</span></th>
							<th><span>PRECIO</span></th>
							<th class="text-right"><span>OPCIONES</span></th>
						</tr>
					</thead>
					<tbody>




						<tr>
							<td>
								<div class="img-item-vacio"></div>
                                <img src="https://s3.amazonaws.com/arc-wordpress-client-uploads/infobae-wp/wp-content/uploads/2019/08/13202915/Gastronomia-del-mundo-111.jpg" alt="..." class="item-list" />
							</td>
							<td>
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
							</td>
							<td>
								<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
							</td>
							<td>
								<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
							</td>
							<td>
                                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
							</td>
							<td class="text-right">
								<asp:Button ID="Button1" runat="server" Text="ACTUALIZAR" class="btn btn-theme" />
							</td>
						</tr>
						<tr>
							<td></td><td>URL
                                <asp:TextBox ID="TextBox6" runat="server" class="url"></asp:TextBox>
							</td><td class="text-right">TIPO &nbsp &nbsp &nbsp</td><td><asp:TextBox ID="TextBox7" runat="server"></asp:TextBox></td><td></td>
							<td class="text-right">
								<asp:Button ID="Button3" runat="server" Text="ELIMINAR"  class="btn btn-theme"/>
							</td>
						</tr>









						</tbody>
					</table>
</div>
</asp:Content>