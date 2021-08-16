<%@ Page Title="Mesa" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" enableEventValidation="false" CodeBehind="Mesa.aspx.cs" Inherits="RestoApp2.Mesa" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <div class="jumbotron">
        <h1>TU MESA Y PEDIDOS</h1>
        <p class="lead">Visualiza tu mesa, pedidos y gestiona mejor tus entregas!</p>
    </div>

    

    <div class="contenido" style="margin-top:25%;">

        <div id="BOTONES" style="margin-bottom:1%">

			<div style="text-align:center">
        <asp:Button Text="VOLVER A MESAS" 
            runat="server" CssClass="btn-primary" style="width:50%; height: 60px; font-size: 20px; 
            background-image: url(https://th.bing.com/th/id/OIP.8KI1Em2sYcNrxizTdGdGlAHaDt?pid=ImgDet&rs=1);" OnClick="volverMesero"
            />
        <asp:Button Text="AGREGAR DEL MENU" 
            runat="server" CssClass="btn-primary" style="width:50%; height: 60px; font-size: 20px;
            background-image: url(https://th.bing.com/th/id/OIP.8KI1Em2sYcNrxizTdGdGlAHaDt?pid=ImgDet&rs=1)" OnClick="volverMenu"
            />  
    </div>





		
			</div>


		
					<table class="table user-list" style="margin-bottom:0; border-bottom: none;">
					<thead>
						<tr style="background: #232528; color: #fff">
							<th><span>MESERO A CARGO</span></th>
							<th class="text-center"><span>MESA ABIERTA</span></th>
							<th class="text-center"><span>CANTIDAD DE INSUMOS</span></th>
							<th class="text-center"><span>COSTO TOTAL</span></th>
							<th class="text-right"><span>OPCIONES</span></th>
						</tr>
					</thead>
					<tbody>

		<tr style="background: #ddd; font-size: 15px">
							<td>
                                <%= mesa.Mesero.Nombre %>
								&nbsp
								<%= mesa.Mesero.Apellido %>
							</td>
							<td class="text-center">
								<%= mesa.Nombre %>
							</td>
							<td class="text-center">
								<%= CantTotalInsumos %>
							</td>
							<td class="text-center">
								$<%= mesa.Pedidos.PrecioTotal %>
							</td>
							<td class="text-right">
								<asp:Button ID="Button1" runat="server" Text="CERRAR MESA" class="btn btn-theme"/>
							</td>
						</tr>

						</tbody></table>

				<table class="table user-list" style="margin-top:0">
					<thead>
						<tr>
							<th><span>IMG</span></th>
							<th><span>PEDIDO</span></th>
						    <th><span>ESTADO</span></th>
							<th><span>CANTIDAD</span></th>
							<th><span>PRECIO</span></th>
							<th><span>SUB TOTAL</span></th>
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
								<asp:Label ID="LabelEstado" runat="server" Font-Size="Medium"></asp:Label>
							</td>
							<td>

                                <asp:TextBox ID="txtCantidad"  runat="server" AutoPostBack="true"></asp:TextBox>
								
							</td>
							<td>
								<asp:Label ID="LabelPrecio" runat="server"></asp:Label>
							</td>
							<td>
								$<%#Eval("PrecioSubTotal") %></td>
							<td class="text-right">
								<asp:Button ID="ButtonUpdate" runat="server" Text="ACTUALIZAR" class="btn btn-theme" OnClick="Actualizar" CommandArgument='<%#Eval("Item.Id")%>'/>
								<asp:Button ID="ButtonEntrega" runat="server" Text="ENTREGADO" class="btn btn-theme" OnClick="Entregado" CommandArgument='<%#Eval("Item.Id")%>'/>
								<asp:Button ID="ButtonDelete" runat="server" Text="ELIMINAR" class="btn btn-theme" OnClick="Eliminar" CommandArgument='<%#Eval("Item.Id")%>'/>
							</td>
						</tr>
							
						
							
						</ItemTemplate>
             </asp:Repeater>


	
						</tbody>
					</table>
</div>
</asp:Content>
