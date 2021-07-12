<%@ Page Title="Menu" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="RestoApp2.Menu" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
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

    <a href="Mesa.aspx">
    <div class="volver-atras-izquierda">
        <div class="texto-atras-izquierda">GESTIONA<br />TUS PEDIDOS</div>
    </div>
	</a>


    <div class="contenido">
        <ul>

            <% foreach (Dominio.Insumo item in ListaMenu){ %>

            
            <li class="col-md-6 col-lg-4 project" data-groups="[&quot;skill1&quot;]">
                            <a href="Mesa.aspx?id=<%=item.Id %>" class="hovereffect">
                                <img class="img-responsive" src="<% =item.UrlImagen %>" alt="" onerror="this.src='https://i.postimg.cc/FKLCS5hD/404.png'" style="object-fit:scale-down; width:400px; height:200px;">
                            </a>
                    <div class="card-body">
                        <h4 class="card-text mt-5 mb-0 fs-14"><b><% =item.Nombre %></b></h4>
                        <h5 class="card-text mt-5 mb-0 fs-14"><% =item.Categoria.Descripcion %>, <% =item.Tipo.Descripcion %></h5>
                        <h5 class="card-text mt-5 mb-0 fs-14"><b>PRECIO &nbsp</b><% =item.Precio %></h5>
                    </div>
            </li>

            <% } %>



        </ul>
        </div>
</asp:Content>
