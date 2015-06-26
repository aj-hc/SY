<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BaseInfo.aspx.cs" Inherits="RuRo.Web.Fp_ExtendPage.BaseInfo" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../include/jquery-easyui-1.4.2/jquery.min.js"></script>
    <script src="../include/jquery-easyui-1.4.2/jquery.easyui.min.js"></script>
    <script src="../include/js/default.js"></script>
    <link href="../include/jquery-easyui-1.4.2/themes/default/easyui.css" rel="stylesheet" />
    <link href="../include/jquery-easyui-1.4.2/themes/icon.css" rel="stylesheet" />
    <script src="../include/js/page.js"></script>
    <title></title>
    <style type="text/css">
        table tr td {
            text-align: right;
            padding: 2px;
        }

        input {
            width: 200px;
        }

        .h {
            margin: 3px;
        }

        .easyui-panel {
            width: 100%;
            padding: 10px;
            margin: 0px;
        }

            .easyui-panel div {
                padding: 5px;
            }
    </style>
    <script type="text/javascript">
    </script>
</head>
<body id="body">
    <%--1、搜索框信息--%>
    <%--2、搜索操作--%>
    <%--3、基本信息展现--%>
    <%--http://localhost:3448/Fp_ExtendPage/BaseInfo.aspx--%>
    <form id="querybycodeform">
        <div class="easyui-panel">
            <div><b>查找患者</b></div>
            <div runat="server">
                查找方式：
                <input id="In_CodeType" class="easyui-combobox" name="querybycode" style="width: 200px;" />
                <input id="In_Code" class="easyui-textbox" />
                <a href="#" onclick="querybycode()" class="easyui-linkbutton">查询患者信息</a>
            </div>
        </div>
    </form>
    <form id="mainform">
        <div class="h"></div>
        <div class="easyui-panel">
            <div style="padding: 2px"><b>患者基本资料</b></div>
            <div id="BaseInfoDiv" runat="server" style="padding: 5px;">
                <table>
                    <tr>
                        <td>姓名：</td>
                        <td>
                            <input class="easyui-textbox" type="text" name="_80" id="_80" data-options="required:true" /></td>
                        <td class="name">住院号：</td>
                        <td>
                            <input class="easyui-textbox" type="text" name="_81" id="_81" data-options="required:false" /></td>
                        <td>就诊卡号：</td>
                        <td>
                            <input class="easyui-textbox" type="text" name="_82" id="_82" data-options="required:false" /></td>
                    </tr>
                    <tr>
                        <td>性别：</td>
                        <td>
                            <input class="easyui-combobox" name="_115" id="_115" style="width: 204px" data-options=" required:false " />
                        </td>
                        <td>出生日期：</td>
                        <td>
                            <input class="easyui-datebox" type="text" name="_84" id="_84" data-options="required:false"  style="z-index:9999;"/></td>
                        <td>血型：</td>
                        <td>
                            <input class="easyui-combobox" type="text" name="_116" id="_116" data-options="required:false" /></td>
                    </tr>
                    <tr>
                        <td>联系人：</td>
                        <td>
                            <input class="easyui-textbox" type="text" name="_88" id="_88" data-options="required:false" /></td>
                        <td>联系人电话：</td>
                        <td>
                            <input class="easyui-textbox" type="text" name="_87" id="_87" data-options="required:false" /></td>
                        <td>联系电话：</td>
                        <td>
                            <input class="easyui-textbox" type="text" name="_86" id="_86" data-options="required:false" /></td>
                    </tr>
                    <tr>
                        <td>籍贯：</td>
                        <td>
                            <input class="easyui-textbox" type="text" name="_89" id="_89" data-options="required:false" /></td>
                        <td>门诊流水号：</td>
                        <td>
                            <input class="easyui-textbox" type="text" name="_90" id="_90" data-options="required:false" /></td>
                        <td>患者ID：</td>
                        <td>
                            <input class="easyui-textbox" type="text" name="_91" id="_91" data-options="required:false" /></td>
                    </tr>
                    <tr>
                        <td>住院ID：</td>
                        <td>
                            <input class="easyui-textbox" type="text" name="_93" id="_93" data-options="required:false" /></td>
                        <td>挂号ID：</td>
                        <td>
                            <input class="easyui-textbox" type="text" name="_92" id="_92" data-options="required:false" /></td>
                    </tr>
                </table>
            </div>
        </div>
    </form>


</body>
</html>
