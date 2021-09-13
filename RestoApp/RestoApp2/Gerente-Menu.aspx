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


	<%/*PANELES DE NAVEGACION*/%>

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

<%/*INICIO DEL CONTENIDO*/%>

    <div class="contenido">




<div id="tablaactiva" style="display:block">
	<div class="row social">

        <div class="col-md-12">
            <a href="javascript:listainactiva()">
            <div class="panel" style="background-image: url(https://th.bing.com/th/id/OIP.8KI1Em2sYcNrxizTdGdGlAHaDt?pid=ImgDet&rs=1)">
            <div class="panel-body text-center">
                 <small style="font-size:30px; color: #fff">VER LOS INSUMOS DESCONTINUADOS</small>
            </div>
            </div>
            </a>
        </div>
	</div>

<%coloropc = 0;%>


		

				<table class="table user-list" style="margin-bottom: 0">
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
								<asp:Button ID="ButtonAdd" runat="server" Text="AGREGAR" class="btn btn-theme" OnClick="Agregar"/>
							</td>
						</tr>
					</tbody>
					</table>

                        
        <div style="height: 280px; overflow: scroll; background-image: url(https://th.bing.com/th/id/OIP.8KI1Em2sYcNrxizTdGdGlAHaDt?pid=ImgDet&rs=1)">
						<table class="table user-list" style="padding-bottom:0">
						<asp:Repeater runat="server" ID="repeaterMenu" >
                            <ItemTemplate>
						<%if (coloropc % 2 == 0)
                            {%>
						<tr style="background: #eee;"><%}else{%>
						<tr style="background: #bbb;"><%}%>
							<td rowspan="2">
								<asp:Image ID="Img" runat="server" style="z-index: 1; height:100px; width:100%; background-size:auto; border: 2px solid #000; background-color: black"/>
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
								<asp:Button ID="Button1" runat="server" Text="MODIFICAR" class="btn btn-theme" OnClick="Actualizar" CommandArgument='<%#Eval("Id")%>' />
							</td>

						</tr>
						<%if (coloropc % 2 == 0)
                            {%>
						<tr style="background: #eee;"><%}else{%>
						<tr style="background: #bbb;"><%}%>
							<td colspan="3">URL
                            <asp:TextBox ID="Url" runat="server" style="z-index: 1;" TextMode="Url" AutoPostBack="true" Width="100%"></asp:TextBox>
							<td class="text-right">
							<asp:Button ID="Button3" runat="server" Text="DAR DE BAJA"  class="btn btn-theme" OnClick="Borrar" CommandArgument='<%#Eval("Id")%>' /></td>
						</tr>
						
						<%coloropc++;%>
						
						</ItemTemplate>
                        </asp:Repeater>
					</table>
					</div>
</div>



<%/*TABLA INACTIVA*/%>

<div id="tablainactiva" style="display:none">
<div class="row social">

        <div class="col-md-12">
            <a href="javascript:listaactiva()">
                <div class="panel" style="background-image: url(https://th.bing.com/th/id/OIP.8KI1Em2sYcNrxizTdGdGlAHaDt?pid=ImgDet&rs=1)">
                    <div class="panel-body text-center">
                        <small style="font-size:30px; color: #fff">VER LOS INSUMOS ACTIVOS</small>
                    </div>
                </div>
            </a>
        </div></div>

				<table class="table user-list" style="margin-bottom: 0">
					<thead>
						<tr>
							<th><span>FOTO</span></th>
							<th><span>INSUMO</span></th>
							<th><span>CATEGORIA</span></th>
							<th><span>PRECIO</span></th>
							<th class="text-right"><span>OPCIONES</span></th>
						</tr>
					</thead>
					</table>

                        
        <div style="height: 333px; overflow: scroll; background-image: url(https://th.bing.com/th/id/OIP.8KI1Em2sYcNrxizTdGdGlAHaDt?pid=ImgDet&rs=1)">
						<table class="table user-list" style="padding-bottom:0">
						<asp:Repeater runat="server" ID="repeaterMenu2" >
                            <ItemTemplate>
						<%if (coloropc % 2 == 0)
                            {%>
						<tr style="background: #eee;"><%}else{%>
						<tr style="background: #bbb;"><%}%>
							<td rowspan="2">
								<asp:Image ID="Img2" runat="server" style="z-index: 1; height:100px; width:100%; background-size:auto; border: 2px solid #000; background-color: black;"/>
							</td>
							<td>
                                <asp:TextBox ID="Insumo2"  runat="server" style="z-index: 1;" TextMode="SingleLine" AutoPostBack="true" Enabled="false"></asp:TextBox>
							</td>
							<td>
								<asp:TextBox ID="Tipo2" runat="server" style="z-index: 1;" TextMode="SingleLine" AutoPostBack="true" Enabled="false"></asp:TextBox>
							</td>
							<td>
                                <asp:TextBox ID="Precio2" runat="server" style="z-index: 1;" AutoPostBack="true" Enabled="false"></asp:TextBox>
							</td>
							<td class="text-right">
								<asp:Button ID="ButtonReactivar" runat="server" Text="REACTIVAR INSUMO" class="btn btn-theme" CommandArgument='<%#Eval("Id")%>' />
							</td>

						</tr>
						<%if (coloropc % 2 == 0)
                            {%>
						<tr style="background: #eee;"><%}else{%>
						<tr style="background: #bbb;"><%}%>
							<td colspan="4">URL
                            <asp:TextBox ID="Url2" runat="server" style="z-index: 1;" TextMode="Url" AutoPostBack="true" Enabled="false" Width="100%"></asp:TextBox>
						</tr>
						
						<%coloropc++;%>
						
						</ItemTemplate>
                        </asp:Repeater>
					</table>
					</div>













</div>
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
	<script>
        function listaactiva() {
			document.getElementById("tablaactiva").style.display = "block";
			document.getElementById("tablainactiva").style.display = "none";
        }
    </script>
	<script>
        function listainactiva() {
            document.getElementById("tablaactiva").style.display = "none";
            document.getElementById("tablainactiva").style.display = "block";
        }
    </script>
</asp:Content>
