﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RuRo.Web.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="include/jquery-easyui-1.4.2/jquery.min.js"></script>
    <script src="include/jquery-easyui-1.4.2/jquery.easyui.min.js"></script>
    <link href="include/jquery-easyui-1.4.2/themes/default/easyui.css" rel="stylesheet" />
    <link href="include/css/default.css" rel="stylesheet" />
    <link href="include/jquery-easyui-1.4.2/themes/icon.css" rel="stylesheet" />
    <%--<script src="include/js/page.js"></script>--%>
    <%--<script src="include/js/sy_func.js"></script>--%>
    <title>FreezerPro</title>
    <script type="text/javascript">
        //初始化win弹窗在显示器中央
        function doimport() {
            var width = 920;
            var height = 600;
            var l = Math.round((window.screen.width - width) / 2);
            var t = Math.round((window.screen.height - height) / 2);
            window.open('Login.aspx', 'newwindow', 'height=' + height + ', width=' + width + ', top=' + t + ',left=' + l + ',toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, status=no')
        }

    </script>
</head>
<body style="width: 100%; height: 100%">
    <%--嵌套页--%>
    <iframe runat="server" id="FreezerPro" name="FreezerPro" frameborder="0" style="width: 100%; height: 100%;"></iframe>
    <form action="/" method="post" runat="server" id="from">
        <%--菜单栏--%>
        <div id="MenuBar" runat="server"><a href="#" id="btnextend" onclick="doimport()" >扩展</a></div>
        
    </form>
</body>
</html>
