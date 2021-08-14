<%@ Page Title="Gerente-Personal" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Gerente-Personal.aspx.cs" Inherits="RestoApp2.Gerente_Personal" EnableEventValidation="false"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <div class="jumbotron">
        <h1>TU PERSONAL</h1>
        <p class="lead">Administra a tus empleados!</p>


		<table class="filter">
              <tr>
                  <td class="item-filter">DNI: <asp:TextBox ID="TB_DNI" runat="server" CssClass="drop" OnTextChanged="OnTextChanged_Filtros" Text=" " TextMode="Number"></asp:TextBox></td>
                  <td class="item-filter">NOMBRE: <asp:TextBox ID="TB_Nombre" runat="server"  CssClass="drop" OnTextChanged="OnTextChanged_Filtros" Text=" "></asp:TextBox></td>
                  <td class="item-filter">APELLIDO: <asp:TextBox ID="TB_Apellido" runat="server"  CssClass="drop" OnTextChanged="OnTextChanged_Filtros" Text=" "></asp:TextBox></td>
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

						<div class="col-sm-6 col-lg-4 mb-2 interior" style="width:100%; height: 0; margin-bottom:5%; margin-top: 0">
                        <a href="Mesero.aspx" >
                        <div class="portfolio-wrapper" >
                            <div class="portfolio-image">
                                <img src="https://th.bing.com/th/id/OIP.8KI1Em2sYcNrxizTdGdGlAHaDt?pid=ImgDet&rs=1" alt="..." style="width:100%; height: 40px; object-fit:cover;"/>
                            </div>
                            <div class="portfolio-overlay">
                                <div class="portfolio-content">
                                    <h4>VER PEDIDOS DE LOS EMPLEADOS</h4>
                                </div>
                            </div>
                        </div></a>
                    </div>


				<table class="table user-list">
					<thead>
						<tr>
							<th><span>NOMBRE</span></th>
							<th><span>APELLIDO</span></th>
							<th><span>DNI</span></th>
							<th><span>CARGO</span></th>
							<th class="text-right"><span>OPCIONES</span></th>
						</tr>
					</thead>
					<tbody>



						<tr style="background: #bbb;">
							<td>
								<asp:TextBox ID="NombreNew" runat="server" TextMode="SingleLine"></asp:TextBox>
							</td>
							<td>
								<asp:TextBox ID="ApellidoNew" runat="server" TextMode="SingleLine"></asp:TextBox>
							</td>
							<td>
								<asp:TextBox ID="DniNew" runat="server" TextMode="Number" ></asp:TextBox>
							</td>
							<td>
								<asp:TextBox ID="CargoNew" runat="server" TextMode="SingleLine"></asp:TextBox>
							</td>
							<td class="text-right">
                                <asp:Button  ID="ButtonAdd" runat="server" Text="AGREGAR"		class="btn btn-theme" OnClick="agregar" />
							</td>
						</tr>


                        <asp:Repeater runat="server" ID="repeaterPersonal">
                            <ItemTemplate>
                        

                        <tr style="background: #eee;">
							<td>
								<asp:TextBox ID="Nombre" runat="server" TextMode="SingleLine" AutoPostBack="true"></asp:TextBox>
							</td>
							<td>
								<asp:TextBox ID="Apellido" runat="server" TextMode="SingleLine" AutoPostBack="true"></asp:TextBox>
							</td>
							<td>
								<asp:TextBox ID="Dni" runat="server" TextMode="Number" AutoPostBack="true"></asp:TextBox>
							</td>
							<td>
								<asp:TextBox ID="Cargo" runat="server" TextMode="SingleLine" AutoPostBack="true"></asp:TextBox>
							</td>
							<td class="text-right">
								<asp:Button  ID="ButtonA" runat="server" Text="MODIFICAR"		class="btn btn-theme" CommandArgument='<%#Eval("Id")%>' OnClick="actualizar"/>
								<asp:Button  ID="ButtonD" runat="server" Text="DAR DE BAJA"		class="btn btn-theme" CommandArgument='<%#Eval("Id")%>' OnClick="borrar"/>
							</td>
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
