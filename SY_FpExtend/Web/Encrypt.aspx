<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Encrypt.aspx.cs" Inherits="RuRo.Web.Encrypt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <Label>服务器:</Label> <asp:TextBox ID="txtFuWu" runat="server"></asp:TextBox>
        <br></br>
        <Label>账__号:</Label> <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
        <br></br>
        <Label>密__码:</Label> <asp:TextBox ID="txtPwd" runat="server" TextMode="Password"></asp:TextBox>
        <br></br>
        <Label>数据库:</Label> <asp:TextBox ID="txtSql" runat="server"></asp:TextBox>
        <br></br>
        <asp:Button runat="server" ID="ok" Text="翻滚吧！牛宝宝" OnClick="ok_Click" />
        <div></div>
        <br></br>
        <asp:TextBox runat="server" ID="txtEncrypt" TextMode="MultiLine" Height="131px" Width="388px"></asp:TextBox>
    </div>
    </form>
</body>
</html>
