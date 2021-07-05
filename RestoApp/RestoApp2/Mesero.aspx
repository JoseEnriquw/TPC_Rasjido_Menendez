<%@ Page Title="Mesero" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mesero.aspx.cs" Inherits="RestoApp2.Mesero" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<div class="jumbotron">
        <h1>MESAS</h1>
        <p class="lead">Elige que mesa ocuparas!</p>
    </div>



    <div class="contenido">



        <table class="table user-list">
					<thead>
						<tr>
							<th><span>MESA</span></th>
							<th class="text-center"><span>ESTADO</span></th>
							<th class="text-center"><span>MESERO</span></th>
							<th class="text-right"><span>OPCIONES</span></th>
						</tr>
					</thead>
					<tbody>



<%  
            Negocio.Consultas cons = new Negocio.Consultas();
            foreach (Dominio.Mesa item in cons.listaMesa)
            { %>

						<tr>
							<td>
                                <div class="job-box">
                                        N<%=item.NumeroMesa%>
                                </div>
							</td>
							<td>
								<div class="<%=item.Estado%>">
                                        <%=item.Estado%>
                                </div>
							</td>
							<td class="text-center">
								<%=item.Mesero.Nombre%>&nbsp<%=item.Mesero.Apellido%>
							</td>
							<td class="text-right">
								<asp:Button ID="Button1" runat="server" Text="ABRIR MESA" class="btn btn-theme"/>
								<asp:Button ID="Button2" runat="server" Text="CERRAR MESA" class="btn btn-theme"/>
								<asp:Button ID="Button3" runat="server" Text="SUS PEDIDOS" class="btn btn-theme"/>
							</td>
						</tr>

<%} %>


						</tbody>
					</table>


        </div>                    
</asp:Content>
