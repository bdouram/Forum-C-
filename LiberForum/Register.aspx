<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="LiberForum.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Registrar - Liberfórum</title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet"/>
    <link href="../assets/css/bar.styles.min.css" rel="stylesheet"/>
</head>
<body style="height: 720px">
    <form id="form1" runat="server">
                <div></div>
    <div>
        <nav class="navbar navbar-default navigation-clean-button">
            <div class="container">
                <div class="navbar-header"><a class="navbar-brand" href="#">LiberFórum</a>
                    <button class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navcol-1"><span class="sr-only">Toggle navigation</span><span class="icon-bar"></span><span class="icon-bar"></span><span class="icon-bar"></span></button>
                </div>
                <div class="collapse navbar-collapse" id="navcol-1">
                    <%if (Session["usuario"] == null) {%>
                    <ul class="nav navbar-nav">
                        <li role="presentation"><a href="Login.aspx">Login</a></li>
                    </ul>
                    <%} %>
                    <p class="navbar-text navbar-right actions"> <a class="btn btn-default action-button" role="button" href="NewPost.aspx">Novo Post</a></p>
                </div>
            </div>
        </nav>
    </div>
    <div id="mainContainer" class="container">
        <div class="col-md-4">
        </div>
        <div class="col-md-4">
            <form>
                <div class="form-group">
                    <label for="exampleInputEmail1">Email</label>
                    <asp:TextBox CssClass="form-control" ID="inputEmail" runat="server" placeholder="Email"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="exampleInputPassword1">Senha</label>
                    <asp:TextBox CssClass="form-control" ID="inputPassword" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                </div>
                <br />
                    <asp:LinkButton ID="btnLogin" CssClass="btn btn-primary" runat="server" OnClick="btnRegistrar_Click" Text ="Registrar"></asp:LinkButton>
            </form>
        </div>
        <div class="col-md-4">

        </div>
    </div>
   </form>
</body>
</html>
