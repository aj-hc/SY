<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebTest1.aspx.cs" Inherits="RuRo.Web.TestData.WebTest1" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../include/jquery-easyui-1.4.3/jquery.min.js"></script>
    <script src="../include/jquery-easyui-1.4.3/jquery.easyui.min.js"></script>
    <link href="../include/jquery-easyui-1.4.3/themes/default/easyui.css" rel="stylesheet" />
    <link href="../include/jquery-easyui-1.4.3/themes/icon.css" rel="stylesheet" />
    <link href="include/css/default.css" rel="stylesheet" />
    <title></title>
    <script type="text/javascript">
        //$(function () {
        //    $('#win').window({
        //        width: 600,
        //        height: 400,
        //        modal: true,
        //        href: '1.html',
        //        closed: true
        //    })
        //})

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <%--<div>
        <a href="#" onclick="PostDataToFp()">content</a>
        <a href="javascript:void(0)" class="easyui-linkbutton" onclick="$('#win').window('open')">Open</a>
    </div>
        <div id="win"></div> --%>
    
       url:
        <asp:TextBox ID="url" runat="server" Style="width: 100%"></asp:TextBox>
        data:
        <asp:TextBox ID="data" runat="server" Style="width: 100%; height: 300px;" TextMode="MultiLine"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" Text="提交" OnClick="Button1_Click" />
        <br />
        结果:<asp:Label ID="res" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>
