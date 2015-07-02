<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BasedInfoTest.aspx.cs" Inherits="RuRo.Web.Fp_ExtendPage.BasedInfoTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:TextBox runat="server" ID="txtBasedInfo"></asp:TextBox>
        <asp:Button ID="ok" runat="server" OnClick="ok_Click" />
    </div>
    </form>
</body>
</html>
