<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Text.aspx.cs" Inherits="RuRo.Web.Text" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <td class="style1"> 
            <asp:FileUpload ID="FileUpload1" runat="server"  />
            <asp:Button ID="Button1" runat="server" Text="上传一般图片" onclick="Button1_Click" />
        </td>
            <td class="style3"> 
            <asp:Image ID="Image1" runat="server" Height="200px" Width="200px" /> 
        </td>
    </form>
</body>
</html>
