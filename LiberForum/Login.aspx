<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LiberForum.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login - Liberfórum</title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet"/>
    <link href="../assets/css/login.styles.min.css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-card"><img src="../assets/img/lib.png" class="profile-img-card">
            <p class="profile-name-card"> </p>
            <form class="form-signin"><span class="reauth-email"> </span>
            <asp:TextBox CssClass="form-control" ID="inputEmail" runat="server" placeholder="Email"></asp:TextBox>
            <asp:TextBox CssClass="form-control" ID="inputPassword" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
            <div class="checkbox">
                <div class="checkbox">
                    <label>
                        <input type="checkbox">Lembre-se de mim</label>
                </div>
            </div>
            <asp:LinkButton ID="btnLogin" CssClass="btn btn-primary btn-block btn-lg btn-signin" runat="server" OnClick="btnLogin_Click" Text ="Sign in"></asp:LinkButton>
            <br /> 
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a title="Registrar-se" accesskey="j" href="Register.aspx">Registrar-se</a>
            </form>
   </form>
</body>
</html>
