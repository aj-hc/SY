<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PostDataTest.aspx.cs" Inherits="RuRo.Web.TestData.PostDataTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="账号" ></asp:Label><asp:TextBox ID="username" runat="server"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Text="密码" ></asp:Label><asp:TextBox ID="password" runat="server"></asp:TextBox>
        <asp:Label ID="Label3" runat="server" Text="方法" ></asp:Label><asp:TextBox ID="method" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Button"  OnClick="Button1_Click"/>
        <asp:Label ID="Label4" runat="server" Text="result"></asp:Label>
    </div>
    </form>
</body>
</html>
