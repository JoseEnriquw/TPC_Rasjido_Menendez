<%@ Page Title="Gerente-Stock" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Gerente-Stock.aspx.cs" Inherits="RestoApp2.Gerente_Stock" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <div class="jumbotron">
        <h1>TU STOCK</h1>
        <p class="lead">Ten un vistazo a tus productos!</p>


<table class="filter">
              <tr>
                  <td class="item-filter">INSUMO: <asp:TextBox ID="TB_Insumo" runat="server" CssClass="drop" OnTextChanged="OnTextChanged_Filtros"></asp:TextBox></td>
                  <td class="item-filter">PRECIO: <asp:DropDownList ID="TB_Precio" runat="server" CssClass="drop" OnTextChanged="OnTextChanged_Filtros"></asp:DropDownList></td>
                  <td class="item-filter">CANTIDAD: <asp:DropDownList ID="TB_Cantidad" runat="server" CssClass="drop" OnTextChanged="OnTextChanged_Filtros"></asp:DropDownList></td>
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



                        <asp:Repeater runat="server" ID="repeaterStock">
                            <ItemTemplate>
						

						<tr style="background: #eee;">
							<td>
								<%#Eval("Nombre").ToString().ToUpper()%>
							</td>
							<td>
								<%#Eval("Precio").ToString().ToUpper()%>
							</td>
							<td>
								<asp:TextBox ID="Cantidad" runat="server" TextMode="Number"></asp:TextBox>
							</td>
							<td class="text-right">
								<asp:Button  ID="Button1" runat="server" Text="RENOVAR"  class="btn btn-theme" CommandArgument='<%#Eval("Id")%>' OnClick="actualizar"/>
								<asp:Button  ID="Button3" runat="server" Text="REMOVER"  class="btn btn-theme" CommandArgument='<%#Eval("Id")%>' OnClick="borrar"/>
							</td>
						</tr>

						</ItemTemplate>
                        </asp:Repeater>






						</tbody>
					</table>
</div>
</asp:Content>

