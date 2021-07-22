<%@ Page Title="Gerente-Menu" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Gerente-Menu.aspx.cs" Inherits="RestoApp2.Gerente_Menu" EnableEventValidation="false"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <div class="jumbotron">
        <h1>TU MENU</h1>
        <p class="lead">Personaliza tus ventas!</p>


		<table class="filter">
              <tr>
                  <td class="item-filter">INSUMO: <asp:TextBox ID="TB_Insumo" runat="server" CssClass="drop" OnTextChanged="OnTextChanged_Filtros" Text=" " AutoPostBack="true"></asp:TextBox></td>
                  <td class="item-filter">CATEGORIA: <asp:DropDownList ID="DDL_Categorias" runat="server" CssClass="drop" OnTextChanged="OnTextChanged_Filtros" AutoPostBack="true"></asp:DropDownList></td>
                  <td class="item-filter">TIPO DE INSUMO: <asp:DropDownList ID="DDL_Tipo_Insumo" runat="server" CssClass="drop" OnTextChanged="OnTextChanged_Filtros" AutoPostBack="true"></asp:DropDownList></td>
                  
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
								<asp:TextBox ID="UrlNew" runat="server" style="z-index: 1; width: 130px" TextMode="Url"></asp:TextBox>
							</td>
							<td>
                                <asp:TextBox ID="InsumoNew"  runat="server" style="z-index: 1;" TextMode="SingleLine"></asp:TextBox>
							</td>
							<td>
								<asp:TextBox ID="TipoNew" runat="server" style="z-index: 1;" TextMode="Number"></asp:TextBox>
							</td>
							<td>
                                <asp:TextBox ID="PrecioNew" runat="server" style="z-index: 1;"></asp:TextBox>
							</td>
							<td class="text-right">
								<asp:Button ID="ButtonAdd" runat="server" Text="AGREGAR" class="btn btn-theme"/>
							</td>

						

                        <asp:Repeater runat="server" ID="repeaterMenu">
                            <ItemTemplate>

						<tr style="background: #eee;">
							<td>
								<div class="img-item-vacio"></div>
								<asp:Image ID="Img" runat="server" CssClass="item-list" style="z-index: 1;"/>
							</td>
							<td>
                                <asp:TextBox ID="Insumo"  runat="server" style="z-index: 1;" TextMode="SingleLine" AutoPostBack="true"></asp:TextBox>
							</td>
							<td>
								<asp:TextBox ID="Tipo" runat="server" style="z-index: 1;" TextMode="SingleLine" AutoPostBack="true"></asp:TextBox>
							</td>
							<td>
                                <asp:TextBox ID="Precio" runat="server" style="z-index: 1;" AutoPostBack="true"></asp:TextBox>
							</td>
							<td class="text-right">
								<asp:Button ID="Button1" runat="server" Text="RENOVAR" class="btn btn-theme" OnClick="actualizar" CommandArgument='<%#Eval("Id")%>' />
							</td>

						</tr>
						<tr style="background: #bbb;">
							<td></td><td>URL
                            <asp:TextBox ID="Url" runat="server" class="url" style="z-index: 1;" TextMode="Url" AutoPostBack="true"></asp:TextBox>
							</td><td></td><td></td>
							<td class="text-right">
							<asp:Button ID="Button3" runat="server" Text="REMOVER"  class="btn btn-theme" OnClick="borrar" CommandArgument='<%#Eval("Id")%>' /></td>
						</tr>


						</ItemTemplate>
                        </asp:Repeater>






						</tbody>
					</table>
</div>

		<div id="ventanaEmergente" class="ventanaEmerg" style="
	background: #232528;
    border: 6px solid #009ffd;
    color: #fff;
    position: absolute;
    top: 40%;
    width: 21%;
    height: 29%;
    left: 60%;
	text-align: center;
    z-index: 10;
	display: none;
    animation-direction:reverse;
    animation-delay: 10s;
	">
		<h1 style="color: #fca014">HUBO UN ERROR!</h1>
        DEBE COMPLETAR TODOS LOS CAMPOS!
        <br /><br /><br />
        <asp:Button ID="Button3" runat="server" Text="CONTINUAR" CssClass="btn btn-theme"/>
    </div>
	

    <script>
        function abrirventanaEmerg() {
            document.getElementById("ventanaEmergente").style.display = "block";
            document.body.style.visibility = "visible: false";
        }
    </script>
</asp:Content>
