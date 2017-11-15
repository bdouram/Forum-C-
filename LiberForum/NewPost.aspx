<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewPost.aspx.cs" Inherits="LiberForum.NewPost" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
                    <p class="navbar-text navbar-right actions">  <asp:LinkButton ID="LinkButton1" CssClass="btn btn-default action-button" runat="server" OnClick="btnSair_Click" Text ="Logout"></asp:LinkButton></p>
                </div>
            </div>
        </nav>
    </div>
        <!-- Corpo-->
         <br />  
        <div id="mainContainer" class="container">  
            <div class="row">
                <div class="col-md-12">
                     <div class="form-group">
                          <label for="usr">Título:</label>
                          <asp:TextBox CssClass="form-control" ID="TextTitle" runat="server"></asp:TextBox>
                         <br />
                        <label for="comment">Pergunta:</label>
                            <asp:TextBox id="TextArea" CssClass="form-control" TextMode="multiline" Columns="50" Rows="5" runat="server" />
                            <div class="row">
                            </div>
                     </div> 
                    <asp:LinkButton ID="btnLogin" CssClass="btn btn-primary btn-block btn-lg btn-signin" runat="server" OnClick="btnSalvar_Click" Text ="Postar"></asp:LinkButton>   
                </div>
            </div>
        </div>
    </form>
    <br/>
</body>
</html>

