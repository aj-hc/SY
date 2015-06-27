<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RuRo.Web.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="include/jquery-easyui-1.4.2/jquery.min.js"></script>
    <script src="include/jquery-easyui-1.4.2/jquery.easyui.min.js"></script>
    <link href="include/jquery-easyui-1.4.2/themes/default/easyui.css" rel="stylesheet" />
    <link href="include/css/default.css" rel="stylesheet" />
    <link href="include/jquery-easyui-1.4.2/themes/icon.css" rel="stylesheet" />
    <script src="include/js/page.js"></script>
    <script src="include/js/sy_func.js"></script>
    <title>FreezerPro</title>
</head>
<body style="width:100%;height:100%">
    <%--嵌套页--%>
   <iframe runat="server" id="FreezerPro" name="FreezerPro" frameborder="0" style="width:100%;height:100%;"></iframe>
    <form action="/" method="post" runat="server" id="from">
        <%--菜单栏--%>
    <div id="MenuBar" runat="server">
        <a href="#"  onclick="but()" id="btnextend" >扩展</a>
    </div>
    </form>
    <!--登陆框-->
    <div id="Login" class="easyui-dialog" style="width: 300px; padding: 30px 50px 20px 50px" title="请登录助手" closed="true">
        <form id="frmLogin">
            <div style="margin-bottom: 10px">
                <input class="easyui-textbox" id="username" name="username" style="width: 100%; height: 40px; padding: 12px" data-options="prompt:'username',iconCls:'icon-man',iconWidth:38" />
            </div>
            <div style="margin-bottom: 20px">
                <input class="easyui-textbox" id="password" name="password" style="width: 100%; height: 40px; padding: 12px" type="password" data-options="prompt:'password',iconCls:'icon-lock',iconWidth:38" />
            </div>
            <div style="text-align: center; padding: 5px">
                <a href="javascript:void(0)" style="margin: 0px 10px 0px 10px" class="easyui-linkbutton" onclick="login()">登陆</a>
                <a href="javascript:void(0)" style="margin: 0px 10px 0px 10px" class=" easyui-linkbutton" onclick="$('#Login').dialog('close')">取消</a>
            </div>
        </form>
    </div>
</body>
</html>
