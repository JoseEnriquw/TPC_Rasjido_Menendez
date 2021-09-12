<%@ Page Title="Gerente-Stock" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Gerente-Stock.aspx.cs" Inherits="RestoApp2.Gerente_Stock" EnableEventValidation="false"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <div class="jumbotron">
        <h1>TU STOCK</h1>
        <p class="lead">Ten un vistazo a tus productos!</p>


<table class="filter">
              <tr>
                  <td class="item-filter">INSUMO: <asp:TextBox ID="TB_Insumo" runat="server" CssClass="drop" OnTextChanged="OnTextChanged_Filtros" Text=" "></asp:TextBox></td>
                  <td class="item-filter">PRECIO: <asp:DropDownList ID="TB_Precio" runat="server" CssClass="drop" OnTextChanged="OnTextChanged_Filtros" TextMode="Number"></asp:DropDownList></td>
                  <td class="item-filter">CANTIDAD: <asp:DropDownList ID="TB_Cantidad" runat="server" CssClass="drop" OnTextChanged="OnTextChanged_Filtros" TextMode="Number"></asp:DropDownList></td>
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

				<table class="table user-list" style="margin-bottom: 0">
					<thead>
						<tr>
							<th><span>INSUMO</span></th>
							<th><span>PRECIO</span></th>
							<th><span>CANTIDAD</span></th>
							<th><span>INGRESO</span></th>
							<th class="text-right"><span>OPCIONES</span></th>
						</tr>
					</thead>
					</table>

					<%coloropc = 0;%>

					<div style="height: 380px; overflow: scroll; background-image: url(https://th.bing.com/th/id/OIP.8KI1Em2sYcNrxizTdGdGlAHaDt?pid=ImgDet&rs=1)">
					<table class="table user-list">

					

                        <asp:Repeater runat="server" ID="repeaterStock">
                            <ItemTemplate>
						

						<%if (coloropc % 2 == 0)
                            {%>
						<tr style="background: #eee;"><%}else{%>
						<tr style="background: #bbb;"><%}%>
							<td>
								<%#Eval("Nombre").ToString().ToUpper()%>
							</td>
							<td>
								<%#Eval("Precio").ToString().ToUpper()%>
							</td>
							<td>
								<%#Eval("Stock").ToString()%>
							</td>
							<td>
								<asp:TextBox ID="CantidadNueva" runat="server" TextMode="Number" AutoPostBack="true"></asp:TextBox>
							</td>

							<td class="text-right">
								<asp:Button  ID="Button1" runat="server" Text="AGREGAR"  class="btn btn-theme" CommandArgument='<%#Eval("Id")%>' OnClick="actualizar"/>
								
							</td>
						</tr>
						<%coloropc++;%>
						</ItemTemplate>
                        </asp:Repeater>
					</table></div>
</div>
</asp:Content>

