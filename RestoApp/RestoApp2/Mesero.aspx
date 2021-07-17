<%@ Page Title="Mesero" Language="C#" MasterPageFile="~/Site.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Mesero.aspx.cs" Inherits="RestoApp2.Mesero" %>

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



					
                   

                        <asp:Repeater ID="RepeaterMesero" runat="server">
							<ItemTemplate>
						<tr>
							<td>
                                <div class="job-box">
                                        <%#Eval("Nombre")%>
                                </div>
							</td>
							<td>
								<div class="<%#Eval("Estado")%>">
                                    	<%# prueba = Eval("Estado").ToString().ToUpper()  %>
							</td>
							<td class="text-center">
								<%#Eval("Mesero.Nombre").ToString().ToUpper()%> <%#Eval("Mesero.Apellido").ToString().ToUpper()%>
							</td>
							<td class="text-right">

								<asp:Button ID="ButtonOpc" runat="server" Text="ABRIR MESA!" class="btn btn-theme" CommandArgument='<%#Eval("NumeroMesa")%>' OnClick="AbrirMesa" />

							</td>
						</tr>

				         </ItemTemplate>
						</asp:Repeater>






						</tbody>
					</table>


        </div>                    
</asp:Content>
