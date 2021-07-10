<%@ Page Title="Gerente-Menu" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Gerente-Menu.aspx.cs" Inherits="RestoApp2.Gerente_Menu" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <div class="jumbotron">
        <h1>TU MENU</h1>
        <p class="lead">Personaliza tus ventas!</p>


		<table class="filter">
              <tr>
                  <td class="item-filter">INSUMO: <asp:TextBox ID="TB_Insumo" runat="server" CssClass="drop" OnTextChanged="OnTextChanged_Filtros"></asp:TextBox></td>
                  <td class="item-filter">CATEGORIA: <asp:DropDownList ID="TB_Tipo" runat="server" CssClass="drop" OnTextChanged="OnTextChanged_Filtros"></asp:DropDownList></td>
                  <td class="item-filter">PRECIO: <asp:DropDownList ID="TB_Precio" runat="server" CssClass="drop" OnTextChanged="OnTextChanged_Filtros"></asp:DropDownList></td>
                  
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
							<th><span>CATEGORIA</span></th>
							<th><span>PRECIO</span></th>
							<th class="text-right"><span>OPCIONES</span></th>
						</tr>
					</thead>
					<tbody>

						<tr style="background: #555;">
							<td>
								<asp:TextBox ID="UrlNew" runat="server" style="z-index: 1; width: 130px"></asp:TextBox>
							</td>
							<td>
                                <asp:TextBox ID="InsumoNew"  runat="server" style="z-index: 1;"></asp:TextBox>
							</td>
							<td>
								<asp:TextBox ID="TipoNew" runat="server" style="z-index: 1;"></asp:TextBox>
							</td>
							<td>
                                <asp:TextBox ID="PrecioNew" runat="server" style="z-index: 1;"></asp:TextBox>
							</td>
							<td class="text-right">
								<asp:Button ID="Button1" runat="server" Text="AGREGAR" class="btn btn-theme"/>
							</td>

						

                        <asp:Repeater runat="server" ID="repeaterMenu">
                            <ItemTemplate>

						<tr style="background: #eee;">
							<td>
								<div class="img-item-vacio"></div>
								<asp:Image ID="Img" runat="server" CssClass="item-list" style="z-index: 1;" />
							</td>
							<td>
                                <asp:TextBox ID="Insumo"  runat="server" style="z-index: 1;"></asp:TextBox>
							</td>
							<td>
								<asp:TextBox ID="Tipo" runat="server" style="z-index: 1;"></asp:TextBox>
							</td>
							<td>
                                <asp:TextBox ID="Precio" runat="server" style="z-index: 1;"></asp:TextBox>
							</td>
							<td class="text-right">
								<asp:Button ID="Button1" runat="server" Text="RENOVAR" class="btn btn-theme" CommandArgument='<%#Eval("Id")%>' OnClick="actualizar"/>
							</td>

						</tr>
						<tr style="background: #bbb;">
							<td></td><td>URL
                            <asp:TextBox ID="Url" runat="server" class="url" style="z-index: 1;"></asp:TextBox>
							</td><td></td><td></td>
							<td class="text-right">
							<asp:Button ID="Button3" runat="server" Text="REMOVER"  class="btn btn-theme" CommandArgument='<%#Eval("Id")%>' OnClick="borrar"/></td>
						</tr>


						</ItemTemplate>
                        </asp:Repeater>






						</tbody>
					</table>
</div>
</asp:Content>
