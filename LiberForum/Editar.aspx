<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="LiberForum.Editar" %>

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
                    <p class="navbar-text navbar-right actions"> <a class="btn btn-default action-button" role="button" href="#">Sign Up</a></p>
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
                        <label for="comment">Comentário:</label>
                            <asp:TextBox id="TextArea" CssClass="form-control" TextMode="multiline" Columns="50" Rows="5" runat="server" />
                            <div class="row">
                                <asp:LinkButton ID="btnAlterar" CssClass="btn btn-primary btn-block btn-lg btn-signin" runat="server" OnClick="btnSalvar_Click" Text ="Alterar"></asp:LinkButton>   
                                <asp:LinkButton ID="btnApagar" CssClass="btn btn-danger btn-block btn-lg btn-signin" runat="server" OnClientClick = "Confirm()" OnClick="btnApagar_Click" Text ="Apagar"></asp:LinkButton> 
                            </div>
                     </div> 
                </div>
            </div>
        </div>
    </form>
    <br/>


    <script type = "text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Você deseja mesmo apagar o comentário?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
</body>
</html>

