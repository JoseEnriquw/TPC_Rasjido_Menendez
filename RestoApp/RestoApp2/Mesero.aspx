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




						<tr>
							<td>
                                <div class="job-box">
                                        N1
                                </div>
							</td>
							<td>
								<div class="abierto">
                                        ABIERTO
                                </div>
							</td>
							<td class="text-center">
								PEPITO JUAREZ
							</td>
							<td class="text-right">
								<asp:Button OnClick="window.open('Mesero.aspx');" ID="Button3" runat="server" Text="CERRAR MESA" class="btn btn-theme"/>
								<asp:Button OnClick="window.open('Mesa.aspx');" ID="Button1" runat="server" Text="SUS PEDIDOS" class="btn btn-theme"/>
							</td>
						</tr>


						<tr>
							<td>
                                <div class="job-box">
                                        N2
                                </div>
							</td>
							<td>
								<div class="libre">
                                        LIBRE
                                </div>
							</td>
							<td class="text-center">
								SIN MESERO
							</td>
							<td class="text-right">
								<asp:Button OnClick="window.open('Mesa.aspx');" ID="Button2" runat="server" Text="ABRIR MESA" class="btn btn-theme"/>
							</td>
						</tr>

						<tr>
							<td>
                                <div class="job-box">
                                        N3
                                </div>
							</td>
							<td>
								<div class="cerrado">
                                        CERRADO
                                </div>
							</td>
							<td class="text-center">
								JUAN PEREZ
							</td>
							<td class="text-right">
								
							</td>
						</tr>







						</tbody>
					</table>


        </div>                    
</asp:Content>
