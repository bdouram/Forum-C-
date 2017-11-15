<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="LiberForum.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Fórum</title>
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
    <div></div>

        <!-- Corpo-->
         <br />  
        <div id="mainContainer" class="container">  
            <div class="shadowBox">  
                <div class="page-container">  
                    <div class="container">  
                        <div class="jumbotron">  
                            <p class="text-danger">Postagens presentes no sistema</p>  
                            <span class="text-info">Escolha um tópico de sua preferência e clique em detalhes.</span>  
                        </div>  
                        <div class="row">  
                            <div class="col-lg-12 ">  
                                <div class="table-responsive">  
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=DESKTOP-PIT72D7\SQLEXPRESS;Initial Catalog=bd_forum;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT p.id_post, p.titulo FROM Post p ORDER BY p.id_post DESC"></asp:SqlDataSource>
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id_post" CssClass="table table-striped table-bordered table-hover" DataSourceID="SqlDataSource1" AllowPaging="True" EmptyDataText="Desculpe, não há post's. O fórum está um pouco vazio, adicione um tópico">
                                        <Columns>
                                            <asp:BoundField DataField="id_post" HeaderText="id_post" InsertVisible="False" ReadOnly="True" SortExpression="id_post" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" >
<HeaderStyle CssClass="visible-lg"></HeaderStyle>

<ItemStyle CssClass="visible-lg" Width="10px"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="titulo" HeaderText="Titulo" SortExpression="titulo" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg">
<HeaderStyle CssClass="visible-lg"></HeaderStyle>

<ItemStyle CssClass="visible-lg"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:HyperLinkField DataNavigateUrlFields="id_post" DataNavigateUrlFormatString="Post.aspx?post={0}" HeaderText="Postagem" Text="Ler..." HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg">
<HeaderStyle CssClass="visible-lg"></HeaderStyle>

<ItemStyle CssClass="visible-lg" Width="10px"></ItemStyle>
                                            </asp:HyperLinkField>
                                        </Columns>
                                    </asp:GridView>
                                </div>  
                            </div>  
                        </div>  
                    </div>  
                </div>  
            </div>  
        </div>   
    </form>
</body>
</html>
