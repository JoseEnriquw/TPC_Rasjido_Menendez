<%@ Page Title="RESTOAPP - TU MEJOR RESTAURANT!" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Gerente-Personal.aspx.cs" Inherits="RestoApp2.Gerente_Personal" EnableEventValidation="false"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <div class="jumbotron">
        <h1>TU PERSONAL</h1>
        <p class="lead">Administra a tus empleados!</p>


		<table class="filter">
              <tr>
                  <td class="item-filter">DNI: <asp:TextBox ID="TB_DNI" runat="server" CssClass="drop" OnTextChanged="OnTextChanged_Filtros" Text="" TextMode="Number" onkeypress="javascript:return solonumeros(event)"   AutoPostBack="true"></asp:TextBox></td>

                   <script>
                       function solonumeros(e) {

                           var key;

                           if (window.event) // IE
                           {
                               key = e.keyCode;
                           }
                           else if (e.which) // Netscape/Firefox/Opera
                           {
                               key = e.which;
                           }

                           if (key < 48 || key > 57) {
                               return false;
                           }

                           return true;
                       }
                   </script>

                  <td class="item-filter">NOMBRE: <asp:TextBox ID="TB_Nombre" runat="server"  CssClass="drop" OnTextChanged="OnTextChanged_Filtros" Text=""  AutoPostBack="true"></asp:TextBox></td>
                  
                  <td class="item-filter">APELLIDO: <asp:TextBox ID="TB_Apellido" runat="server"  CssClass="drop" OnTextChanged="OnTextChanged_Filtros" Text="" AutoPostBack="true"></asp:TextBox></td>
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

		<div id="personasactivas" style="display:block">
        <div class="row social">

        <div class="col-md-6">
            <a href="Mesero.aspx">
                <div class="panel" style="background-image: url(https://th.bing.com/th/id/OIP.8KI1Em2sYcNrxizTdGdGlAHaDt?pid=ImgDet&rs=1)">
                    <div class="panel-body text-center">
                        <small style="font-size:25px; color: #fff">VER PEDIDOS DE TODOS LOS EMPLEADOS</small>
                    </div>
                </div>
            </a>
        </div>


        <div class="col-md-6">
            <a href="javascript:personasinactivas()">
                <div class="panel" style="background-image: url(https://th.bing.com/th/id/OIP.8KI1Em2sYcNrxizTdGdGlAHaDt?pid=ImgDet&rs=1)">
                    <div class="panel-body text-center">
                        <small style="font-size:25px; color: #fff">VER EMPLEADOS DADOS DE BAJA</small>
                    </div>
                </div>
            </a>
        </div>
        </div>

                <%coloropc = 0;%>

				<table class="table user-list" style="margin-bottom:0">
					<thead>
						<tr>
							<th style="width: 19%"><span>NOMBRE</span></th>
							<th style="width: 18%"><span>APELLIDO</span></th>
							<th style="width: 19%"><span>DNI</span></th>
							<th style="width: 20%"><span>CARGO</span></th>
							<th class="text-right"><span>OPCIONES</span></th>
						</tr>
					</thead>
					<tbody>

                        

						<tr style="background: #555;">
							<td>
								<asp:TextBox ID="NombreNew" runat="server" TextMode="SingleLine"></asp:TextBox>
							</td>
							<td>
								<asp:TextBox ID="ApellidoNew" runat="server" TextMode="SingleLine"></asp:TextBox>
							</td>
							<td>
								<asp:TextBox ID="DniNew" runat="server" TextMode="Number" onkeypress="javascript:return solonumeros(event)" ></asp:TextBox>

                                  <script>
                                      function solonumeros(e) {

                                          var key;

                                          if (window.event) // IE
                                          {
                                              key = e.keyCode;
                                          }
                                          else if (e.which) // Netscape/Firefox/Opera
                                          {
                                              key = e.which;
                                          }

                                          if (key < 48 || key > 57) {
                                              return false;
                                          }

                                          return true;
                                      }
                                  </script>

							</td>
							<td>
                                <asp:DropDownList ID="DDL_CargoNew" runat="server"></asp:DropDownList>

							</td>
							<td class="text-right" style="width: 40%">
                                <asp:Button  ID="ButtonAdd" runat="server" Text="AGREGAR"		class="btn btn-theme" OnClick="ConfirmAgregar" Width="100%"/>
							</td>
						</tr>
                        </tbody></table>


                        <div style="height: 280px; overflow: scroll; background-image: url(https://th.bing.com/th/id/OIP.8KI1Em2sYcNrxizTdGdGlAHaDt?pid=ImgDet&rs=1)">
                        <table class="table user-list">
                        
                        <asp:Repeater runat="server" ID="repeaterPersonal">
                            <ItemTemplate>
                        

                       <%if (coloropc % 2 == 0)
                            {%>
						<tr style="background: #eee;"><%}else{%>
						<tr style="background: #bbb;"><%}%>
							<td>
								<asp:TextBox ID="Nombre" runat="server" TextMode="SingleLine" ></asp:TextBox>
							</td>
							<td>
								<asp:TextBox ID="Apellido" runat="server" TextMode="SingleLine" ></asp:TextBox>
							</td>
							<td>
								<asp:TextBox ID="Dni" runat="server" TextMode="Number" onkeypress="javascript:return solonumeros(event)" ></asp:TextBox>

                                <script>
                                    function solonumeros(e) {

                                        var key;

                                        if (window.event) // IE
                                        {
                                            key = e.keyCode;
                                        }
                                        else if (e.which) // Netscape/Firefox/Opera
                                        {
                                            key = e.which;
                                        }

                                        if (key < 48 || key > 57) {
                                            return false;
                                        }

                                        return true;
                                    }
                                </script>

							</td>
							<td>
								  <asp:DropDownList ID="DDL_Cargo" runat="server"></asp:DropDownList>
							</td>
							<td class="text-right">
								<asp:Button  ID="ButtonA" runat="server" Text="MODIFICAR"		class="btn btn-theme" CommandArgument='<%#Eval("Id")%>' OnClick="ConfirmActualizar" Width="47%"/>
								<asp:Button  ID="ButtonD" runat="server" Text="DAR DE BAJA"		class="btn btn-theme" CommandArgument='<%#Eval("Id")%>' OnClick="ConfirmBorrar" Width="47%"/>
							</td>
						</tr>
                        <%coloropc++;%>
                        </ItemTemplate>
                        </asp:Repeater>

					</table></div></div>

        <div id="personasinactivas" style="display:none">


		<div class="row social">

        <div class="col-md-6">
            <a href="Mesero.aspx">
                <div class="panel" style="background-image: url(https://th.bing.com/th/id/OIP.8KI1Em2sYcNrxizTdGdGlAHaDt?pid=ImgDet&rs=1)">
                    <div class="panel-body text-center">
                        <small style="font-size:25px; color: #fff">VER PEDIDOS DE TODOS LOS EMPLEADOS</small>
                    </div>
                </div>
            </a>
        </div>

        <div class="col-md-6">
            <a href="javascript:personasactivas()">
                <div class="panel" style="background-image: url(https://th.bing.com/th/id/OIP.8KI1Em2sYcNrxizTdGdGlAHaDt?pid=ImgDet&rs=1)">
                    <div class="panel-body text-center">
                        <small style="font-size:25px; color: #fff">VER EMPLEADOS ACTIVOS</small>
                    </div>
                </div>
            </a>
        </div>
        </div>

                <%coloropc = 0;%>

				<table class="table user-list" style="margin-bottom:0">
					<thead>
						<tr>
							<th style="width: 22%"><span>NOMBRE</span></th>
							<th style="width: 21%"> <span>APELLIDO</span></th>
							<th style="width: 21%"><span>DNI</span></th>
							<th style="width: 16%"><span>CARGO</span></th>
							<th class="text-right" style="width: 20%"><span>OPCIONES</span></th>
						</tr>
					</thead>
                    </table>

                        <div style="height: 333PX; overflow: scroll; background-image: url(https://th.bing.com/th/id/OIP.8KI1Em2sYcNrxizTdGdGlAHaDt?pid=ImgDet&rs=1)">
                        <table class="table user-list">
                        
                        <asp:Repeater runat="server" ID="repeaterPersonal2">
                            <ItemTemplate>
                        

                       <%if (coloropc % 2 == 0)
                            {%>
						<tr style="background: #eee;"><%}else{%>
						<tr style="background: #bbb;"><%}%>
							<td>
								<asp:TextBox ID="Nombre2" runat="server" TextMode="SingleLine" ></asp:TextBox>
							</td>
							<td>
								<asp:TextBox ID="Apellido2" runat="server" TextMode="SingleLine" ></asp:TextBox>
							</td>
							<td>
								<asp:TextBox ID="Dni2" runat="server" TextMode="Number" onkeypress="javascript:return solonumeros(event)" ></asp:TextBox>

                                <script>
                                    function solonumeros(e) {

                                        var key;

                                        if (window.event) // IE
                                        {
                                            key = e.keyCode;
                                        }
                                        else if (e.which) // Netscape/Firefox/Opera
                                        {
                                            key = e.which;
                                        }

                                        if (key < 48 || key > 57) {
                                            return false;
                                        }

                                        return true;
                                    }
                                </script>

							</td>
							<td>
								  <asp:DropDownList ID="DDL_Cargo2" runat="server"></asp:DropDownList>
							</td>
							<td class="text-right">
								<asp:Button  ID="ButtonA" runat="server" Text="REACTIVAR"		class="btn btn-theme" CommandArgument='<%#Eval("Id")%>' OnClick="ConfirmReactivar"/>

							</td>
						</tr>
                        <%coloropc++;%>
                        </ItemTemplate>
                        </asp:Repeater>

					</table></div></div>



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
            function personasactivas() {
                document.getElementById("personasactivas").style.display = "block";
                document.getElementById("personasinactivas").style.display = "none";
            }
        </script>
        <script>
            function personasinactivas() {
                document.getElementById("personasinactivas").style.display = "block";
                document.getElementById("personasactivas").style.display = "none";
            }
        </script>

    	    <script>
                function abrirventanaEmerg_Borrar() {

                    document.getElementById("mensajeConf_borrar").style.display = "block";
                    document.body.style.visibility = "visible: false";

                }
            </script>


	<div id="mensajeConf_borrar" class="ventanaEmerg" style="
	background: #232528;
    border: 6px solid #009ffd;
    color: #fff;
    position: absolute;
    top: 47%;
    width: 30%;
    height: 30%;
    left: 35%;
	text-align: center;
    z-index: 10;
	display: none;
    animation-direction:reverse;
    animation-delay: 10s;

	">
		<h1 style="color: #fca014">ESTAS POR REALIZAR CAMBIOS</h1>
        <p>¿Estas seguro de querer aplicar estos cambios?</p>

		<asp:Button  ID="jsBorrar" runat="server" Text="BORRAR" class="btn btn-theme" OnClick="Borrar"/>
        <asp:Button  ID="jsActualizar" runat="server" Text="ACTUALIZAR" class="btn btn-theme" OnClick="Actualizar"/>
        <asp:Button  ID="jsReactivar" runat="server" Text="REACTIVAR" class="btn btn-theme" OnClick="Reactivar_Persona"/>
        <asp:Button  ID="jsAgregar" runat="server" Text="AGREGAR" class="btn btn-theme" OnClick="Agregar"/>
		<asp:Button  ID="no" runat="server" Text="CANCELAR!" class="btn btn-theme"  />

    </div>
</asp:Content>
