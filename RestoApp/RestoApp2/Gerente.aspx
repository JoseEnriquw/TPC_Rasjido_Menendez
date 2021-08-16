<%@ Page Title="Gerente" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Gerente.aspx.cs" Inherits="RestoApp2.Gerente" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>RESTO APP</h1>
        <p class="lead">Tu mejor app para gestionar tu negocio!.</p>
    </div>
    <div class="contenido">

    
        <h1 class="text-center" style="top:0; color:#fff; background-image: url('https://th.bing.com/th/id/OIP.8KI1Em2sYcNrxizTdGdGlAHaDt?pid=ImgDet&rs=1'); border: 2px solid #000;">Seleccione una de las siguientes opciones!</h1>

    <div class="col-sm-6 col-lg-4 mb-2 interior">
                        <a href="Gerente-Stock.aspx">
                        <div class="portfolio-wrapper">
                            <div class="portfolio-image">
                                <img src="https://image.freepik.com/foto-gratis/vista-superior-portatil-comida-sobre-fondo-amarillo_23-2148247949.jpg" alt="..." />
                            </div>
                            <div class="portfolio-overlay">
                                <div class="portfolio-content">
                                    <h4>STOCK</h4>
                                    <p>Visualiza y controla tus insumos!</p>
                                </div>
                            </div>
                        </div></a>
                    </div>

    <div class="col-sm-6 col-lg-4 mb-2 interior">
                        <a href="Gerente-Personal">
                        <div class="portfolio-wrapper">
                            <div class="portfolio-image">
                                <img src="https://thumbs.dreamstime.com/b/agregar-nueva-ilustraci%C3%B3n-de-icono-vector-simple-usuario-al-fondo-amarillo-188683887.jpg" alt="..." />
                            </div>
                            <div class="portfolio-overlay">
                                <div class="portfolio-content">
                                    <h4>EMPLEADOS</h4>
                                    <p>Gestiona tu personal!</p>
                                </div>
                            </div>
                        </div></a>
                    </div>

    <div class="col-sm-6 col-lg-4 mb-2 interior">
                        <a href="Gerente-Menu">
                        <div class="portfolio-wrapper">
                            <div class="portfolio-image">
                                <img src="https://image.freepik.com/foto-gratis/vista-superior-cajas-ensalada-sobre-fondo-amarillo_23-2148247884.jpg" alt="..." />
                            </div>
                            <div class="portfolio-overlay">
                                <div class="portfolio-content">
                                    <h4>TU MENU</h4>
                                    <p>Visualiza y edita tu menu!</p>
                                </div>
                            </div>
                        </div></a>
                    </div>
         </div>

        <div style="text-align:center">
        <asp:Button Text="CANTIDAD DE MESAS" 
            runat="server" CssClass="btn-primary" style="width:50%; height: 60px; font-size: 20px; 
            background-image: url(https://th.bing.com/th/id/OIP.8KI1Em2sYcNrxizTdGdGlAHaDt?pid=ImgDet&rs=1);" OnClick="Mesas"
            />
        <asp:Button Text="VER HISTORIAL" 
            runat="server" CssClass="btn-primary" style="width:50%; height: 60px; font-size: 20px;
            background-image: url(https://th.bing.com/th/id/OIP.8KI1Em2sYcNrxizTdGdGlAHaDt?pid=ImgDet&rs=1)" OnClick="Historial"
            />  
    </div>


    <div id="ventanaEmergente" class="ventanaEmerg" style="
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
		<h1 style="color: #fca014">AGREGA TUS CAMBIOS!</h1>
        Actualmente cuentas con un total de: <%=cantidadMesas%> Mesas
        <p>quieres hacer algun cambio?</p>


        <asp:TextBox ID="NewCant" runat="server" ForeColor="Black" TextMode="Number" Text="0" Font-Bold="true"/>

        <p>Advertencia todo cambio afectara a la base de datos<br />Esto afectara las mesas existentes!</p>

		<asp:Button  ID="si" runat="server" Text="CONTINUAR" class="btn btn-theme" OnClick="NewMesas"/>
		<asp:Button  ID="no" runat="server" Text="CANCELAR!" class="btn btn-theme"  />

    </div>
	

    <script>
        function abrirventanaEmerg() {
            document.getElementById("ventanaEmergente").style.display = "block";
            document.body.style.visibility = "visible: false";
        }
    </script>


    
    <div id="listaEmergente" class="ventanaEmerg" style="
	background: #232528;
    border: 6px solid #009ffd;
    color: #fff;
    position: absolute;
    top: 39%;
    width: 80%;
    height: 55%;
    left: 10%;
	text-align: center;
    z-index: 10;
	display: none;
    animation-direction:reverse;
    animation-delay: 10s;
	">
		<h1 style="color: #fca014">TU VENTAS REGISTRADAS!</h1>
        
        <div style="margin:1%; overflow:scroll; height:75%; scrollbar-face-color:#009ffd">

        <asp:GridView ID="listaPedidos" runat="server" Width="100%" BackColor="#cccccc" AlternatingRowStyle-BackColor="#ffffff"
        ForeColor="Black" HeaderStyle-BackColor="#0099ff" AutoGenerateColumns="false"  
        RowStyle-HorizontalAlign="Left"
        >
        <Columns>
        <asp:BoundField DataField="Id" HeaderText="PersonalNumero" />
        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
        <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
        <asp:BoundField DataField="Dni" HeaderText="DNI" />
        <asp:BoundField DataField="Cargo.Descripcion" HeaderText="Cargo" />
        </Columns>
        
        </asp:GridView>
        </div>

		<asp:Button  ID="Button1" runat="server" Text="CONTINUAR" class="btn btn-theme" />

    </div>
	

    <script>
        function abrirlistaEmerg() {
            document.getElementById("listaEmergente").style.display = "block";
            document.body.style.visibility = "visible: false";
        }
    </script>


    </asp:Content>

