<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClinicalInfo.aspx.cs" Inherits="RuRo.Web.Fp_ExtendPage.ClinicalInfo" %>
<!doctype html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../include/jquery-easyui-1.4.3/jquery.min.js"></script>
    <script src="../include/jquery-easyui-1.4.3/jquery.easyui.min.js"></script>
    <script src="../include/js/default.js"></script>
    <link href="../include/jquery-easyui-1.4.3/themes/default/easyui.css" rel="stylesheet" />
    <link href="../include/jquery-easyui-1.4.3/themes/icon.css" rel="stylesheet" />
    <script src="../include/js/page.js"></script>
    <title></title>
    <style type="text/css">
        .easyui-panel {
            width: 800px;
            padding: 10px;
        }
    </style>
</head>
<body>
    <form id="form1">
        <%--1、临床信息列表展现--%>
        <%--2、临床信息详细信息展现--%>
        <%--3、单独导入临床信息操作--%>
       <div class="easyui-panel"><div id="ClinicalInfoDg" style="height:340px;width:100%"></div></div>
    </form>

</body>

</html>
