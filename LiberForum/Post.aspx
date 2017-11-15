<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Post.aspx.cs" Inherits="LiberForum.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Postagens</title>
     <link href="../Content/bootstrap.min.css" rel="stylesheet"/>
    <link href="../assets/css/bar.styles.min.css" rel="stylesheet"/>
</head>
<body style="height: 720px">
    <form id="form1" runat="server">
                <div></div>
    <div>
        <nav class="navbar navbar-default navigation-clean-button">
            <div class="container">
                <div class="navbar-header"><a class="navbar-brand" href="Home.aspx">LiberFórum</a>
                    <button class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navcol-1"><span class="sr-only">Toggle navigation</span><span class="icon-bar"></span><span class="icon-bar"></span><span class="icon-bar"></span></button>
                </div>
                <div class="collapse navbar-collapse" id="navcol-1">
                    <%if (Session["usuario"] != null) {%>
                        <p class="navbar-text navbar-right actions">  <asp:LinkButton ID="LinkButton1" CssClass="btn btn-default action-button" runat="server" OnClick="btnSair_Click" Text ="Logout"></asp:LinkButton></p>
                    <%} %>
                    <%if (Session["usuario"] == null) {%>
                    <ul class="nav navbar-nav">
                        <li role="presentation"><a href="Login.aspx">Login</a></li>
                    </ul>
                    <%} %>
                    <% if (Session["moderador"] != null) {%>
                        <p class="navbar-text navbar-right actions"> <a class="btn btn-default action-button" role="button" href="Moderador.aspx">Moderação</a></p>
                    <%} %>
                    <p class="navbar-text navbar-right actions"> <a class="btn btn-default action-button" role="button" href="NewPost.aspx">Novo Post</a></p>
                </div>
            </div>
        </nav>
    </div>
        <!-- Corpo-->
         <br />  
        <div id="mainContainer" class="container">  
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-primary">
                        <div class="panel-heading"><b>Pergunta:</b>&nbsp <%=Titulo %><br /><small><small><b>Usuário:</b>&nbsp <%=Autor%></small></small></div>
                            <div class="panel-body" style="text-align:justify">
                                <%=Texto %>
                                <div class="row">
                                    <div class="col-md-11"></div>
                                    <div class="col-md-1">
                                        <%if (Autor.Equals(Session["usuario"]) || Session["moderador"]!=null){ %>
                                            <a title="Editar" accesskey="j" href="EditarPost.aspx?post=<%=Id_Postagem %>">Editar</a>
                                        <%} %>
                                    </div>
                                </div>
                             </div>
                    </div>


                    <%foreach(KeyValuePair<string, string> usuario in Comentarios){ %>
                    <% int i = 0; while (!usuario.Key.ElementAt(i).Equals('/')) { i++; } %>
                    <div class="panel panel-info">
                        <div class="panel-heading"><b>Usuário:</b>&nbsp <%=usuario.Key.Substring(0,i)%><br /><small><small><b>Resposta</b></small></small></div>
                            <div class="panel-body" style="text-align:justify">
                                <%=usuario.Value%>
                                 <div class="row">
                                    <div class="col-md-11"></div>
                                        <div class="col-md-1">
                                            <%if (usuario.Key.Substring(0,i).Equals(Session["usuario"]) || Session["moderador"]!=null){ %>
                                                <a title="Editar" accesskey="j" href="Editar.aspx?post=<%=usuario.Key.Substring(i+1) %>&retorno=<%=Id_Postagem %>">Editar</a>
                                            <%}%>
                                        </div>
                                </div>
                             </div>
                    </div>
                    <%} %>

                    <% if (Session["usuario"] != null){ %> 
                        <div class="form-group">
                            <label for="comment">Comentário:</label>
                            <asp:TextBox id="TextArea" CssClass="form-control" TextMode="multiline" Columns="50" Rows="5" runat="server" />
                        </div>
                        <asp:LinkButton ID="btnComentar" CssClass="btn btn-primary" runat="server" OnClick="btnComentar_Click" Text ="Responder"></asp:LinkButton>
                    <%} %>
                </div>
            </div>
        </div>
    </form>
    <br/>
</body>
</html>
