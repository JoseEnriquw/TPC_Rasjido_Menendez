<%@ Page Title="Contact" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mesa.aspx.vb" Inherits="RestoApp.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <div class="jumbotron">
        <h1>TU MESA Y PEDIDOS</h1>
        <p class="lead">Visualiza tu mesa, pedidos y gestiona mejor tus entregas!</p>
    </div>

	<a href="Menu.aspx">
    <div class="volver-atras-izquierda">
        <div class="texto-atras-izquierda">VER EL<br /> MENU</div>
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







						<tr>
							<td>
                                <img src="https://s3.amazonaws.com/arc-wordpress-client-uploads/infobae-wp/wp-content/uploads/2019/08/13202915/Gastronomia-del-mundo-111.jpg" alt="..." class="item-mesa"/>
							</td>
							<td>
                                NOMBRE DEL PLATO
							</td>
							<td>
								MESA N°1
							</td>
							<td>
								PENDIENTE
							</td>
							<td>
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
							</td>
							<td>
								$99.99
							</td>
							<td class="text-right">
								<asp:Button ID="Button1" runat="server" Text="ENTREGADO" class="btn btn-theme"/>
								<asp:Button ID="Button3" runat="server" Text="PAGADO" class="btn btn-theme"/>
								<asp:Button ID="Button2" runat="server" Text="ELIMINAR" class="btn btn-theme"/>
							</td>
						</tr>



												<tr>
							<td>
                                <img src="https://s3.amazonaws.com/arc-wordpress-client-uploads/infobae-wp/wp-content/uploads/2019/08/13202915/Gastronomia-del-mundo-111.jpg" alt="..." class="item-mesa"/>
							</td>
							<td>
                                NOMBRE DEL PLATO
							</td>
							<td>
								MESA N°1
							</td>
							<td>
								PENDIENTE
							</td>
							<td>
                                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
							</td>
							<td>
								$99.99
							</td>
							<td class="text-right">
								<asp:Button ID="Button4" runat="server" Text="ENTREGADO" class="btn btn-theme"/>
								<asp:Button ID="Button5" runat="server" Text="PAGADO" class="btn btn-theme"/>
								<asp:Button ID="Button6" runat="server" Text="ELIMINAR" class="btn btn-theme"/>
							</td>
						</tr>














						</tbody>
					</table>
</div>
</asp:Content>
