<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Moderador.aspx.cs" Inherits="LiberForum.Moderador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Moderador - Liberfórum</title>
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
                    <%if (Session["usuario"] == null) {%>
                    <ul class="nav navbar-nav">
                        <li role="presentation"><a href="Login.aspx">Login</a></li>
                    </ul>
                    <%} %>
                    <p class="navbar-text navbar-right actions"> <a class="btn btn-default action-button" role="button" href="NewPost.aspx">Novo Post</a></p>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=DESKTOP-PIT72D7\SQLEXPRESS;Initial Catalog=bd_forum;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [email], [moderador] FROM [Usuario]"></asp:SqlDataSource>
                </div>
            </div>
        </nav>
    </div>
        <div id="mainContainer" class="container">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover" DataKeyNames="email" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowCommand="GridView1_RowCommand1">
                        <Columns>
                            <asp:BoundField DataField="email" HeaderText="email" ReadOnly="True" SortExpression="email" />
                            <asp:CheckBoxField DataField="moderador" HeaderText="Moderação" SortExpression="moderador">
                            <HeaderStyle Width="10px" />
                            </asp:CheckBoxField>
                            <asp:ButtonField ButtonType="Button" CommandName="Update" HeaderText="Moderador" ShowHeader="True" Text="Alterar" ControlStyle-CssClass ="btn btn-light">
<ControlStyle CssClass="btn btn-success"></ControlStyle>

                            <HeaderStyle Width="10px" />
                            </asp:ButtonField>
                            <asp:ButtonField ButtonType="Button" CommandName="Delete"  HeaderText="Ação" ShowHeader="True" Text="Banir" ControlStyle-CssClass="btn btn-danger">
<ControlStyle CssClass="btn btn-danger"></ControlStyle>

                            <HeaderStyle Width="10px" />
                            </asp:ButtonField>
                        </Columns>
        </asp:GridView>
        </div>
    </form>

</body>
</html>