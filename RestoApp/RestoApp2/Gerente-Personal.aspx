<%@ Page Title="Gerente-Personal" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Gerente-Personal.aspx.cs" Inherits="RestoApp2.Gerente_Personal" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <div class="jumbotron">
        <h1>TU PERSONAL</h1>
        <p class="lead">Administra a tus empleados!</p>


		<table class="filter">
              <tr>
                  <td class="item-filter">DNI: <asp:TextBox ID="TB_DNI" runat="server" CssClass="drop" OnTextChanged="OnTextChanged_Filtros" ></asp:TextBox></td>
                  <td class="item-filter">NOMBRE: <asp:TextBox ID="TB_Nombre" runat="server"  CssClass="drop" OnTextChanged="OnTextChanged_Filtros" ></asp:TextBox></td>
                  <td class="item-filter">APELLIDO: <asp:TextBox ID="TB_Apellido" runat="server"  CssClass="drop" OnTextChanged="OnTextChanged_Filtros" ></asp:TextBox></td>
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
							<th class="text-right"><span>OPCIONES</span></th>
						</tr>
					</thead>
					<tbody>


					<%foreach (Dominio.Persona item in PersonaLista){%>
                        

						<tr>
							<td>
                                <%=item.Nombre%>
							</td>
							<td>
								<%=item.Apellido%>
							</td>
							<td>
								<%=item.Dni%>
							</td>
							<td class="text-right">
								<asp:Button  ID="Button1" runat="server" Text="VER SUS PEDIDOS" class="btn btn-theme"/>
								<asp:Button  ID="Button3" runat="server" Text="ELIMINAR" class="btn btn-theme"/>
							</td>
						</tr>

						<%} %>






						</tbody>
					</table>
</div>
</asp:Content>
