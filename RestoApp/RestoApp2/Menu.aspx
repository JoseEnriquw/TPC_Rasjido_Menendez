<%@ Page Title="RESTOAPP - TU MEJOR RESTAURANT!" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="RestoApp2.Menu" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >
    
    <div class="jumbotron">
        <h1>MENU</h1>
        <p class="lead">Busca tus mejores insumos para ordenar!</p>

        <table class="filter">
              <tr>
                           
                  <td class="item-filter">BUSCAR: <asp:TextBox ID="TB_Buscar" runat="server" CssClass="drop" OnTextChanged="OnTextChanged_Filtros"></asp:TextBox></td>
                  <td class="item-filter">CATEGORIA: <asp:DropDownList ID="DDL_Categorias" runat="server" CssClass="drop" OnTextChanged="OnTextChanged_Filtros" AutoPostBack="true"></asp:DropDownList></td>
                  <td class="item-filter">TIPO DE INSUMO: <asp:DropDownList ID="DDL_Tipo_Insumo" runat="server" CssClass="drop" OnTextChanged="OnTextChanged_Filtros" AutoPostBack="true"></asp:DropDownList></td>
              </tr>
          </table>
</div>
    <%if (((Dominio.Persona)Session["UserLog"]) != null)
        {%>
    <a href="Mesa.aspx">
    <div class="volver-atras-izquierda">
        <div class="texto-atras-izquierda">GESTIONA<br />TUS PEDIDOS</div>
    </div>
	</a>
    <%}%>

    <div class="contenido" >
        <ul>

            <% foreach (Dominio.Insumo item in ListaMenu){ %>

            
            <li class="col-md-6 col-lg-4 project" data-groups="[&quot;skill1&quot;]" style="backdrop-filter: blur(5px)">
                            
                            <%if (((Dominio.Persona)Session["UserLog"]) != null && verificarStock(1, item.Id))
                                {%>

                            <a href="Mesa.aspx?id=<%=item.Id %>" class="hovereffect" >
                                <img class="img-responsive" src="<% =item.UrlImagen %>"  alt="" onerror="this.src='https://i.postimg.cc/FKLCS5hD/404.png'" style="object-fit:scale-down; width:400px; height:200px; border: 10px solid #000; background-image: url(https://th.bing.com/th/id/OIP.8KI1Em2sYcNrxizTdGdGlAHaDt?pid=ImgDet&rs=1)">
                            </a>
                             <%}else{%>

                                <div style="border: 10px solid #000; background-image: url(https://th.bing.com/th/id/OIP.8KI1Em2sYcNrxizTdGdGlAHaDt?pid=ImgDet&rs=1)">
                                    <img class="img-responsive" src="<% =item.UrlImagen %>"  alt="" onerror="this.src='https://i.postimg.cc/FKLCS5hD/404.png'" style="object-fit:scale-down; width:400px; height:200px;">
                                </div>
                            <%}%>
          

                    <div class="card-body">
                        <h4 class="card-text mt-5 mb-0 fs-14"><b><% =item.Nombre %></b></h4>
                        <h5 class="card-text mt-5 mb-0 fs-14"><% =item.Categoria.Descripcion %>, <% =item.Tipo.Descripcion %></h5>
                        <h5 class="card-text mt-5 mb-0 fs-14"><b>
                            &nbsp</b><% ="$" + string.Format("{0:00.00}",item.Precio)%></h5>
                    </div>
            </li>

            <% } %>



        </ul>
        </div>
</asp:Content>
