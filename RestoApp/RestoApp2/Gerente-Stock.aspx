<%@ Page Title="RESTOAPP - TU MEJOR RESTAURANT!" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Gerente-Stock.aspx.cs" Inherits="RestoApp2.Gerente_Stock" EnableEventValidation="false"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <div class="jumbotron">
        <h1>TU STOCK</h1>
        <p class="lead">Ten un vistazo a tus productos!</p>


<table class="filter">
              <tr>
                  <td class="item-filter">INSUMO: <asp:TextBox ID="TB_Insumo" runat="server" CssClass="drop" OnTextChanged="OnTextChanged_Filtros" AutoPostBack="true"></asp:TextBox></td>
                  <td class="item-filter">
                      : <asp:TextBox ID="TB_Precio" runat="server" CssClass="drop" OnTextChanged="OnTextChanged_Filtros" TextMode="Number" AutoPostBack="true"></asp:TextBox></td>
               <td class="item-filter">CANTIDAD: <asp:TextBox ID="TB_Cantidad" runat="server" CssClass="drop" OnTextChanged="OnTextChanged_Filtros"  AutoPostBack="true" TextMode="singleline" onkeypress="javascript:return solonumeros(event)"></asp:TextBox></td>
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


		<div id="tablaactiva" style="display:block">
<div class="row social">

        <div class="col-md-12">
            <a href="javascript:listainactiva()">
                <div class="panel" style="background-image: url(https://th.bing.com/th/id/OIP.8KI1Em2sYcNrxizTdGdGlAHaDt?pid=ImgDet&rs=1)">
                    <div class="panel-body text-center">
                        <small style="font-size:30px; color: #fff">VER LOS INSUMOS SIN STOCK</small>
                    </div>
                </div>
            </a>
        </div></div>

				<table class="table user-list" style="margin-bottom: 0">
					<thead>
						<tr>
							<th style="width: 50%"><span>INSUMO</span></th>
							<th style="width: 10%"><span>PRECIO</span></th>
							<th><span>CANTIDAD</span></th>
							<th><span>INGRESO</span></th>
							<th class="text-right"><span>OPCIONES</span></th>
						</tr>
					</thead>
					</table>

					<%coloropc = 0;%>

					<div style="height: 333px; overflow: scroll; background-image: url(https://th.bing.com/th/id/OIP.8KI1Em2sYcNrxizTdGdGlAHaDt?pid=ImgDet&rs=1)">
					<table class="table user-list">

					

                        <asp:Repeater runat="server" ID="repeaterStock">
                            <ItemTemplate>
						

						<%if (coloropc % 2 == 0)
                            {%>
						<tr style="background: #eee;"><%}else{%>
						<tr style="background: #bbb;"><%}%>
							<td style="width: 50%">
								<%#Eval("Nombre").ToString().ToUpper()%>
							</td>
							<td style="width: 13%">
								<%#Eval("Precio").ToString().ToUpper()%>
							</td>
							<td style="width: 7%">
								<%#Eval("Stock").ToString()%>
							</td>
							<td>
								<asp:TextBox ID="CantidadNueva" runat="server" TextMode="singleline" onkeypress="javascript:return solonumeros(event)" placeholder="Cantidad entrante"></asp:TextBox>

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

							<td class="text-right">
								<asp:Button  ID="Button1" runat="server" Text="AGREGAR"  class="btn btn-theme" CommandArgument='<%#Eval("Id")%>' OnClick="Confirmacion" />
								
							</td>
						</tr>
						<%coloropc++;%>
						</ItemTemplate>
                        </asp:Repeater>
					</table></div>
</div>



<div id="tablainactiva" style="display:none">
<div class="row social">

        <div class="col-md-12">
            <a href="javascript:listaactiva()">
                <div class="panel" style="background-image: url(https://th.bing.com/th/id/OIP.8KI1Em2sYcNrxizTdGdGlAHaDt?pid=ImgDet&rs=1)">
                    <div class="panel-body text-center">
                        <small style="font-size:30px; color: #fff">VER LOS INSUMOS CON STOCK</small>
                    </div>
                </div>
            </a>
        </div></div>

				<table class="table user-list" style="margin-bottom: 0">
					<thead>
						<tr>
							<th style="width: 50%"><span>INSUMO</span></th>
							<th style="width: 10%"><span>PRECIO</span></th>
							<th><span>CANTIDAD</span></th>
							<th><span>INGRESO</span></th>
							<th class="text-right"><span>OPCIONES</span></th>
						</tr>
					</thead>
					</table>

					<%coloropc = 0;%>

					<div style="height: 333px; overflow: scroll; background-image: url(https://th.bing.com/th/id/OIP.8KI1Em2sYcNrxizTdGdGlAHaDt?pid=ImgDet&rs=1)">
					<table class="table user-list">

					

                        <asp:Repeater runat="server" ID="repeaterStock2">
                            <ItemTemplate>
						

						<%if (coloropc % 2 == 0)
                            {%>
						<tr style="background: #eee;"><%}else{%>
						<tr style="background: #bbb;"><%}%>
							<td style="width: 50%">
								<%#Eval("Nombre").ToString().ToUpper()%>
							</td>
							<td style="width: 13%">
								<%#Eval("Precio").ToString().ToUpper()%>
							</td>
							<td style="width: 7%">
								<%#Eval("Stock").ToString()%>
							</td>
							<td>
								<asp:TextBox ID="CantidadNueva" runat="server" TextMode="Number" onkeypress="javascript:return solonumeros(event)" placeholder="Cantidad entrante"></asp:TextBox>

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

							<td class="text-right">
								<asp:Button  ID="Button1" runat="server" Text="AGREGAR"  class="btn btn-theme" CommandArgument='<%#Eval("Id")%>' OnClick="Confirmacion"/>
								
							</td>
						</tr>
						<%coloropc++;%>
						</ItemTemplate>
                        </asp:Repeater>
					</table></div>
</div>>


    </div>
		<script>
        function listaactiva() {
            document.getElementById("tablaactiva").style.display = "block";
            document.getElementById("tablainactiva").style.display = "none";
        }

            function listainactiva() {
                document.getElementById("tablaactiva").style.display = "none";
                document.getElementById("tablainactiva").style.display = "block";
			}

        </script>


	    <script>
            function abrirventanaEmerg() {
                document.getElementById("mensajeConf").style.display = "block";
                document.body.style.visibility = "visible: false";
            }
        </script>


	<div id="mensajeConf" class="ventanaEmerg" style="
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

		<asp:Button  ID="si" runat="server" Text="CONTINUAR" class="btn btn-theme" OnClick="Actualizar"/>
		<asp:Button  ID="no" runat="server" Text="CANCELAR!" class="btn btn-theme"  />

    </div>


</asp:Content>

