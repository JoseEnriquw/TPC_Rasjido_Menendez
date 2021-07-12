<%@ Page Title="Mesa" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mesa.aspx.cs" Inherits="RestoApp2.Mesa" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <div class="jumbotron">
        <h1>TU MESA Y PEDIDOS</h1>
        <p class="lead">Visualiza tu mesa, pedidos y gestiona mejor tus entregas!</p>
    </div>

	<a href="Mesero.aspx">
    <div class="volver-atras-izquierda">
        <div class="texto-atras-izquierda">VER MAS<br /> MESAS</div>
    </div>
	</a>

	<a href="Menu.aspx">
	<div class="volver-atras-derecha-1">
        <div class="texto-atras-derecha">AGREGAR<br /> DEL MENU</div>
    </div>
    </a>

    <div class="contenido">

				<table class="table user-list">
					<thead>
						<tr>
							<th><span>IMG</span></th>
							<th><span>PEDIDO</span></th>
							<th><span>MESA</span></th>
							<th><span>ESTADO</span></th>
							<th><span>CANTIDAD</span></th>
							<th><span>PRECIO</span></th>
							<th class="text-right"><span>OPCIONES</span></th>
						</tr>
					</thead>
					<tbody>




			<asp:Repeater ID="RepeaterMesa" runat="server">
                     <ItemTemplate>


						<tr>
							<td>
                                <img src="<%# Eval("Item.UrlImagen") %>" alt="..." class="item-mesa"/>
							</td>
							<td>
                                <%# Eval("Item.Nombre") %>
							</td>
							<td>
								<%# mesa.Nombre%>
							</td>
							<td>
								
							</td>
							<td>
                                <asp:TextBox ID="txtCantidad" runat="server"  ></asp:TextBox>
							</td>
							<td>
								<%#Eval("PrecioSubTotal") %>
							</td>
							<td class="text-right">
								<asp:Button ID="Button1" runat="server" Text="ENTREGADO" class="btn btn-theme"/>
								<asp:Button ID="Button3" runat="server" Text="PAGADO" class="btn btn-theme"/>
								<asp:Button ID="Button2" runat="server" Text="ELIMINAR" class="btn btn-theme"/>
							</td>
						</tr>



							
						</ItemTemplate>
             </asp:Repeater>













						</tbody>
					</table>
</div>
</asp:Content>
