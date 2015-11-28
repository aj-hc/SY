<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImportTestData.aspx.cs" Inherits="RuRo.Web.TestData.ImportTestData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../include/jquery-easyui-1.4.3/jquery.min.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server" action="ImportTestData.aspx">
        <div>
          <label>账号：</label><asp:TextBox runat="server" ID="U" Text="admin"></asp:TextBox>
            <label>密码：</label><asp:TextBox runat="server" ID="P" Text="123456"></asp:TextBox>
            <label>源：</label><asp:TextBox runat="server" ID="Y" ></asp:TextBox>
            <label>网络链接地址：</label><asp:TextBox runat="server" ID="W" ></asp:TextBox>
            <label>图片网络链接地址：</label><asp:TextBox runat="server" ID="T" ></asp:TextBox>
            <asp:Button  runat="server" OnClick="Unnamed_Click"/>
        </div>
    </form>
</body>
</html>
