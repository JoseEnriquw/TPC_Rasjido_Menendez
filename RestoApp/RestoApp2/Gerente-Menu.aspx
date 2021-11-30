<%@ Page Title="RESTOAPP - TU MEJOR RESTAURANT!" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Gerente-Menu.aspx.cs" Inherits="RestoApp2.Gerente_Menu" EnableEventValidation="false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>TU MENU</h1>
        <p class="lead">Personaliza tus ventas!</p>


        <table class="filter">
            <tr>
                <td class="item-filter">INSUMO:
                    <asp:TextBox ID="TB_Insumo" runat="server" CssClass="drop" OnTextChanged="OnTextChanged_Filtros" Text=" " AutoPostBack="true"></asp:TextBox></td>
                <td class="item-filter">CATEGORIA:
                    <asp:DropDownList ID="DDL_Categorias" runat="server" CssClass="drop" OnTextChanged="OnTextChanged_Filtros" AutoPostBack="true"></asp:DropDownList></td>
                <td class="item-filter">TIPO DE INSUMO:
                    <asp:DropDownList ID="DDL_Tipo_Insumo" runat="server" CssClass="drop" OnTextChanged="OnTextChanged_Filtros" AutoPostBack="true"></asp:DropDownList></td>

            </tr>
        </table>
    </div>


    <%/*PANELES DE NAVEGACION*/%>

    <a href="Gerente.aspx">
        <div class="volver-atras-izquierda">
            <div class="texto-atras-izquierda">
                MENU
                <br />
                GERENTE
            </div>
        </div>
    </a>

    <a href="Gerente-stock.aspx">
        <div class="volver-atras-derecha-1">
            <div class="texto-atras-derecha">
                GESTIONAR
                <br />
                STOCK
            </div>
        </div>
    </a>

    <a href="Gerente-Personal.aspx">
        <div class="volver-atras-derecha-2">
            <div class="texto-atras-derecha">
                VER
                <br />
                PERSONAL
            </div>
        </div>
    </a>

    <%/*INICIO DEL CONTENIDO*/%>

    <div class="contenido">




        <div id="tablaactiva" style="display: block">
            <div class="row social">

                <div class="col-md-12">
                    <a href="javascript:listainactiva()">
                        <div class="panel" style="background-image: url(https://th.bing.com/th/id/OIP.8KI1Em2sYcNrxizTdGdGlAHaDt?pid=ImgDet&rs=1)">
                            <div class="panel-body text-center">
                                <small style="font-size: 30px; color: #fff">VER LOS INSUMOS DESCONTINUADOS</small>
                            </div>
                        </div>
                    </a>
                </div>
            </div>

            <%coloropc = 0;%>




            <table class="table user-list" style="margin-bottom: 0">
                <thead>
                    <tr>
                        <th style="width: 21%"><span>FOTO</span></th>
                        <th><span>INSUMO</span></th>
                        <th style="width: 10%"><span>CATEGORIA</span></th>
                        <th style="width: 10%"> <span>INSUMO</span></th>
                        <th><span>PRECIO</span></th>
                        <th class="text-right"><span>OPCIONES</span></th>
                    </tr>
                </thead>



                <tbody>

                    <tr style="background: #555;">
                        <td>
                            <asp:TextBox ID="UrlNew" runat="server" Style="z-index: 1; width: 100%" TextMode="Url" placeholder="Pagina.com//Imagen/Ejemplo.jpg"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="InsumoNew" runat="server" Style="z-index: 1;" TextMode="SingleLine" placeholder="Nombre del insumo"></asp:TextBox>
                        </td>
                        <td>
                            <asp:DropDownList ID="DDL_Categorias_Agregar" runat="server"></asp:DropDownList>

                        </td>
                        <td>
                            <asp:DropDownList ID="DDL_TipoInsumo_Agregar" runat="server"></asp:DropDownList>

                        </td>

                        <td>
                            <asp:TextBox ID="PrecioNew" runat="server" Style="z-index: 1;" onkeypress="javascript:return solonumeros(event)" placeholder="888.88"></asp:TextBox>
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

                                    if ((key != 44 && key < 48) || key > 57) {
                                        return false;
                                    }

                                    return true;
                                }
                            </script>
                        </td>
                        <td class="text-right">
                            <asp:Button ID="ButtonAdd" runat="server" Text="AGREGAR" class="btn btn-theme" OnClick="ConfirmAgregar" Width="160PX"/>
                        </td>
                    </tr>
                </tbody>
            </table>


            <div style="height: 280px; overflow: scroll; background-image: url(https://th.bing.com/th/id/OIP.8KI1Em2sYcNrxizTdGdGlAHaDt?pid=ImgDet&rs=1)">
                <table class="table user-list" style="padding-bottom: 0">
                    <asp:Repeater runat="server" ID="repeaterMenu">
                        <ItemTemplate>
                            <%if (coloropc % 2 == 0)
                                {%>
                            <tr style="background: #eee;">
                                <%}
                                    else
                                    {%>
                            <tr style="background: #bbb;">
                                <%}%>
                                <td rowspan="2">
                                    <asp:Image ID="Img" runat="server" Style="z-index: 1; height: 100px; width: 100%; background-size: auto; border: 2px solid #000; background-color: black" />
                                </td>
                                <td>
                                    <asp:TextBox ID="Insumo" runat="server" Style="z-index: 1;" TextMode="SingleLine" AutoPostBack="true"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DDL_Categorias_Item" runat="server"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DDL_TipoInsumo_Item" runat="server"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox ID="Precio" runat="server" Style="z-index: 1;" AutoPostBack="true" onkeypress="javascript:return solonumeros(event)"></asp:TextBox>
                                </td>
                                <td class="text-right">
                                    <asp:Button ID="Button1" runat="server" Text="MODIFICAR" class="btn btn-theme" OnClick="ConfirmActualizar" CommandArgument='<%#Eval("Id")%>' Width="140PX"/>
                                </td>

                            </tr>
                            <%if (coloropc % 2 == 0)
                                {%>
                            <tr style="background: #eee;">
                                <%}
                                    else
                                    {%>
                            <tr style="background: #bbb;">
                                <%}%>
                                <td colspan="3">URL
                            <asp:TextBox ID="Url" runat="server" Style="z-index: 1;" TextMode="Url" AutoPostBack="true" Width="100%"></asp:TextBox></td><td>
                                    
                                </td>
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

                                            if ((key != 44 && key < 48) || key > 57) {
                                                return false;
                                            }

                                            return true;
                                        }
                                    </script>
                                    <td class="text-right">
                                        <asp:Button ID="Button3" runat="server" Text="DAR DE BAJA" class="btn btn-theme" OnClick="ConfirmBorrar" CommandArgument='<%#Eval("Id")%>' Width="140PX"/></td>
                            </tr>

                            <%coloropc++;%>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </div>



        <%/*TABLA INACTIVA*/%>

        <div id="tablainactiva" style="display: none">
            <div class="row social">

                <div class="col-md-12">
                    <a href="javascript:listaactiva()">
                        <div class="panel" style="background-image: url(https://th.bing.com/th/id/OIP.8KI1Em2sYcNrxizTdGdGlAHaDt?pid=ImgDet&rs=1)">
                            <div class="panel-body text-center">
                                <small style="font-size: 30px; color: #fff">VER LOS INSUMOS ACTIVOS</small>
                            </div>
                        </div>
                    </a>
                </div>
            </div>

            <table class="table user-list" style="margin-bottom: 0">
                <thead>
                    <tr>
                        <th style="width: 15%"><span>FOTO</span></th>
                        <th style="width: 35%"><span>INSUMO</span></th>
                        <th style="width: 17%"><span>CATEGORIA</span></th>
                        <th><span>PRECIO</span></th>
                        <th class="text-right"><span>OPCIONES</span></th>
                    </tr>
                </thead>
            </table>


            <div style="height: 333px; overflow: scroll; background-image: url(https://th.bing.com/th/id/OIP.8KI1Em2sYcNrxizTdGdGlAHaDt?pid=ImgDet&rs=1)">
                <table class="table user-list" style="padding-bottom: 0">
                    <asp:Repeater runat="server" ID="repeaterMenu2">
                        <ItemTemplate>
                            <%if (coloropc % 2 == 0)
                                {%>
                            <tr style="background: #eee;">
                                <%}
                                    else
                                    {%>
                            <tr style="background: #bbb;">
                                <%}%>
                                <td rowspan="2">
                                    <asp:Image ID="Img2" runat="server" Style="z-index: 1; height: 100px; width: 100%; background-size: auto; border: 2px solid #000; background-color: black;" />
                                </td>
                                <td>
                                    <asp:TextBox ID="Insumo2" runat="server" Style="z-index: 1;" TextMode="SingleLine" AutoPostBack="true" Enabled="false"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_Categorias_Item2" runat="server" Style="z-index: 1;" TextMode="SingleLine" AutoPostBack="true" Enabled="false"></asp:TextBox>
                                </td>
                                <td>
                                      <asp:TextBox ID="txt_TipoInsumo_Item2" runat="server" Style="z-index: 1;" TextMode="SingleLine" AutoPostBack="true" Enabled="false"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="Precio2" runat="server" Style="z-index: 1;" AutoPostBack="true" Enabled="false"></asp:TextBox>
                                </td>
                                <td class="text-right">
                                    <asp:Button ID="ButtonReactivar" runat="server" Text="REACTIVAR" class="btn btn-theme" CommandArgument='<%#Eval("Id")%>' OnClick="ConfirmReactivar" Width="140PX"/>
                                </td>

                            </tr>
                            <%if (coloropc % 2 == 0)
                                {%>
                            <tr style="background: #eee;">
                                <%}
                                    else
                                    {%>
                            <tr style="background: #bbb;">
                                <%}%>
                                <td colspan="4">URL
                                 <asp:TextBox ID="Url2" runat="server" Style="z-index: 1;" TextMode="Url" AutoPostBack="true" Enabled="false" Width="100%"></asp:TextBox>
                                <td>
                                  
                                </td>
                            </tr>

                            <%coloropc++;%>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>













        </div>
    </div>


    <div id="ventanaEmergente" class="ventanaEmerg" style="background: #232528; border: 6px solid #009ffd; color: #fff; position: absolute; top: 40%; width: 21%; height: 29%; left: 60%; text-align: center; z-index: 10; display: none; animation-direction: reverse; animation-delay: 10s;">
        <h1 style="color: #fca014">HUBO UN ERROR!</h1>
        DEBE COMPLETAR TODOS LOS CAMPOS!
        <br />
        <br />
        <br />
        <asp:Button ID="Button3" runat="server" Text="CONTINUAR" CssClass="btn btn-theme" />
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

    <script>
        function abrirventanaEmerg_Borrar() {

            document.getElementById("mensajeConf_borrar").style.display = "block";
            document.body.style.visibility = "visible: false";

        }
    </script>


    <div id="mensajeConf_borrar" class="ventanaEmerg" style="background: #232528; border: 6px solid #009ffd; color: #fff; position: absolute; top: 47%; width: 30%; height: 30%; left: 35%; text-align: center; z-index: 10; display: none; animation-direction: reverse; animation-delay: 10s;">
        <h1 style="color: #fca014">ESTAS POR REALIZAR CAMBIOS</h1>
        <p>¿Estas seguro de querer aplicar estos cambios?</p>

        <asp:Button ID="jsBorrar" runat="server" Text="BORRAR" class="btn btn-theme" OnClick="Borrar" />
        <asp:Button ID="jsActualizar" runat="server" Text="ACTUALIZAR" class="btn btn-theme" OnClick="Actualizar" />
        <asp:Button ID="jsReactivar" runat="server" Text="REACTIVAR" class="btn btn-theme" OnClick="Reactivar_Insumo" />
        <asp:Button ID="jsAgregar" runat="server" Text="AGREGAR" class="btn btn-theme" OnClick="Agregar" />
        <asp:Button ID="no" runat="server" Text="CANCELAR!" class="btn btn-theme" />

    </div>
</asp:Content>
